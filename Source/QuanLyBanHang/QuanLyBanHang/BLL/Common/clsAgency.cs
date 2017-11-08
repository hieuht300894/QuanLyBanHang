using EntityModel.DataModel;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace QuanLyBanHang.BLL.Common
{
    public class clsAgency : clsFunction<xAgency>
    {
        #region Constructor
        private static volatile clsAgency instance = null;
        private static readonly object mLock = new object();
        protected clsAgency() { }
        public new static clsAgency Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsAgency();
                    }
                }
                return instance;
            }
        }
        #endregion

        public List<xAgency> GetAllAgency()
        {
            db = new aModel();
            List<xAgency> lstResult = db.xAgency.ToList<xAgency>();
            lstResult.Insert(0, new xAgency() { KeyID = 0, Name = "Not Selected", IsEnable = true });
            return lstResult;
        }

        public xAgency GetAgency(int keyID)
        {
            db = new aModel();
            return db.xAgency.FirstOrDefault(x => x.KeyID == keyID && x.IsEnable);
        }

        public bool accessEntry(xAgency aEntry)
        {
            try
            {
                _accessModel = new aModel();
                _accessModel.xAgency.AddOrUpdate(aEntry);
                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
