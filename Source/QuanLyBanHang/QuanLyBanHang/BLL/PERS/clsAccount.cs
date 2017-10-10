using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.BLL.Common;

namespace QuanLyBanHang.BLL.PERS
{
    public class clsAccount : clsTemplate<xAccount>
    {
        #region Constructor
        private static volatile clsAccount instance = null;
        private static readonly object mLock = new object();
        protected clsAccount() { }
        public new static clsAccount Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsAccount();
                    }
                }
                return instance;
            }
        }
        #endregion

        //#region Variables
        //private aModel db, _accessModel;
        //#endregion

        //#region Constructor
        //private static volatile clsAccount instance = null;
        //private static readonly object mLock = new Object();
        //public static clsAccount Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            lock (mLock)
        //            {
        //                if (instance == null)
        //                    instance = new clsAccount();
        //            }
        //        }
        //        return instance;
        //    }
        //}

        //protected clsAccount() { }
        //#endregion

        //#region Functions
        //public List<xPersonnel> getAllPersonnel()
        //{
        //    db = new aModel();
        //    IEnumerable<xPersonnel> lstTemp = db.ePersonnels.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID);

        //    List<xPersonnel> lstResult = lstTemp.ToList<xPersonnel>();
        //    return lstResult;
        //}

        //public List<xPersonnel> getPersonnel(int KeyID)
        //{
        //    db = new aModel();
        //    IEnumerable<xPersonnel> lstTemp = db.ePersonnels.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID);
        //    if (KeyID > 0)
        //        lstTemp = lstTemp.Where(n => (n.IsEnable && n.eAccount == null) || n.KeyID == KeyID);
        //    else
        //        lstTemp = lstTemp.Where(n => n.IsEnable && n.eAccount == null);

        //    List<xPersonnel> lstResult = lstTemp.ToList<xPersonnel>();
        //    return lstResult;
        //}

        //public List<xPermission> getUserRole(int KeyID)
        //{
        //    db = new aModel();
        //    IEnumerable<xPermission> lstTemp = db.xPermissions;
        //    if (KeyID > 0)
        //        lstTemp = lstTemp.Where(n => n.IsEnable || n.KeyID == KeyID);
        //    else
        //        lstTemp = lstTemp.Where(n => n.IsEnable);

        //    List<xPermission> lstResult = lstTemp.ToList<xPermission>();
        //    return lstResult;
        //}

        //public List<xAccount> searchAccount(bool IsEnable)
        //{
        //    db = new aModel();
        //    IEnumerable<xAccount> lstTemp = db.eAccounts.Where(n => n.IsEnable == IsEnable);

        //    List<xAccount> lstResult = lstTemp.ToList<xAccount>();
        //    return lstResult;
        //}

        //public bool checkExist(string UserName, int KeyID)
        //{
        //    bool bRe = false;
        //    using (aModel db = new aModel())
        //    {
        //        if (KeyID > 0)
        //            bRe = db.eAccounts.Any(n => n.IsEnable && n.UserName.ToLower().Equals(UserName.ToLower()) && n.IDPersonnel != KeyID);
        //        else
        //            bRe = db.eAccounts.Any(n => n.IsEnable && n.UserName.ToLower().Equals(UserName.ToLower()));
        //    }
        //    return bRe;
        //}

        //public xAccount getEntry(int KeyID)
        //{
        //    try
        //    {
        //        _accessModel = new aModel();
        //        if (KeyID == 0) return new xAccount() { IsEnable = true };
        //        var eRe = _accessModel.eAccounts.FirstOrDefault<xAccount>(n => n.IDPersonnel == KeyID);
        //        return eRe != null ? eRe : new xAccount() { IsEnable = true };
        //    }
        //    catch
        //    {
        //        return new xAccount() { IsEnable = true };
        //    }
        //}

        //public bool accessEntry(xAccount _acEntry)
        //{
        //    bool bRe = false;
        //    try
        //    {
        //        _accessModel = _accessModel ?? new aModel();
        //        _accessModel.eAccounts.AddOrUpdate<xAccount>(_acEntry);
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
        //        _accessModel.eAccounts.Find(KeyID).IsEnable = false;
        //        _accessModel.SaveChanges();
        //        bRe = true;
        //    }
        //    catch { }
        //    return bRe;
        //}
        //#endregion

        public  IList<xAccount> SearchAccount(bool IsEnable, int KeyID)
        {
            repository.Context = new aModel();
            IEnumerable<xAccount> lstTemp = repository.Context.xAccount.Where(n => n.IsEnable == IsEnable || n.IDPersonnel == KeyID);
            List<xAccount> lstResult = lstTemp.ToList();
            return lstResult;
        }

        //public override bool InsertEntry(xAccount entry)
        //{
        //    try
        //    {
        //        _accessModel = _accessModel ?? new aModel();
        //        _accessModel.Set<xAccount>().Add(entry);
        //        _accessModel.ePersonnels.Find(entry.IDPersonnel).IsAccount = true;
        //        _accessModel.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsGeneral.showErrorException(ex, "Lỗi thêm mới");
        //        return false;
        //    }
        //}

        public override bool InsertEntry(xAccount entry)
        {
            try
            {
                repository.Context = new aModel();
                repository.Insert(entry);
                repository.Context.xPersonnel.Find(entry.IDPersonnel).IsAccount = true;
                repository.Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                clsGeneral.showErrorException(ex, "Lỗi thêm mới");
                return false;
            }
        }
    }
}
