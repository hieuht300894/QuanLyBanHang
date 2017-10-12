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
    public class clsPermission : clsTemplate<xPermission>
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
                lstUserFeatures.ForEach(x =>
                {
                    if (x.KeyID == 0)
                        repository.Context.xUserFeature.Add(x);
                    else if (x.IsEnable)
                        repository.Context.xUserFeature.AddOrUpdate(x);
                    else
                        repository.Context.xUserFeature.Remove(x);
                });
                repository.Context.SaveChanges();
                repository.Commit();
                return true;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi cập nhật mới: {typeof(xPermission).Name}");
                return false;
            }
        }
    }
}
