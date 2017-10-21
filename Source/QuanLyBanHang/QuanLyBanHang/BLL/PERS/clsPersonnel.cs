using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsPersonnel : clsDelete<xPersonnel>
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
                repository.Context = new aModel();
                IEnumerable<xPersonnel> lstTemp = repository.Context.xPersonnel.Where(x => (x.IsEnable && !x.IsAccount) || (x.KeyID == KeyID && x.IsAccount) && x.IDAgency == clsGeneral.curAgency.KeyID);
                return lstTemp.ToList();
            }
            catch
            {
                return new List<xPersonnel>();
            }
        }

        public IList<xPersonnel> SearchPersonnel(bool IsEnable, int KeyID)
        {
            repository.Context = new aModel();
            IEnumerable<xPersonnel> lstTemp = repository.Context.xPersonnel.Where(x => x.IsEnable == IsEnable || x.KeyID == KeyID);
            return lstTemp.ToList();
        }
    }
}
