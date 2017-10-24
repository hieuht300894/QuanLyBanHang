using DevExpress.XtraEditors;
using EntityModel.DataModel;
using QuanLyBanHang.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAL
{
    public abstract class Function<T> : ISelect<T>, IInsert<T>, IUpdate<T>, IDelete<T> where T : class, new()
    {
        #region Variables
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
        protected Repository<T> repository;
        protected RepositoryCollection collection;
        BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 1000, Enabled = false };
        IList<T> ListData = new List<T>();
        Dictionary<string, object> dValueFrom = new Dictionary<string, object>();
        Dictionary<string, object> dValueTo = new Dictionary<string, object>();
        string FormName = string.Empty;
        string ControlName = string.Empty;
        bool CurrentStatus = false;
        bool IsComplete = false;
        int TotalNumber = 0;
        int CurrentNumber = 0;
        int CurrentPercent = 0;
        #endregion

        #region Constructor
        public Function(string FormName, string ControlName)
        {
            collection = new RepositoryCollection();
            repository = collection.GetRepo<T>();
            this.FormName = FormName;
            this.ControlName = ControlName;
        }
        ~Function()
        {
            timer.Dispose();
            bWorker.Dispose();
        }
        #endregion

        #region Default Method
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
            var threadName = clsService.dThreads.Select(x=>x.Key).FirstOrDefault(x => x.Equals(FormName + "_" + ControlName));
            if (string.IsNullOrEmpty(threadName))
            {
                clsService.dThreads.Add(FormName + "_" + ControlName, bWorker);
                _OpenProgress?.Invoke();
                bWorker.RunWorkerAsync();
                timer.Enabled = true;
            }
        }

        private void ResetThread()
        {
            clsService.dThreads.Remove(FormName + "_" + ControlName);
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

            ResetThread();
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        public virtual void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
        }
        #endregion

        #region Implement Method
        public virtual void Select()
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
                CurrentStatus = true;
            }
            catch (Exception ex)
            {
                _ReloadError?.Invoke(ex);
                CurrentStatus = false;
            }

            IsComplete = true;
        }

        public void Insert()
        {
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }
        #endregion
    }

    public interface ISelect<T> where T : class, new()
    {
        void Select();
    }

    public interface IInsert<T> where T : class, new()
    {
        void Insert();
    }

    public interface IUpdate<T> where T : class, new()
    {
        void Update();
    }

    public interface IDelete<T> where T : class, new()
    {
        void Delete();
    }
}
