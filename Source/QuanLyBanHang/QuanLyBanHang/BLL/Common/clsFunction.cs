using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using EntityModel.DataModel;
using QuanLyBanHang.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyBanHang.BLL.Common
{
    public class clsFunction
    {
        #region Variables
        protected static aModel _accessModel, db;
        #endregion

        #region Contructor
        protected clsFunction() { }
        public static clsFunction Instance
        {
            get { return new clsFunction(); }
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

        public void SelectAsync<T>(XtraForm frmMain, GridControl gctMain, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        {
            var threadName = clsService.dManageThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(frmMain.Name));
            if (!string.IsNullOrEmpty(threadName))
            {
                ThreadObject oldThreadObject = clsService.dManageThreads[threadName].FirstOrDefault(x => x.Name.Equals(gctMain.Name));
                if (oldThreadObject != null)
                {
                    oldThreadObject.TokenSource.Cancel();
                    clsService.dManageThreads[threadName].Remove(oldThreadObject);
                }
            }
            else
            {
                threadName = frmMain.Name;
                clsService.dManageThreads.Add(threadName, new List<ThreadObject>());
            }

            System.Threading.CancellationTokenSource tokenSource = new System.Threading.CancellationTokenSource();
            ThreadObject newThreadObject = new ThreadObject() { Name = gctMain.Name, TokenSource = tokenSource, FrmMain = frmMain, CtrMain = gctMain };
            clsService.dManageThreads[threadName].Add(newThreadObject);

            db = new aModel();
            Timer timer = new Timer() { Interval = 1000 };
            DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);

            newThreadObject.Task = result.ForEachAsync((item) =>
             {
                 if (tokenSource.IsCancellationRequested) { return; }
                 else
                 {
                     if (gctMain.InvokeRequired)
                     {
                         try
                         {
                             Action<T> action = (obj) => { ListResult.Add(obj); };
                             gctMain.Invoke(action, item);
                         }
                         catch { }
                     }
                     else { ListResult.Add(item); }
                 }
             }, tokenSource.Token);

            timer.Tick += (sender, e) =>
            {
                if (ListResult.Any())
                {
                    if (gctMain.InvokeRequired)
                    {
                        Action action = () => { gctMain.RefreshDataSource(); };
                        gctMain.Invoke(action);
                    }
                    else { gctMain.RefreshDataSource(); }
                    timer.Enabled = false;
                }
            };

            if (!ListResult.Any())
                timer.Enabled = true;
        }

        public void SelectAsync<T>(XtraForm frmMain, TreeList trlMain, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        {
            var threadName = clsService.dManageThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(frmMain.Name));
            if (!string.IsNullOrEmpty(threadName))
            {
                ThreadObject oldThreadObject = clsService.dManageThreads[threadName].FirstOrDefault(x => x.Name.Equals(trlMain.Name));
                if (oldThreadObject != null)
                {
                    oldThreadObject.TokenSource.Cancel();
                    clsService.dManageThreads[threadName].Remove(oldThreadObject);
                }
            }
            else
            {
                threadName = frmMain.Name;
                clsService.dManageThreads.Add(threadName, new List<ThreadObject>());
            }

            System.Threading.CancellationTokenSource tokenSource = new System.Threading.CancellationTokenSource();
            ThreadObject newThreadObject = new ThreadObject() { Name = trlMain.Name, TokenSource = tokenSource, FrmMain = frmMain, CtrMain = trlMain };
            clsService.dManageThreads[threadName].Add(newThreadObject);

            db = new aModel();
            Timer timer = new Timer() { Interval = 1000 };
            DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);

            newThreadObject.Task = result.ForEachAsync((item) =>
            {
                if (tokenSource.IsCancellationRequested) { return; }
                else
                {
                    if (trlMain.InvokeRequired)
                    {
                        try
                        {
                            Action<T> action = (obj) => { ListResult.Add(obj); };
                            trlMain.Invoke(action, item);
                        }
                        catch { }
                    }
                    else { ListResult.Add(item); }
                }
            }, tokenSource.Token);

            timer.Tick += (sender, e) =>
            {
                if (ListResult.Any())
                {
                    if (trlMain.InvokeRequired)
                    {
                        Action action = () => { trlMain.RefreshDataSource(); };
                        trlMain.Invoke(action);
                    }
                    else { trlMain.RefreshDataSource(); }
                    timer.Enabled = false;
                }
            };

            if (!ListResult.Any())
                timer.Enabled = true;
        }

        public void SelectAsync<T>(XtraForm frmMain, LookUpEdit lokMain, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        {
            var threadName = clsService.dManageThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(frmMain.Name));
            if (!string.IsNullOrEmpty(threadName))
            {
                ThreadObject oldThreadObject = clsService.dManageThreads[threadName].FirstOrDefault(x => x.Name.Equals(lokMain.Name));
                if (oldThreadObject != null)
                {
                    oldThreadObject.TokenSource.Cancel();
                    clsService.dManageThreads[threadName].Remove(oldThreadObject);
                }
            }
            else
            {
                threadName = frmMain.Name;
                clsService.dManageThreads.Add(threadName, new List<ThreadObject>());
            }

            System.Threading.CancellationTokenSource tokenSource = new System.Threading.CancellationTokenSource();
            ThreadObject newThreadObject = new ThreadObject() { Name = lokMain.Name, TokenSource = tokenSource, FrmMain = frmMain, CtrMain = lokMain };
            clsService.dManageThreads[threadName].Add(newThreadObject);

            db = new aModel();
            Timer timer = new Timer() { Interval = 1000 };
            DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);

            newThreadObject.Task = result.ForEachAsync((item) =>
            {
                if (tokenSource.IsCancellationRequested) { return; }
                else
                {
                    if (lokMain.InvokeRequired)
                    {
                        try
                        {
                            Action<T> action = (obj) => { ListResult.Add(obj); };
                            lokMain.Invoke(action, item);
                        }
                        catch { }
                    }
                    else { ListResult.Add(item); }
                }
            }, tokenSource.Token);

            timer.Tick += (sender, e) =>
            {
                if (ListResult.Any())
                {
                    timer.Enabled = false;
                }
            };

            if (!ListResult.Any())
                timer.Enabled = true;
        }

        public void SelectAsync<T>(XtraForm frmMain, SearchLookUpEdit slokMain, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        {
            db = new aModel();
            Timer timer = new Timer() { Interval = 1000 };
            DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);

            result.ForEachAsync((item) =>
            {
                Action<T> action = (obj) => { ListResult.Add(obj); };
                slokMain.Invoke(action, item);
            });

            timer.Tick += (sender, e) =>
            {
                if (ListResult.Any()) { timer.Enabled = false; }
            };

            if (!ListResult.Any())
                timer.Enabled = true;
        }

        public void SelectAsync<T>(XtraForm frmMain, RepositoryItem repoMain, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        {
            var threadName = clsService.dManageThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(frmMain.Name));
            if (!string.IsNullOrEmpty(threadName))
            {
                ThreadObject oldThreadObject = clsService.dManageThreads[threadName].FirstOrDefault(x => x.Name.Equals(repoMain.Name));
                if (oldThreadObject != null)
                {
                    oldThreadObject.TokenSource.Cancel();
                    clsService.dManageThreads[threadName].Remove(oldThreadObject);
                }
            }
            else
            {
                threadName = frmMain.Name;
                clsService.dManageThreads.Add(threadName, new List<ThreadObject>());
            }

            System.Threading.CancellationTokenSource tokenSource = new System.Threading.CancellationTokenSource();
            ThreadObject newThreadObject = new ThreadObject() { Name = repoMain.Name, TokenSource = tokenSource, FrmMain = frmMain, RepoMain = repoMain };
            clsService.dManageThreads[threadName].Add(newThreadObject);

            db = new aModel();
            Timer timer = new Timer() { Interval = 1000 };
            DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);

            newThreadObject.Task = result.ForEachAsync((item) =>
              {
                  if (tokenSource.IsCancellationRequested) { return; }
                  else if (!frmMain.IsDisposed)
                  {
                      if (frmMain.InvokeRequired)
                      {
                          try
                          {
                              Action<T> action = (obj) => { ListResult.Add(obj); };
                              frmMain.Invoke(action, item);
                          }
                          catch { }
                      }
                      else
                      {
                          ListResult.Add(item);
                      }
                  }
              }, tokenSource.Token);

            timer.Tick += (sender, e) =>
            {
                if (ListResult.Any()) { timer.Enabled = false; }
            };

            if (!ListResult.Any())
                timer.Enabled = true;
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

        #region Test
        //public void Select<T>(XtraForm FrmMain, Object Control, IList<T> ListResult, string Query, SqlParameter[] Parameters) where T : class, new()
        //{
        //    db = new aModel();
        //    BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        //    Timer timer = new Timer() { Interval = 1000 };
        //    bool IsComplete = false;

        //    timer.Tick += (sender, e) =>
        //    {
        //        if (!IsComplete && ListResult.Any())
        //        {
        //            bWorker.ReportProgress(0);
        //            timer.Enabled = false;
        //        }
        //    };

        //    bWorker.DoWork += (sender, e) =>
        //    {
        //        try
        //        {
        //            DbRawSqlQuery<T> result = db.Database.SqlQuery<T>(Query, Parameters);
        //            foreach (T item in result)
        //            {
        //                Action<T> action = (obj) => { ListResult.Add(obj); };
        //                FrmMain.Invoke(action, item);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Action action = () =>
        //            {
        //                ListResult = new List<T>();
        //                clsGeneral.showErrorException(ex);
        //            };
        //            FrmMain.BeginInvoke(action);
        //        }
        //        IsComplete = true;
        //    };

        //    bWorker.ProgressChanged += (sender, e) =>
        //    {
        //        Action action = () => { RefreshControl((Control)Control); };
        //        FrmMain.BeginInvoke(action);
        //    };

        //    bWorker.RunWorkerCompleted += (sender, e) =>
        //    {
        //        Action action = () => { RefreshControl((Control)Control); };
        //        FrmMain.BeginInvoke(action);

        //        var _threadName = clsService.dThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(FrmMain.Name + "_" + (Control as Control).Name));
        //        if (!string.IsNullOrEmpty(_threadName))
        //            clsService.dThreads.Remove(_threadName);

        //        timer.Dispose();
        //        bWorker.Dispose();
        //    };

        //    var threadName = clsService.dThreads.Select(x => x.Key).FirstOrDefault(x => x.Equals(FrmMain.Name + "_" + (Control as Control).Name));
        //    if (string.IsNullOrEmpty(threadName))
        //    {
        //        clsService.dThreads.Add(FrmMain.Name + "_" + (Control as Control).Name, bWorker);
        //        bWorker.RunWorkerAsync();
        //        timer.Enabled = true;
        //    }
        //}
        #endregion
    }
}
