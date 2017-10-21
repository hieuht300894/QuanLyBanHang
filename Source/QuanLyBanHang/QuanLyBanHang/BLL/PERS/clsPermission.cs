using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.BLL.Common;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPermission : clsDelete<xPermission>
    {
        #region Constructor
        private static volatile clsPermission instance = null;
        private static readonly object mLock = new object();
        protected clsPermission() { }
        public new static clsPermission Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsPermission();
                    }
                }
                return instance;
            }
        }
        #endregion

        public IList<xPermission> SearchPermission(bool IsEnable, int KeyID)
        {
            repository.Context = new aModel();
            IEnumerable<xPermission> lstTemp = repository.Context.xPermission.Where(x => x.IsEnable == IsEnable || x.KeyID == KeyID);
            return lstTemp.ToList();
        }

        public bool InsertEntry(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();

                repository.Context.xPermission.AddOrUpdate(entry);
                repository.Context.SaveChanges();

                lstUserFeatures.ForEach(x =>
                {
                    x.IDUserRole = entry.KeyID;
                    repository.Context.xUserFeature.Add(x);
                });

                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi thêm mới: {typeof(xPermission).Name}");
                return false;
            }
        }

        public bool UpdateEntry(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();
                repository.Context.xPermission.AddOrUpdate(entry);
                lstUserFeatures.ForEach(x => { repository.Context.xUserFeature.AddOrUpdate(x); });
                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi cập nhật: {typeof(xPermission).Name}");
                return false;
            }
        }

        public  bool AddOrUpdate(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            try
            {
                repository.Context = new aModel();
                repository.BeginTransaction();

                repository.Context.xPermission.AddOrUpdate(entry);
                repository.Context.SaveChanges();

                lstUserFeatures.ForEach(x =>
                {
                    x.IDUserRole = entry.KeyID;
                    repository.Context.xUserFeature.AddOrUpdate(x);
                });

                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi AddOrUpdate: {typeof(xPermission).Name}");
                return false;
            }
        }
    }
}
