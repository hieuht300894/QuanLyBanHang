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
    public class clsPermission : clsFunction<xPermission>
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

        public async Task<IList<xPermission>> SearchPermission(bool IsEnable, int KeyID)
        {
            try
            {
                db = new aModel();
                return await db.Database.SqlQuery<xPermission>("sp_xPermission_SearchPermission {0},{1}", KeyID, IsEnable).ToListAsync();
            }
            catch { return new List<xPermission>(); }
        }

        public async Task<bool> AddOrUpdate(xPermission entry, List<xUserFeature> lstUserFeatures)
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.xPermission.AddOrUpdate(entry);
                await db.SaveChangesAsync();

                lstUserFeatures.ForEach(x =>
                {
                    x.IDUserRole = entry.KeyID;
                    db.xUserFeature.AddOrUpdate(x);
                });

                await db.SaveChangesAsync();
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
