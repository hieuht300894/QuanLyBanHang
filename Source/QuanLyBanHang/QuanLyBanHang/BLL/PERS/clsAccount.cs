using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsAccount : clsFunction<xAccount>
    {
        #region Constructor
        private static volatile clsAccount instance = null;
        private static readonly object mLock = new object();
        protected clsAccount() { }
        public new static clsAccount Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsAccount();
                    }
                }
                return instance;
            }
        }
        #endregion

        public IList<xAccount> SearchAccount(bool IsEnable, int KeyID)
        {
            db = new aModel();
            IEnumerable<xAccount> lstTemp = db.xAccount.Where(n => n.IsEnable == IsEnable || n.KeyID == KeyID);
            List<xAccount> lstResult = lstTemp.ToList();
            return lstResult;
        }

        public async override Task<bool> AddOrUpdate(xAccount entry)
        {
            db = new aModel();
            var tran = db.Database.BeginTransaction();
            try
            {
                db.xAccount.AddOrUpdate(entry);
                db.xPersonnel.Find(entry.KeyID).IsAccount = true;
                await db.SaveChangesAsync();
                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                clsGeneral.showErrorException(ex, "Lỗi thêm mới");
                return false;
            }
        }
    }
}
