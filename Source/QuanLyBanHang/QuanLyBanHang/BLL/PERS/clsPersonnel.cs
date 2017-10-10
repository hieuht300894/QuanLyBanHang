using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPersonnel : clsBase<xPersonnel>
    {
        #region Constructor
        private static volatile clsPersonnel instance = null;
        private static readonly object mLock = new object();
        protected clsPersonnel() { }
        public new static clsPersonnel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsPersonnel();
                    }
                }
                return instance;
            }
        }
        #endregion

        public IList<xPersonnel> SearchNoAccount(bool IsEnable, int KeyID)
        {
            try
            {
                db = new aModel();
                IEnumerable<xPersonnel> lstTemp = db.ePersonnels.Where(x => (x.IsEnable && !x.IsAccount) || (x.KeyID == KeyID && x.IsAccount) && x.IDAgency == clsGeneral.curAgency.KeyID);
                return lstTemp.ToList();
            }
            catch
            {
                return new List<xPersonnel>();
            }
        }
    }
}
