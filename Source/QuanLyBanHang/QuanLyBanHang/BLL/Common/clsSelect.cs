using EntityModel.DataModel;
using QuanLyBanHang.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace QuanLyBanHang.BLL.Common
{
    public partial class clsSelect<T> where T : class, new()
    {
        #region Variable
        protected Repository<T> repository;
        protected RepositoryCollection collection;
        #endregion

        #region Constructor
        public clsSelect()
        {
            collection = new RepositoryCollection();
            repository = collection.GetRepo<T>();
        }
        ~clsSelect()
        {
            timer.Dispose();
            bWorker.Dispose();
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
        public delegate void OpenProgress();
        public delegate void CloseProgress();
        public delegate void LoadPecent(int Percent);
        public delegate void LoadMessage(string Msg);
        public delegate void LoadError(Exception Ex);
        public delegate void InsertObjectToList(T TObject, IList<T> ListData);
        public OpenProgress _OpenProgress;
        public CloseProgress _CloseProgress;
        public LoadPecent _ReloadPercent;
        public LoadMessage _ReloadMessage;
        public LoadError _ReloadError;
        public InsertObjectToList _InsertObjectToList;
        BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 1000, Enabled = false };
        IList<T> ListData = new List<T>();
        Dictionary<string, object> dValueFrom = new Dictionary<string, object>();
        Dictionary<string, object> dValueTo = new Dictionary<string, object>();
        bool CurrentStatus = false;
        bool IsComplete = false;
        int TotalNumber = 0;
        int CurrentNumber = 0;
        int CurrentPercent = 0;

        public void Init()
        {
            bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            timer = new System.Windows.Forms.Timer() { Interval = 1000, Enabled = false };
            timer.Tick += timer_Tick;

            ListData = new List<T>();
            IsComplete = false;
            CurrentStatus = false;
            TotalNumber = 0;
            CurrentNumber = 0;
            CurrentPercent = 0;
        }

        public void SetEntity(IList<T> ListData)
        {
            this.ListData = ListData;
        }

        public void SetSearch(Dictionary<string, object> dValueFrom, Dictionary<string, object> dValueTo)
        {
            this.dValueFrom = dValueFrom ?? new Dictionary<string, object>();
            this.dValueTo = dValueTo ?? new Dictionary<string, object>();
        }

        public void StartRun()
        {
            bWorker.RunWorkerAsync();
            timer.Enabled = true;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (TotalNumber > 0 && !IsComplete)
            {
                CurrentPercent = Convert.ToInt32(((CurrentNumber * 1.0f) / TotalNumber) * 100);
                bWorker.ReportProgress(CurrentPercent);
            }
        }

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;

            _CloseProgress?.Invoke();
            _ReloadPercent?.Invoke(CurrentPercent);
            _ReloadMessage?.Invoke(CurrentStatus ? "Tải dữ liệu hoàn thành!" : "Tải dữ liệu không thành công!");
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        public virtual void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _OpenProgress?.Invoke();
            CurrentStatus = SelectEntry();
            IsComplete = true;
        }

        private bool SelectEntry()
        {
            DateTime CurrentDate = DateTime.Now.ServerNow();
            repository.Context = new aModel();
            try
            {
                Type type = typeof(T);
                TotalNumber = repository.Context.GetTotalRow(type.Name, dValueFrom, dValueTo);
                var result = repository.Context.SearchRange(type.Name, type, dValueFrom, dValueTo);

                foreach (T obj in result)
                {
                    if (bWorker.CancellationPending) { break; }
                    _InsertObjectToList?.Invoke(obj, ListData);
                    CurrentNumber++;
                }
                return true;
            }
            catch (Exception ex)
            {
                _ReloadError?.Invoke(ex);
                return false;
            }
        }
        #endregion
    }
}
