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

        //#region Constructor
        //private static volatile clsTemplate<T> instance = null;
        //private static readonly object mLock = new object();
        //public clsTemplate()
        //{
        //    collection = new RepositoryCollection();
        //    repository = collection.GetRepo<T>();
        //}
        //public static clsTemplate<T> Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            lock (mLock)
        //            {
        //                if (instance == null)
        //                    instance = new clsTemplate<T>();
        //            }
        //        }
        //        return instance;
        //    }
        //}
        //~clsTemplate()
        //{
        //    instance = null;
        //}
        //#endregion

        #region Constructor
        public clsTemplate()
        {
            collection = new RepositoryCollection();
            repository = collection.GetRepo<T>();
        }
        public static clsTemplate<T> Instance
        {
            get { return new clsTemplate<T>(); }
        }
        ~clsTemplate() { }
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
    }
}
