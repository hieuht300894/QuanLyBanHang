using EntityModel.DataModel;
using EntityModel.DataModel.HeThong;
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
        #region Contructor
        protected clsFeature() { }
        public new static clsFeature Instance
        {
            get { return new clsFeature(); }
        }
        #endregion

        public async Task<IList<xFeature>> SearchFeature(bool IsEnable)
        {
            try
            {
                return await Task.Factory.StartNew(() =>
                {
                    db = new aModel();
                    IEnumerable<xFeature> lstTemp = db.xFeature.Where(x => x.IsEnable == IsEnable);
                    return lstTemp.ToList();
                });
            }
            catch { return new List<xFeature>(); }
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
