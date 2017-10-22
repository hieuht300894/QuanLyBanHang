using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.BLL.Common
{
    public partial class clsCustomForm
    {
        #region Variable
        #endregion

        #region Constructor
        public clsCustomForm()
        {
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
        public delegate void CallMethod(string Method);
        public OpenProgress _OpenProgress;
        public CloseProgress _CloseProgress;
        public LoadPecent ReloadPercent;
        public LoadMessage ReloadMessage;
        public LoadError ReloadError;
        public CallMethod _CallMethod;
        private BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        Timer timer = new Timer() { Interval = 1000, Enabled = false };
        private List<string> ListData = new List<string>();
        private bool CurrentStatus = false;
        private bool IsComplete = false;
        private int TotalNumber = 0;
        private int CurrentNumber = 0;
        private int CurrentPercent = 0;

        public void Init()
        {
            bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            timer = new Timer() { Interval = 1000, Enabled = false };
            timer.Tick += timer_Tick;

            IsComplete = false;
            CurrentStatus = false;
            TotalNumber = 0;
            CurrentNumber = 0;
            CurrentPercent = 0;
        }

        public void SetEntity(List<string> _ListData)
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
            if (TotalNumber > 0 && !IsComplete)
            {
                CurrentPercent = Convert.ToInt32(((CurrentNumber * 1.0f) / TotalNumber) * 100);
                bWorker.ReportProgress(CurrentPercent);
            }
        }

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;
            timer.Dispose();
            bWorker.Dispose();

            _CloseProgress?.Invoke();
            ReloadPercent?.Invoke(CurrentPercent);
            ReloadMessage?.Invoke(CurrentStatus ? "Tải dữ liệu hoàn thành!" : "Tải dữ liệu không thành công!");
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _OpenProgress?.Invoke();
            CurrentStatus = CustomForm();
            IsComplete = !IsComplete;
        }

        public virtual bool CustomForm()
        {
            DateTime CurrentDate = DateTime.Now.ServerNow();
            try
            {
                TotalNumber = ListData.Count;

                foreach(string str in ListData)
                {
                    _CallMethod?.Invoke(str);
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
        #endregion
    }
}
