using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsUserRole : clsFunction<xUserFeature>
    {
        #region Contructor
        protected clsUserRole() { }
        public new static clsUserRole Instance
        {
            get { return new clsUserRole(); }
        }
        #endregion

        #region Functions
        public xUserFeature GetUserFeature(string IDFeature)
        {
            db = new aModel();
            xUserFeature uf = new xUserFeature();
            if (clsGeneral.curAccount.IDPermission > 0)
                uf = db.xUserFeature.FirstOrDefault(x => x.IDPermission == clsGeneral.curAccount.IDPermission && x.IDFeature.Equals(IDFeature) && x.IsEnable);

            return uf ?? new xUserFeature();
        }

        public List<xUserFeature> GetUserFeature(int IDPermission)
        {
            db = new aModel();
            IEnumerable<xUserFeature> lstTemp = db.xUserFeature.Where(x => x.IDPermission == IDPermission && x.IsEnable);
            return lstTemp.ToList();
        }

        public async Task<IList<xUserFeature>> SearchUserFeature(int IDPermission)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                 {
                     db = new aModel();
                     IEnumerable<xUserFeature> lstTemp = db.xUserFeature.Where(x => x.IDPermission == IDPermission && x.IsEnable);
                     return lstTemp.ToList();
                 });
            }
            catch { return new List<xUserFeature>(); }
        }
        #endregion
    }
}
