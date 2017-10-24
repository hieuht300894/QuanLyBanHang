using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using QuanLyBanHang.DAL;

namespace QuanLyBanHang.BLL.Common
{
    public class clsAgency:clsTemplate<xAgency>
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

        aModel db, accessModel;
        public List<xAgency> GetAllAgency()
        {
            accessModel = new aModel();
            List<xAgency> lstResult = accessModel.xAgency.ToList<xAgency>();
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
                accessModel = accessModel ?? new aModel();
                accessModel.xAgency.AddOrUpdate(aEntry);
                accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
