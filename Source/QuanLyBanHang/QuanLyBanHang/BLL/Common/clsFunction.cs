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
using System.Threading.Tasks;
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
        public async virtual Task<IList<T>> GetAll<T>() where T : class, new()
        {
            try
            {
                db = new aModel();
                var qResult = db.Database.SqlQuery<T>($"SELECT * FROM {typeof(T).Name}", new SqlParameter[] { });
                return await qResult.ToListAsync();
            }
            catch { return new List<T>(); }
        }

        public async virtual Task<T> GetByID<T>(object KeyID) where T : class, new()
        {
            try
            {
                db = new aModel();
                T item = await db.Set<T>().FindAsync(KeyID);
                return item ?? new T();
            }
            catch { return new T(); }
        }

        public async virtual Task<bool> AddOrUpdate<T>(T entry) where T : class, new()
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    db.Set<T>().AddOrUpdate(entry);
                    var res = db.SaveChangesAsync();
                    tran.Commit();
                    return true;
                });
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi AddOrUpdate: {typeof(T).Name}");
                return false;
            }
        }

        public async virtual Task<bool> AddOrUpdate<T>(List<T> entries) where T : class, new()
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    entries.ForEach(x => db.Set<T>().AddOrUpdate(x));
                    var res = db.SaveChangesAsync();
                    tran.Commit();
                    return true;
                });
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
