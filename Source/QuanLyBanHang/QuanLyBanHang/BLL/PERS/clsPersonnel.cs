using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPersonnel : clsFunction<xPersonnel>
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
                return await Task.Factory.StartNew(() =>
                {
                    db = new aModel();
                    IEnumerable<xPersonnel> lstTemp = db.xPersonnel.ToList();
                    return lstTemp.ToList();
                });
            }
            catch { return new List<xPersonnel>(); }
        }

        public async Task<IList<xPersonnel>> SearchPersonnel(bool IsEnable = true)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    db = new aModel();
                    IEnumerable<xPersonnel> lstTemp = db.xPersonnel.Where(x => x.IsEnable == IsEnable);
                    return lstTemp.ToList();
                });
            }
            catch { return new List<xPersonnel>(); }
        }

        public async Task<IList<xPersonnel>> SeachPersonnelNoAccount(int KeyID)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    db = new aModel();
                    IEnumerable<xPersonnel> lstTemp = db.xPersonnel.Where(x => (x.IsEnable == true && !x.IsAccount) || x.KeyID == KeyID);
                    return lstTemp.ToList();
                });
            }
            catch { return new List<xPersonnel>(); }
        }
    }
}
