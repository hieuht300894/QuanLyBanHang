using EntityModel.DataModel;
using QuanLyBanHang.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.ComponentModel;
using System.Data.Entity;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyBanHang.BLL.Common
{
    public class clsTemplate<T> where T : class, new()
    {
        #region Variable
        protected static Repository<T> repository;
        protected static RepositoryCollection collection;
        #endregion

        #region Constructor
        private static volatile clsTemplate<T> instance = null;
        private static readonly object mLock = new object();
        protected clsTemplate()
        {
            collection = new RepositoryCollection();
            repository = collection.GetRepo<T>();
        }
        public static clsTemplate<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsTemplate<T>();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Common Function
        public virtual List<T> GetAll()
        {
            try
            {
                repository.Context = new aModel();
                IEnumerable<T> lstTemp = repository.Context.Set<T>().AsEnumerable();
                List<T> lstResult = lstTemp.ToList();
                return lstResult;
            }
            catch
            {
                return new List<T>();
            }
        }

        public virtual T GetByID(int KeyID)
        {
            try
            {
                repository.Context = new aModel();
                T entry = repository.Context.Set<T>().Find(KeyID);
                return entry ?? new T();
            }
            catch { return new T(); }
        }

        public virtual T GetEntry(int KeyID)
        {
            try
            {
                repository.Context = new aModel();
                T entry = repository.Context.Set<T>().Find(KeyID);
                return entry ?? new T();
            }
            catch { return new T(); }
        }

        public virtual bool InsertEntry(T entry)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();
                repository.Context.Set<T>().AddOrUpdate(entry);
                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi thêm mới: {typeof(T).Name}");
                return false;
            }
        }

        public virtual bool UpdateEntry(T entry)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();
                repository.Context.Set<T>().AddOrUpdate(entry);
                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi cập nhật: {typeof(T).Name}");
                return false;
            }
        }

        public virtual bool DeleteEntry(T entry)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();
                repository.Context.Set<T>().Remove(entry);
                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi xóa: {typeof(T).Name}");
                return false;
            }
        }
        #endregion

        #region Delete Items
        public delegate void LoadStatus(bool status);
        public delegate void LoadPecent(int percent);
        public LoadStatus ReloadStatus;
        public LoadPecent ReloadPercent;
        //private List<int> ListEntry;
        private BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        Timer timer = new Timer() { Interval = 1000, Enabled = false };
        private Dictionary<string, List<int>> ListEntity = new Dictionary<string, List<int>>();
        private bool CurrentStatus = false;
        private int TotalNumber = 0;
        private int CurrentNumber = 0;
        private DateTime CurrentDate;

        public void Init()
        {
            bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            timer = new Timer() { Interval = 1000, Enabled = false };
            timer.Tick += timer_Tick;

            ListEntity = new Dictionary<string, List<int>>();
            CurrentStatus = false;
            TotalNumber = 0;
            CurrentNumber = 0;
        }

        public void SetEntity(string Name, List<int> _lstEntry)
        {
            ListEntity.Add(Name, _lstEntry);
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

            ReloadStatus?.Invoke(CurrentStatus);
            ReloadPercent?.Invoke(100);

            clsGeneral.showMessage((DateTime.Now.ServerNow().Minute - CurrentDate.Minute).ToString());
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
                timer.Enabled = false;

            ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CurrentNumber = 0;

            if (ListEntity != null)
                ListEntity.ToList().ForEach(x => TotalNumber += x.Value.Count);

            CurrentStatus = RemoveEntry();
        }

        //private bool RemoveEntry()
        //{
        //    try
        //    {
        //        repository.Context = new aModel();
        //        foreach (var entity in ListEntity)
        //        {
        //            DbSet dbSet = getDbSet(entity.Key);
        //            if (dbSet == null)
        //                return false;
        //            foreach (int id in entity.Value)
        //            {
        //                object obj = dbSet.Find(id);
        //                if (obj != null)
        //                {
        //                    xLog log = new xLog();
        //                    log.AccessDate = CurrentDate;
        //                    log.IDPersonnel = clsGeneral.curPersonnel.KeyID;
        //                    log.State = EntityState.Deleted.ToString();
        //                    log.TableName = entity.Key;
        //                    log.OldValue = obj.Serialize();
        //                    repository.Context.xLog.AddOrUpdate(log);
        //                    dbSet.Remove(obj);
        //                }
        //                CurrentNumber++;
        //            }
        //        }
        //        repository.Context.SaveChangesAsync().Wait();
        //        return true;
        //    }
        //    catch { return false; }
        //}

        //private bool RemoveEntry()
        //{
        //    try
        //    {
        //        CurrentDate = DateTime.Now.ServerNow();
        //        repository.Context = new aModel();
        //        repository.BeginTransaction();
        //        foreach (var entity in ListEntity)
        //        {
        //            DbSet dbSet = getDbSet(entity.Key);
        //            if (dbSet == null)
        //                return false;
        //            foreach (int id in entity.Value)
        //            {
        //                string qSelect = "select * from " + entity.Key + " where KeyID=@KeyID";
        //                object obj = dbSet.SqlQuery(qSelect, new SqlParameter("@KeyID", id)).ToListAsync().Result.FirstOrDefault();
        //                if (obj != null)
        //                {
        //                    string qInsert = $"insert into xLog (AccessDate,IDPersonnel,State,TableName,OldValue) values(@AccessDate,@IDPersonnel,@State,@TableName,@OldValue)";
        //                    repository.Context.Database.ExecuteSqlCommand(
        //                        qInsert,
        //                        new SqlParameter("@AccessDate", CurrentDate),
        //                        new SqlParameter("@IDPersonnel", clsGeneral.curPersonnel.KeyID),
        //                        new SqlParameter("@State", EntityState.Deleted.ToString()),
        //                        new SqlParameter("@TableName", entity.Key),
        //                        new SqlParameter("@OldValue", obj.Serialize()));

        //                    string qDelete = $"delete from {entity.Key} where KeyID=@KeyID";
        //                    repository.Context.Database.ExecuteSqlCommand(qDelete, new SqlParameter("@KeyID", id));
        //                }
        //                else
        //                    return false;
        //                CurrentNumber++;
        //            }
        //        }
        //        repository.Context.SaveChangesAsync().Wait();
        //        repository.Commit();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        repository.Rollback();
        //        clsGeneral.showErrorException(ex);
        //        return false;
        //    }
        //}

        private bool RemoveEntry()
        {
            CurrentDate = DateTime.Now.ServerNow();
            repository.Context = new aModel();
            SqlConnection conn = new SqlConnection(repository.Context.Database.Connection.ConnectionString);
            SqlTransaction tran = null;
            try
            {
                conn.Open();
                tran = conn.BeginTransaction(System.Data.IsolationLevel.Serializable);

                foreach (var entity in ListEntity)
                {
                    Type type = null;
                    GetInstance(entity.Key, ref type);

                    if (type == null) return false;

                    int minID = entity.Value.DefaultIfEmpty().Min();
                    int maxID = entity.Value.DefaultIfEmpty().Max();
                    string qSelect = $"SELECT * FROM {entity.Key} WHERE KeyID BETWEEN {minID} AND {maxID}";
                    SqlCommand cmdSelect = new SqlCommand(qSelect, conn, tran);
                    List<Dictionary<string, object>> listParent = new List<Dictionary<string, object>>(cmdSelect.ExecuteReader().CreateObjects(type));
                    int countSelect = listParent.Count;
                    int currentSelect = 0;
                    foreach (int id in entity.Value)
                    {
                        Dictionary<string, object> listChild = listParent[currentSelect++];
                        bool chk = listChild.Any(x => x.Key.Equals("KeyID") && x.Value.Equals(id));
                        if (!chk) return false;
                        else
                        {
                            string qInsert = $"INSERT INTO xLog (AccessDate,IDPersonnel,State,TableName,OldValue) VALUES (@AccessDate,@IDPersonnel,@State,@TableName,@OldValue)";
                            SqlCommand cmdInsert = new SqlCommand(qInsert, conn, tran);
                            cmdInsert.Parameters.Add("@AccessDate", System.Data.SqlDbType.DateTime).Value = CurrentDate;
                            cmdInsert.Parameters.Add("@IDPersonnel", System.Data.SqlDbType.Int).Value = clsGeneral.curPersonnel.KeyID;
                            cmdInsert.Parameters.Add("@State", System.Data.SqlDbType.NVarChar).Value = EntityState.Deleted.ToString();
                            cmdInsert.Parameters.Add("@TableName", System.Data.SqlDbType.NVarChar).Value = entity.Key;
                            cmdInsert.Parameters.Add("@OldValue", System.Data.SqlDbType.NVarChar).Value = listChild.SerializeJSON();
                            cmdInsert.ExecuteNonQuery();

                            string qDelete = $"DELETE FROM {entity.Key} WHERE KeyID=@KeyID";
                            SqlCommand cmdDelete = new SqlCommand(qDelete, conn, tran);
                            cmdDelete.Parameters.Add("@KeyID", System.Data.SqlDbType.Int).Value = id;
                            cmdDelete.ExecuteNonQuery();

                        }
                        CurrentNumber++;
                    }
                }

                tran.Commit();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                conn.Close();
                clsGeneral.showErrorException(ex);
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
                if (type != null)
                    return repository.Context.Set(type);
            }
            return null;
        }

        public void GetInstance(string tableName, ref Type type)
        {
            Assembly asse = Assembly.Load("EntityModel");
            Module mod = asse.GetModules().FirstOrDefault(x => x.Name.Contains("EntityModel"));
            if (mod != null) type = mod.Assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(tableName));
        }
        #endregion
    }
}
