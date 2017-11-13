using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.BLL.Common;
using EntityModel.DataModel.HeThong;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPermission : clsFunction<xPermission>
    {
        #region Contructor
        protected clsPermission() { }
        public new static clsPermission Instance
        {
            get { return new clsPermission(); }
        }
        #endregion

        //public async Task<IList<xPermission>> SearchPermission(bool IsEnable, int KeyID)
        //{
        //    try
        //    {
        //        db = new aModel();
        //        return await db.Database.SqlQuery<xPermission>("sp_xPermission_SearchPermission {0},{1}", KeyID, IsEnable).ToListAsync();
        //    }
        //    catch { return new List<xPermission>(); }
        //}

        public async Task<IList<xPermission>> SearchPermission(bool IsEnable, int KeyID)
        {
            try
            {
                return await Task.Factory.StartNew(() => {
                    db = new aModel();
                    IEnumerable<xPermission> lstTemp = db.xPermission.Where(x => x.IsEnable == IsEnable || x.KeyID==KeyID);
                    return lstTemp.ToList();
                });
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
                    x.IDPermission = entry.KeyID;
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
