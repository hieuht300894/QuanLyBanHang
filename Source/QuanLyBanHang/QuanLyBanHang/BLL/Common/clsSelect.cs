using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyBanHang.BLL.Common
{
    public class clsSelect<T> : clsTemplate<T> where T : class, new()
    {
        #region Constructor
        private static volatile clsSelect<T> instance = null;
        private static readonly object mLock = new object();
        protected clsSelect() { }
        public new static clsSelect<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsSelect<T>();
                    }
                }
                return instance;
            }
        }

        #endregion

        #region Select Items

        /*
            Cách sử dụng hàm Delete Items:

            List<int> list = new List<int>();
            for(int i = 1; i <= 100000; i++) { list.Add(i); }
            clsPersonnel.Instance.Init();
            clsPersonnel.Instance.SetEntity(typeof(eTinhThanh).Name, list);
            clsPersonnel.Instance.ReloadProgress = LoadProgress;
            clsPersonnel.Instance.ReloadPercent = LoadPercent;
            clsPersonnel.Instance.ReloadMessage = LoadMessage;
            clsPersonnel.Instance.ReloadError = LoadError;
            clsPersonnel.Instance.StartRun();
         */
        public delegate void LoadProgress();
        public delegate void LoadData(int KeyID);
        public delegate void LoadPecent(int Percent);
        public delegate void LoadMessage(string Msg);
        public delegate void LoadError(Exception Ex);
        public delegate void AddData(T TObject, BindingList<T> ListData);
        public LoadData ReloadData;
        public LoadProgress ReloadProgress;
        public LoadPecent ReloadPercent;
        public LoadMessage ReloadMessage;
        public LoadError ReloadError;
        public AddData InsertData;
        private BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        Timer timer = new Timer() { Interval = 1000, Enabled = false };
        private BindingList<T> ListData = new BindingList<T>();
        private bool CurrentStatus = false;
        private int TotalNumber = 0;
        private int CurrentNumber = 0;

        public void Init()
        {
            bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            timer = new Timer() { Interval = 1000, Enabled = false };
            timer.Tick += timer_Tick;

            ListData = new BindingList<T>();
            CurrentStatus = false;
            TotalNumber = 0;
            CurrentNumber = 0;
        }

        public void SetEntity(BindingList<T> _ListData)
        {
            ListData = _ListData;
        }

        public void StartRun()
        {
            bWorker.RunWorkerAsync();
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (TotalNumber > 0 && bWorker.IsBusy)
            {
                int curPercent = Convert.ToInt32(((CurrentNumber * 1.0f) / TotalNumber) * 100);
                bWorker.ReportProgress(curPercent, bWorker.IsBusy);
            }
        }

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;

            timer.Dispose();
            bWorker.Dispose();

            ReloadData?.Invoke(0);
            ReloadPercent?.Invoke(100);
            ReloadMessage?.Invoke(CurrentStatus ? "Tải dữ liệu hoàn thành!" : "Tải dữ liệu không thành công!");
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
                timer.Enabled = false;

            ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ReloadProgress?.Invoke();
            CurrentStatus = SelectEntry();
        }

        public virtual bool SelectEntry()
        {
            DateTime CurrentDate = DateTime.Now.ServerNow();
            repository.Context = new aModel();
            try
            {
                Type type = typeof(T);
                var result = repository.Context.SearchRange(type.Name, type, new Dictionary<string, object>(), new Dictionary<string, object>());

                //result.ForEachAsync((obj) =>
                //{
                //    //ListData.Add(obj as T);
                //    InsertData?.Invoke((T)obj, ListData);
                //    TotalNumber++;
                //    CurrentNumber++;
                //});

                foreach (var obj in result)
                {
                    InsertData?.Invoke((T)obj, ListData);
                    TotalNumber++;
                    CurrentNumber++;
                }
                return true;
            }
            catch (Exception ex)
            {
                ReloadError?.Invoke(ex);
                return false;
            }
        }

        public DbSet getDbSet(string tableName)
        {
            Assembly asse = Assembly.Load("EntityModel");
            Module mod = asse.GetModules().FirstOrDefault(x => x.Name.Contains("EntityModel"));
            if (mod != null)
            {
                Type type = mod.Assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(tableName));
                if (type != null) return repository.Context.Set(type);
            }
            return null;
        }

        public Type GetInstance(string tableName)
        {
            Assembly asse = Assembly.Load("EntityModel");
            Module mod = asse.GetModules().FirstOrDefault(x => x.Name.Contains("EntityModel"));
            if (mod != null) return mod.Assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(tableName));
            else return null;
        }
        #endregion
    }
}
