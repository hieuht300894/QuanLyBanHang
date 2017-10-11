using EntityModel.DataModel;
using QuanLyBanHang.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
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

        #region Function
        public virtual List<T> GetAll()
        {
            try
            {
                repository.Context = new aModel();
                IEnumerable<T> lstTemp = repository.GetAll();
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
                repository.Insert(entry);
                repository.Context.SaveChanges();
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
                repository.Context = new aModel();
                repository.Update(entry);
                repository.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Lỗi cập nhật");
                return false;
            }
        }

        public virtual bool DeleteEntry(T entry)
        {
            try
            {
                repository.Context = new aModel();
                repository.Delete(entry);
                repository.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Lỗi xóa");
                return false;
            }
        }
        #endregion
    }
}
