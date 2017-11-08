using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BLL.PERS
{
    class clsFeature : clsFunction<xFeature>
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
            db = new aModel();
            IEnumerable<xFeature> lstTemp = db.xFeature.Where(x => x.IsEnable == IsEnable);

            return lstTemp.ToList();
        }

        public void UpdateFeaturesCount()
        {
            try
            {
                db = new aModel();
                IEnumerable<xFeature> lstTemp = db.xFeature.Where(x => x.IsEnable);
                List<xFeature> list = lstTemp.ToList();
                list.ForEach(x => x.ItemCount = 0);
                List<xFeature> lstParents = new List<xFeature>(list.Where(x => x.Level == 0));
                foreach (xFeature f in lstParents)
                {
                    DuyetCay(list, f);
                }
                list.ForEach(x => db.xFeature.AddOrUpdate(x));
                db.SaveChanges();
            }
            catch { }
        }

        void DuyetCay(List<xFeature> list, xFeature fParent)
        {
            List<xFeature> lstChilds = new List<xFeature>(list.Where(x => x.Level > fParent.Level && x.IDGroup.Equals(fParent.KeyID)));
            foreach (xFeature f in lstChilds)
            {
                fParent.ItemCount++;
                DuyetCay(list, f);
            }
        }
    }
}
