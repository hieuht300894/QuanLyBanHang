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
    public class clsPermission : clsFunction
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
            db = new aModel();
            IEnumerable<xPermission> lstTemp = db.xPermission.Where(x => x.IsEnable == IsEnable || x.KeyID == KeyID);
            return lstTemp.ToList();
        }

        public bool InsertEntry(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.xPermission.AddOrUpdate(entry);
                db.SaveChanges();

                lstUserFeatures.ForEach(x =>
                {
                    x.IDUserRole = entry.KeyID;
                    db.xUserFeature.Add(x);
                });

                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi thêm mới: {typeof(xPermission).Name}");
                return false;
            }
        }

        public bool UpdateEntry(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.xPermission.AddOrUpdate(entry);
                lstUserFeatures.ForEach(x => { db.xUserFeature.AddOrUpdate(x); });
                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi cập nhật: {typeof(xPermission).Name}");
                return false;
            }
        }

        public bool AddOrUpdate(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.xPermission.AddOrUpdate(entry);
                db.SaveChanges();

                lstUserFeatures.ForEach(x =>
                {
                    x.IDUserRole = entry.KeyID;
                    db.xUserFeature.AddOrUpdate(x);
                });

                db.SaveChanges();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, $"Lỗi AddOrUpdate: {typeof(xPermission).Name}");
                return false;
            }
        }
    }
}
