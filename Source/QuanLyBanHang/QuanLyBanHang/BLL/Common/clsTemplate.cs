using EntityModel.DataModel;
using QuanLyBanHang.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.Common
{
    public class clsTemplate<T> where T : class, new()
    {
        public readonly Repository<T> repository;
        public readonly RepositoryCollection collection;

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
        public virtual IList<T> GetAll()
        {
            try
            {
                repository.Context = new aModel();
                IEnumerable<T> lstTemp = repository.Context.Set<T>().AsEnumerable();
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
                repository.Context.Set<T>().Add(entry);
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
                repository.Context.Entry(entry).State = EntityState.Modified;
                repository.Context.SaveChanges();
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
