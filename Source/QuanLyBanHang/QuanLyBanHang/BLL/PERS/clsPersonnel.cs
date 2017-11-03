using DevExpress.Utils;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
            //db = new aModel();
            //IList<xPersonnel> lstResult = new List<xPersonnel>();
            //var qResult = db.Database.SqlQuery<xPersonnel>("select top 10000 * from xPersonnel", new SqlParameter[] { }).ToListAsync();
            //return await qResult;

            try
            {
                db = new aModel();
                var qResult = db.Database.SqlQuery<xPersonnel>("select top 100000 * from xPersonnel", new SqlParameter[] { });
                return await qResult.ToListAsync();
            }
            catch { return new List<xPersonnel>(); }
        }
    }
}
