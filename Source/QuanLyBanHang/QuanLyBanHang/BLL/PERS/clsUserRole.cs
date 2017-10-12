using System.Collections.Generic;
using System.Linq;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.BLL.Common;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsUserRole : clsTemplate<xUserFeature>
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

        //public List<xPersonnel> getAllPersonnel()
        //{
        //    db = new aModel();
        //    IEnumerable<xPersonnel> lstTemp = db.ePersonnels;
        //    return lstTemp.ToList<xPersonnel>();
        //}

        //public List<xFeature> getAllFeature()
        //{
        //    db = new aModel();
        //    IEnumerable<xFeature> lstTemp = db.xFeatures;
        //    return lstTemp.ToList<xFeature>();
        //}

        //public IList<xPermission> searchUserRole(bool IsEnable)
        //{
        //    db = new aModel();
        //    IEnumerable<xPermission> lstTemp = db.xPermissions.Where(n => n.IsEnable == IsEnable);

        //    IList<xPermission> lstResult = lstTemp.ToList<xPermission>();
        //    return lstResult;
        //}

        //public xPermission getEntry(int KeyID)
        //{
        //    try
        //    {
        //        _accessModel = new aModel();
        //        if (KeyID == 0) return new xPermission() { IsEnable = true };
        //        var eRe = _accessModel.xPermissions.FirstOrDefault<xPermission>(n => n.KeyID == KeyID);
        //        return eRe != null ? eRe : new xPermission() { IsEnable = true };
        //    }
        //    catch
        //    {
        //        return new xPermission() { IsEnable = true };
        //    }
        //}

        //public bool accessEntry(xPermission _acEntry)
        //{
        //    bool bRe = false;
        //    try
        //    {
        //        _accessModel = _accessModel ?? new aModel();
        //        _accessModel.xPermissions.AddOrUpdate<xPermission>(_acEntry);
        //        _accessModel.xUserFeatures.RemoveRange(_accessModel.xUserFeatures.Where(delegate (xUserFeature ix)
        //            {
        //                return (ix.IDUserRole == _acEntry.KeyID && !_acEntry.xUserFeatures.Any(n => n.IDFeature == ix.IDFeature));
        //            }));
        //        _accessModel.SaveChanges();
        //        bRe = true;
        //    }
        //    catch { bRe = false; }
        //    return bRe;
        //}

        //public bool deleteEntry(int KeyID)
        //{
        //    bool bRe = false;
        //    try
        //    {
        //        _accessModel = _accessModel ?? new aModel();
        //        _accessModel.xPermissions.Find(KeyID).IsEnable = false;
        //        _accessModel.SaveChanges();
        //        bRe = true;
        //    }
        //    catch { }
        //    return bRe;
        //}

        //public xFeature getFeature(string KeyID)
        //{
        //    db = new aModel();
        //    return db.xFeatures.Find(KeyID) ?? new xFeature();
        //}

        //public List<xFeature> getChildFeature(string KeyID)
        //{
        //    db = new aModel();
        //    IEnumerable<xFeature> lstTemp = db.xFeatures.Where(x => x.IDGroup.Equals(KeyID));
        //    return lstTemp.ToList();
        //}

        public xUserFeature getUserFeature(string IDFeature)
        {
            repository.Context = new aModel();
            xUserFeature uf = new xUserFeature();
            if (clsGeneral.curAccount.IDPermission>0)
                uf = repository.Context.xUserFeature.FirstOrDefault(x => x.IDUserRole == clsGeneral.curAccount.IDPermission && x.IDFeature.Equals(IDFeature) && x.IsEnable);

            return uf ?? new xUserFeature();
        }

        public List<xUserFeature> getUserFeature(int IDPermission)
        {
            repository.Context = new aModel();
            IEnumerable<xUserFeature> lstTemp = repository.Context.xUserFeature.Where(x => x.IDUserRole == IDPermission && x.IsEnable);
            return lstTemp.ToList();
        }
        #endregion
    }
}
