using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPersonnel : clsFunction
    {
        #region Contructor
        public new static clsPersonnel Instance
        {
            get { return new clsPersonnel(); }
        }
        #endregion

        public async Task<IList<xPersonnel>> GetAllPersonnel()
        {
            try
            {
                db = new aModel();
                var qResult = db.Database.SqlQuery<xPersonnel>("sp_xPersonnel_GetAllPersonnel", new SqlParameter[] { });
                return await qResult.ToListAsync();
            }
            catch { return new List<xPersonnel>(); }
        }

        public async Task<IList<xPersonnel>> SearchPersonnel(bool IsEnable = true)
        {
            try
            {
                db = new aModel();
                var qResult = db.Database.SqlQuery<xPersonnel>("sp_xPersonnel_SeachPersonnel {0}", IsEnable);
                return await qResult.ToListAsync();
            }
            catch { return new List<xPersonnel>(); }
        }

        public async Task<IList<xPersonnel>> SeachPersonnelNoAccount(int KeyID)
        {
            try
            {
                db = new aModel();
                var result = db.Database.SqlQuery<xPersonnel>("sp_xPersonnel_SeachPersonnelNoAccount {0}", KeyID);
                return await result.ToListAsync();
            }
            catch { return new List<xPersonnel>(); }
        }
    }
}
