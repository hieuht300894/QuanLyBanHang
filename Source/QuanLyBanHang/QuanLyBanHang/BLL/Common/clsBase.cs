using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.Common
{
    public class clsBase<T> where T : class, new()
    {
        #region Constructor
        private static volatile clsBase<T> instance = null;
        private static readonly object mLock = new object();
        protected clsBase() { }
        public static clsBase<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsBase<T>();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Function
        public aModel _accessModel, db;

        private DbSet getDbSet(string tableName)
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

        public virtual IList<T> GetAll()
        {
            try
            {
                db = new aModel();
                IEnumerable<T> lstTemp = db.Set<T>().Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID);
                return lstTemp.ToList();
            }
            catch
            {
                return new List<T>();
            }
        }

        public virtual IList<T> Search(bool IsEnable)
        {
            try
            {
                db = new aModel();
                IEnumerable<T> lstTemp = db.Set<T>().AsEnumerable().Where(x => x.GetBooleanByName("IsEnable") == IsEnable);
                return lstTemp.ToList();
            }
            catch
            {
                return new List<T>();
            }
        }

        public virtual IList<T> Search(int IDAgency, bool IsEnable)
        {
            try
            {
                db = new aModel();
                IEnumerable<T> lstTemp = db.Set<T>().
                    Where(x =>
                            x.GetInt32ByName("IDAgency") == IDAgency &&
                              x.GetBooleanByName("IsEnable") == IsEnable);
                return lstTemp.ToList();
            }
            catch
            {
                return new List<T>();
            }
        }

        public virtual T GetEntry(int KeyID)
        {
            try
            {
                _accessModel = new aModel();
                T entry = _accessModel.Set<T>().Find(KeyID);
                return entry ?? new T();
            }
            catch { return new T(); }
        }

        public virtual bool AddEntry(T entry)
        {
            try
            {
                _accessModel = _accessModel ?? new aModel();
                _accessModel.Set<T>().Add(entry);
                _accessModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Lỗi thêm mới");
                return false;
            }
        }

        public virtual bool UpdateEntry(T entry)
        {
            try
            {
                _accessModel = _accessModel ?? new aModel();
                _accessModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Lỗi cập nhật");
                return false;
            }
        }
        #endregion
    }
}
