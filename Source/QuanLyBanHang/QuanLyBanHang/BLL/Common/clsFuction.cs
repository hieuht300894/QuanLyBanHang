using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.Threading;
using System.Reflection;

namespace QuanLyBanHang.BLL.Common
{
    class clsFuction
    {
        #region Constructor
        private static volatile clsFuction instance = null;
        private static readonly object mLock = new object();
        protected clsFuction() { }
        public static clsFuction Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsFuction();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        aModel db, _accessModel;
        public T getEntry<T>(int KeyID) where T : class, new()
        {
            try
            {
                _accessModel = new aModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return null;
                return (T)entity.Find(KeyID);
            }
            catch { return null; }
        }

        public IList<T> getListEntry<T>() where T : class, new()
        {
            try
            {
                _accessModel = new aModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return null;

                IEnumerable<T> lstTemp = entity.OfType<T>().AsEnumerable<T>();
                return lstTemp.Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID && Convert.ToBoolean(x.GetStringByName("IsEnable"))).ToList<T>();
            }
            catch { return new List<T>(); }
        }

        public int getMaxKeyID<T>() where T : class
        {
            try
            {
                db = new aModel();
                DbSet entity = db.Set<T>();
                if (entity == null)
                    return 0;

                IEnumerable<T> lstTemp = entity.OfType<T>().AsEnumerable<T>();
                lstTemp = lstTemp.Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID).ToList<T>();
                if (lstTemp.Any())
                    return lstTemp.MaxIndex<T>() + 1;
                else
                    return 0;
            }
            catch { return 0; }
        }

        public IList<T> searchListEntry<T>(bool IsEnable) where T : class, new()
        {
            try
            {
                _accessModel = new aModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return null;

                IEnumerable<T> lstTemp = entity.OfType<T>().AsEnumerable<T>();
                return lstTemp.Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID && Convert.ToBoolean(x.GetStringByName("IsEnable")) == IsEnable).ToList<T>();
            }
            catch { return new List<T>(); }
        }

        public bool deleteEntry<T>(List<T> lstEntry) where T : class, new()
        {
            try
            {
                _accessModel = new aModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return false;

                foreach (T item in lstEntry)
                {
                    T edt = (T)entity.Find(item.GetInt32ByName("KeyID"));
                    _accessModel.Entry(edt).CurrentValues.SetValues(item);
                }

                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool accessEntry<T>(T entry) where T : class, new()
        {
            try
            {
                _accessModel = new aModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return false;

                if (entry.GetInt32ByName("KeyID") > 0)
                {
                    T edtEntry = (T)entity.Find(entry.GetInt32ByName("KeyID"));
                    _accessModel.Entry(edtEntry).CurrentValues.SetValues(entry);
                }
                else
                    entity.Add(entry);

                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool accessEntry<T>(BindingList<T> lstEntry) where T : class, new()
        {
            try
            {
                _accessModel = new aModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return false;

                foreach (T entry in lstEntry)
                {
                    if (entry.GetInt32ByName("KeyID") > 0)
                    {
                        T edtEntry = (T)entity.Find(entry.GetInt32ByName("KeyID"));
                        _accessModel.Entry(edtEntry).CurrentValues.SetValues(entry);
                    }
                    else
                        entity.Add(entry);
                }

                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        #endregion
    }


    //public partial class DeleteEntry<T1, T2, T3>
    //    where T1 : class
    //    where T2 : class
    //    where T3 : class
    //{
    //    System.Windows.Forms.Timer timer;
    //    public delegate void LoadStatus(bool _status);
    //    public delegate void LoadPecent(int _num);
    //    public LoadStatus ReloadStatus;
    //    public LoadPecent ReloadPercent;
    //    private readonly List<int> ListEntry;
    //    private BackgroundWorker bWorker;
    //    private bool status;
    //    private Dictionary<string, List<int>> ListEntity;
    //    private int lenght = 0;
    //    private int cur = 0;
    //    aModel db;
    //    public DeleteEntry(List<int> _ListEntry)
    //    {
    //        this.ListEntry = _ListEntry;
    //        _BackgroundWorker();
    //    }

    //    private void _BackgroundWorker()
    //    {
    //        bWorker = new BackgroundWorker();
    //        bWorker.WorkerReportsProgress = true;
    //        bWorker.WorkerSupportsCancellation = true;

    //        bWorker.DoWork += bWorker_DoWork;
    //        bWorker.ProgressChanged += bWorker_ProgressChanged;
    //        bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

    //        if (Thread.CurrentThread.Name == null)
    //            Thread.CurrentThread.Name = "Deleting" + typeof(T1).Name;
    //    }

    //    public DeleteEntry()
    //    {
    //        this.ListEntity = new Dictionary<string, List<int>>();
    //        _BackgroundWorker();
    //    }

    //    public void SetEntity(string Name, List<int> _lstEntry)
    //    {
    //        ListEntity.Add(Name, _lstEntry);
    //    }

    //    public void StartRun()
    //    {
    //        db = new aModel();
    //        timer = new System.Windows.Forms.Timer();
    //        timer.Tick += timer_Tick;
    //        timer.Interval = 1000;
    //        timer.Enabled = false;
    //        bWorker.RunWorkerAsync();
    //        timer.Enabled = true;
    //        timer.Start();
    //    }

    //    void timer_Tick(object sender, EventArgs e)
    //    {
    //        if (lenght > 0 && bWorker.IsBusy)
    //        {
    //            int curPercent = Convert.ToInt32(((cur * 1.0f) / lenght) * 100);
    //            bWorker.ReportProgress(curPercent, bWorker.IsBusy);
    //        }
    //    }

    //    ~DeleteEntry()
    //    {
    //        timer.Enabled = false;
    //        timer.Dispose();
    //        bWorker.Dispose();
    //    }

    //    void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    //    {
    //        timer.Enabled = false;

    //        ReloadStatus?.Invoke(status);
    //        ReloadPercent?.Invoke(100);

    //        if (Thread.CurrentThread.Name == "QuanLyBanHangDeleting")
    //            Thread.CurrentThread.Name = null;
    //    }

    //    void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    //    {
    //        if (!(bool)e.UserState)
    //            timer.Enabled = false;

    //        ReloadPercent?.Invoke(e.ProgressPercentage);
    //    }

    //    void bWorker_DoWork(object sender, DoWorkEventArgs e)
    //    {
    //        cur = 0;

    //        if (ListEntry != null)
    //            lenght = ListEntry.Count;
    //        if (ListEntity != null)
    //            ListEntity.ToList().ForEach(x => lenght += x.Value.Count);

    //        _accessEntry();
    //    }

    //    private bool _accessEntry()
    //    {
    //        if (ListEntry != null)
    //            status = _deleteEntryByID();
    //        if (ListEntity != null)
    //            status = _deleteEntryByT();
    //        return status;
    //    }

    //    private bool _deleteEntryByID()
    //    {
    //        try
    //        {
    //            foreach (int id in ListEntry)
    //            {
    //                T1 edt = db.Set<T1>().Find(id);
    //                DbEntityEntry entry = db.Entry<T1>(edt);
    //                if (entry != null && entry.State == EntityState.Unchanged)
    //                {
    //                    string propName = entry.CurrentValues.PropertyNames.FirstOrDefault(x => x.Equals("IsEnable") || x.Equals("IsEditable") || x.Equals("IsEnbale"));
    //                    if (!string.IsNullOrEmpty(propName))
    //                        entry.Property(propName).CurrentValue = false;
    //                }
    //                cur++;
    //            }
    //            db.SaveChangesAsync().Wait();
    //            return true;
    //        }
    //        catch { return false; }
    //    }

    //    private bool _deleteEntryByT()
    //    {
    //        try
    //        {
    //            foreach (var strVal in ListEntity)
    //            {
    //                foreach (int id in strVal.Value)
    //                {
    //                    DbEntityEntry entry = getDbEntityEntry(strVal.Key, id);
    //                    if (entry != null && entry.State == EntityState.Unchanged)
    //                    {
    //                        string propName = entry.CurrentValues.PropertyNames.FirstOrDefault(x => x.Equals("IsEnable") || x.Equals("IsEditable") || x.Equals("IsEnbale"));
    //                        if (!string.IsNullOrEmpty(propName))
    //                            entry.Property(propName).CurrentValue = false;
    //                    }
    //                    cur++;
    //                }
    //            }
    //            db.SaveChangesAsync().Wait();
    //            return true;
    //        }
    //        catch { return false; }
    //    }

    //    private DbEntityEntry getDbEntityEntry(string TName, int id)
    //    {
    //        DbEntityEntry entry = null;
    //        if (TName.Equals(typeof(T1).Name))
    //        {
    //            T1 edt = db.Set<T1>().Find(id);
    //            entry = db.Entry(edt);
    //        }
    //        if (TName.Equals(typeof(T2).Name))
    //        {
    //            T2 edt = db.Set<T2>().Find(id);
    //            entry = db.Entry(edt);
    //        }
    //        if (TName.Equals(typeof(T3).Name))
    //        {
    //            T3 edt = db.Set<T3>().Find(id);
    //            entry = db.Entry(edt);
    //        }
    //        return entry;
    //    }

    //    public DbSet getDbSet(string tableName)
    //    {
    //        Assembly asse = Assembly.Load("EntityModel");
    //        Module mod = asse.GetModules().FirstOrDefault(x => x.Name.Contains("EntityModel"));
    //        if (mod != null)
    //        {
    //            Type type = mod.Assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(tableName));
    //            if (type != null)
    //            {
    //                return db.Set(type);
    //            }
    //        }
    //        return null;
    //    }
    //}

    public partial class DeleteEntry_v2
    {
        System.Windows.Forms.Timer timer;
        public delegate void LoadStatus(bool _status);
        public delegate void LoadPecent(int _num);
        public LoadStatus ReloadStatus;
        public LoadPecent ReloadPercent;
        private readonly List<int> ListEntry;
        private BackgroundWorker bWorker;
        private bool status;
        private Dictionary<string, List<int>> ListEntity;
        private int lenght = 0;
        private int cur = 0;
        private int mode = 1;//1. Disable - 2.Remove
        aModel db;
        public DeleteEntry_v2(List<int> _ListEntry)
        {
            ListEntry = _ListEntry;
            _BackgroundWorker();
        }

        private void _BackgroundWorker()
        {
            bWorker = new BackgroundWorker();
            bWorker.WorkerReportsProgress = true;
            bWorker.WorkerSupportsCancellation = true;

            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            //if (Thread.CurrentThread.Name == null)
            //    Thread.CurrentThread.Name = "Deleting" + typeof(T1).Name;
        }

        public DeleteEntry_v2()
        {
            this.ListEntity = new Dictionary<string, List<int>>();
            _BackgroundWorker();
        }

        public void SetEntity(string Name, List<int> _lstEntry)
        {
            ListEntity.Add(Name, _lstEntry);
        }

        public void StartRun(int mode = 1)
        {
            db = new aModel();
            this.mode = mode;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = false;
            bWorker.RunWorkerAsync();
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (lenght > 0 && bWorker.IsBusy)
            {
                int curPercent = Convert.ToInt32(((cur * 1.0f) / lenght) * 100);
                bWorker.ReportProgress(curPercent, bWorker.IsBusy);
            }
        }

        ~DeleteEntry_v2()
        {
            timer.Enabled = false;
            timer.Dispose();
            bWorker.Dispose();
        }

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;

            ReloadStatus?.Invoke(status);
            ReloadPercent?.Invoke(100);

            //if (Thread.CurrentThread.Name == "QuanLyBanHangDeleting")
            //    Thread.CurrentThread.Name = null;
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
                timer.Enabled = false;

            ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            cur = 0;

            //if (ListEntry != null)
            //    lenght = ListEntry.Count;
            if (ListEntity != null)
                ListEntity.ToList().ForEach(x => lenght += x.Value.Count);

            _accessEntry();
        }

        private bool _accessEntry()
        {
            if (ListEntity != null)
            {
                switch (mode)
                {
                    case 1:
                        status = _disableEntry();
                        break;
                    case 2:
                        status = _removeEntry();
                        break;
                }
            }
            
            return status;
        }

        private bool _disableEntry()
        {
            try
            {
                DateTime time = DateTime.Now.ServerNow();
                foreach (var entity in ListEntity)
                {
                    DbSet dbSet = getDbSet(entity.Key);
                    if (dbSet == null)
                        return false;
                    foreach (int id in entity.Value)
                    {
                        object obj = dbSet.Find(id);
                        if (obj != null)
                        {
                            obj.GetType().GetProperties().Where(x => x.Name.Equals("IsEnable")).ToList().ForEach(x => x.SetValue(obj, false));
                            obj.GetType().GetProperties().Where(x => x.Name.Equals("ModifiedDate")).ToList().ForEach(x => x.SetValue(obj, time));
                        }
                        cur++;
                    }
                }
                db.SaveChangesAsync().Wait();
                return true;
            }
            catch { return false; }
        }

        private bool _removeEntry()
        {
            try
            {
                foreach (var entity in ListEntity)
                {
                    DbSet dbSet = getDbSet(entity.Key);
                    if (dbSet == null)
                        return false;
                    foreach (int id in entity.Value)
                    {
                        object obj = dbSet.Find(id);
                        if (obj != null)
                            dbSet.Remove(obj);
                        cur++;
                    }
                }
                db.SaveChangesAsync().Wait();
                return true;
            }
            catch { return false; }
        }

        public DbSet getDbSet(string tableName)
        {
            Assembly asse = Assembly.Load("EntityModel");
            Module mod = asse.GetModules().FirstOrDefault(x => x.Name.Contains("EntityModel"));
            if (mod != null)
            {
                Type type = mod.Assembly.GetTypes().FirstOrDefault(x => x.Name.Equals(tableName));
                if (type != null)
                    return db.Set(type);
            }
            return null;
        }
    }
}
