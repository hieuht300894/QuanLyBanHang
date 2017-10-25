using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using EntityModel.DataModel;
using QuanLyBanHang.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyBanHang.BLL.Common
{
    public class clsFunction
    {
        #region Variables
        protected static aModel _accessModel, db;
        private static volatile clsFunction instance = null;
        private static readonly object mLock = new object();
        #endregion

        #region Contructor
        protected clsFunction()
        {
        }
        public static clsFunction Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsFunction();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Implement Method
        public void Insert()
        {
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }

        public IList<T> Select<T>(string Query, SqlParameter[] parameters) where T : class, new()
        {
            IList<T> ListResult = new List<T>();
            return ListResult;
        }

        public void Select<T>(XtraForm FrmMain, Object Control, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        {
            db = new aModel();
            BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            Timer timer = new Timer() { Interval = 1000 };
            bool IsComplete = false;
            int CurrentSecond = 0;

            timer.Tick += (sender, e) =>
            {
                CurrentSecond++;
                if (!IsComplete && CurrentSecond == 5)
                    bWorker.ReportProgress(0);
            };

            bWorker.DoWork += (sender, e) =>
            {
                try
                {
                    DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);
                    foreach (T item in result)
                    {
                        Action<T> action = (obj) => { ListResult.Add(obj); };
                        FrmMain.Invoke(action, item);
                    }
                }
                catch (Exception ex)
                {
                    Action action = () =>
                    {
                        ListResult = new List<T>();
                        clsGeneral.showErrorException(ex);
                    };
                    FrmMain.Invoke(action);
                }
                IsComplete = true;
            };

            bWorker.ProgressChanged += (sender, e) =>
            {
                Action action = () => { RefreshControl((Control)Control); };
                FrmMain.Invoke(action);
            };

            bWorker.RunWorkerCompleted += (sender, e) =>
            {
                timer.Enabled = false;

                Action action = () => { RefreshControl((Control)Control); };
                FrmMain.Invoke(action);

                var _threadName = clsService.dThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(FrmMain.Name + "_" + (Control as Control).Name));
                if (!string.IsNullOrEmpty(_threadName))
                    clsService.dThreads.Remove(_threadName);

                timer.Dispose();
                bWorker.Dispose();
            };
            var threadName = clsService.dThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(FrmMain.Name + "_" + (Control as Control).Name));
            if (string.IsNullOrEmpty(threadName))
            {
                clsService.dThreads.Add(FrmMain.Name + "_" + (Control as Control).Name, bWorker);
                bWorker.RunWorkerAsync();
                timer.Enabled = true;
            }
        }

        private void RefreshControl(Control Ctr)
        {
            if (Ctr is GridControl)
            {
                GridControl gctMain = (GridControl)Ctr;
                gctMain.RefreshDataSource();
            }
        }
        #endregion

        #region Base Method
        public virtual List<T> GetAll<T>() where T : class, new()
        {
            try
            {
                db = new aModel();
                IEnumerable<T> lstTemp = db.Set<T>().AsEnumerable();
                List<T> lstResult = lstTemp.ToList();
                return lstResult;
            }
            catch
            {
                return new List<T>();
            }
        }

        public virtual T GetByID<T>(int KeyID) where T : class, new()
        {
            try
            {
                db = new aModel();
                T entry = db.Set<T>().Find(KeyID);
                return entry ?? new T();
            }
            catch { return new T(); }
        }

        public virtual bool AddOrUpdate<T>(T entry) where T : class, new()
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.Set<T>().AddOrUpdate(entry);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi AddOrUpdate: {typeof(T).Name}");
                return false;
            }
        }

        public virtual bool DeleteEntry<T>(T entry) where T : class, new()
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.Set<T>().Attach(entry);
                db.Set<T>().Remove(entry);
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi Delete: {typeof(T).Name}");
                return false;
            }
        }
        #endregion
    }
}
