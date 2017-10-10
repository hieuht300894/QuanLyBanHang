using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    class clsFeature : clsTemplate<xFeature>
    {
        #region Constructor
        private static volatile clsFeature instance = null;
        private static readonly object mLock = new object();
        protected clsFeature() { }
        public new static clsFeature Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsFeature();
                    }
                }
                return instance;
            }
        }
        #endregion

        public IList<xFeature> SearchFeature(bool IsEnable)
        {
            repository.Context = new aModel();
            IEnumerable<xFeature> lstTemp = repository.Context.xFeature.Where(x => x.IsEnable == IsEnable);
            return lstTemp.ToList();
        }
    }
}
