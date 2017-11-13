using System.Collections.Generic;
using System.Linq;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.BLL.Common;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsUserRole : clsFunction<xUserFeature>
    {
        #region Constructor
        private static volatile clsUserRole instance = null;
        private static readonly object mLock = new object();
        protected clsUserRole() { }
        public new static clsUserRole Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsUserRole();
                    }
                }
                return instance;
            }
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
