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
using System.Threading.Tasks;

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

        public virtual bool AddOrUpdate(T entry)
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
                clsGeneral.showErrorException(ex, $"Lỗi AddOrUpdate: {typeof(T).Name}");
                return false;
            }
        }

        public virtual bool DeleteEntry(T entry)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();
                repository.Context.Set<T>().Attach(entry);
                repository.Context.Set<T>().Remove(entry);
                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi Delete: {typeof(T).Name}");
                return false;
            }
        }
        #endregion

        #region Delete Items

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
        public LoadData ReloadData;
        public LoadProgress ReloadProgress;
        public LoadPecent ReloadPercent;
        public LoadMessage ReloadMessage;
        public LoadError ReloadError;
        private BackgroundWorker bWorker = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        Timer timer = new Timer() { Interval = 1000, Enabled = false };
        private Dictionary<string, List<int>> ListEntity = new Dictionary<string, List<int>>();
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

            ListEntity = new Dictionary<string, List<int>>();
            CurrentStatus = false;
            TotalNumber = 0;
            CurrentNumber = 0;
        }

        public void SetEntity(string Name, List<int> _lstEntry)
        {
            ListEntity.Add(Name, _lstEntry.OrderBy(x => x).ToList());
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
            ReloadMessage?.Invoke(CurrentStatus ? "Xóa dữ liệu hoàn thành!" : "Xóa dữ liệu không thành công!");
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
                timer.Enabled = false;

            ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ListEntity != null)
                ListEntity.ToList().ForEach(x => TotalNumber += x.Value.Count);

            ReloadProgress?.Invoke();
            CurrentStatus = RemoveEntry();
        }

        //private bool RemoveEntry()
        //{
        //    DateTime CurrentDate = DateTime.Now.ServerNow();
        //    repository.Context = new aModel();
        //    SqlConnection conn = new SqlConnection(repository.Context.Database.Connection.ConnectionString);
        //    SqlTransaction tran = null;
        //    try
        //    {
        //        conn.Open();
        //        tran = conn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        //        foreach (var entity in ListEntity)
        //        {
        //            Type type = GetInstance(entity.Key);
        //            if (type == null) return false;

        //            int minID = entity.Value.DefaultIfEmpty().Min();
        //            int maxID = entity.Value.DefaultIfEmpty().Max();
        //            string qSelect = $"SELECT * FROM {entity.Key} WHERE KeyID BETWEEN {minID} AND {maxID}";
        //            SqlCommand cmdSelect = new SqlCommand(qSelect, conn, tran);
        //            List<Dictionary<string, object>> listParent = new List<Dictionary<string, object>>(cmdSelect.ExecuteReader().CreateObjects(type));
        //            int countSelect = listParent.Count;
        //            int currentSelect = 0;
        //            foreach (int id in entity.Value)
        //            {
        //                Dictionary<string, object> listChild = listParent[currentSelect];
        //                bool chk = listChild.Any(x => x.Key.Equals("KeyID") && x.Value.Equals(id));
        //                if (!chk) return false;
        //                else
        //                {
        //                    string qInsert = $"INSERT INTO xLog (AccessDate,IDPersonnel,State,TableName,OldValue) VALUES (@AccessDate,@IDPersonnel,@State,@TableName,@OldValue)";
        //                    SqlCommand cmdInsert = new SqlCommand(qInsert, conn, tran);
        //                    cmdInsert.Parameters.Add("@AccessDate", System.Data.SqlDbType.DateTime).Value = CurrentDate;
        //                    cmdInsert.Parameters.Add("@IDPersonnel", System.Data.SqlDbType.Int).Value = clsGeneral.curPersonnel.KeyID;
        //                    cmdInsert.Parameters.Add("@State", System.Data.SqlDbType.NVarChar).Value = EntityState.Deleted.ToString();
        //                    cmdInsert.Parameters.Add("@TableName", System.Data.SqlDbType.NVarChar).Value = entity.Key;
        //                    cmdInsert.Parameters.Add("@OldValue", System.Data.SqlDbType.NVarChar).Value = listChild.SerializeJSON();
        //                    cmdInsert.ExecuteNonQuery();

        //                    string qDelete = $"DELETE FROM {entity.Key} WHERE KeyID=@KeyID";
        //                    SqlCommand cmdDelete = new SqlCommand(qDelete, conn, tran);
        //                    cmdDelete.Parameters.Add("@KeyID", System.Data.SqlDbType.Int).Value = id;
        //                    cmdDelete.ExecuteNonQuery();
        //                }
        //                currentSelect++;
        //                CurrentNumber++;
        //            }
        //        }

        //        tran.Commit();
        //        conn.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        tran.Rollback();
        //        conn.Close();
        //        ReloadError?.Invoke(ex);
        //        return false;
        //    }
        //}

        private bool RemoveEntry()
        {
            DateTime CurrentDate = DateTime.Now.ServerNow();
            repository.Context = new aModel();
            try
            {
                repository.BeginTransaction();
                List<ColumnKey> lstPrimaryKeys = new List<ColumnKey>(repository.Context.GetPrimaryKeys());

                foreach (var entity in ListEntity)
                {
                    DbSet dbSet = getDbSet(entity.Key);
                    if (dbSet == null) return false;
                    Type type = GetInstance(entity.Key);
                    if (type == null) return false;

                    int minID = entity.Value.DefaultIfEmpty().Min();
                    int maxID = entity.Value.DefaultIfEmpty().Max();

                    var qColumnsKey = new List<ColumnKey>(repository.Context.GetColumnKeys(lstPrimaryKeys, entity.Key));
                    //var qColumnsNotKey = new List<string>(repository.Context.GetColumnNotKeys(qColumnsKey.Select(x => x.COLUMN_NAME).ToList(), type.GetProperties().Select(x => x.Name).ToList(), entity.Key));

                    var result = repository.Context.SearchRange(
                        entity.Key,
                        type,
                        new Dictionary<string, object>() { { "KeyID", minID } },
                        new Dictionary<string, object>() { { "KeyID", maxID } });

                    foreach (var obj in result)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (ColumnKey info in qColumnsKey)
                        {
                            var tempProperty = obj.GetType().GetProperty(info.COLUMN_NAME);
                            var tempType = tempProperty.PropertyType;
                            var tempValue = tempProperty.GetValue(obj);
                            if (tempValue != null)
                                dic.Add(info.COLUMN_NAME, Convert.ChangeType(tempValue, tempType));
                            else
                                dic.Add(info.COLUMN_NAME, tempValue);
                        }
                        repository.Context.SaveDelete(entity.Key, dic);
                        CurrentNumber++;
                    }
                }
                repository.Context.SaveChangesAsync();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
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
