using System.Collections.Generic;
using System.Linq;
using EntityModel.DataModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System;

namespace QuanLyBanHang.BLL.PERS
{ 
    public class clsPersonnel
    {
        #region Variables
        private aModel db, _accessModel;
        #endregion

        #region Constructor
        private static volatile clsPersonnel instance = null;
        private static readonly object mLock = new Object();
        public static clsPersonnel Instance
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

        protected clsPersonnel() { }
        #endregion

        #region Functions
        public List<xPersonnel> getAllPersonnel()
        {
            db = new aModel();
            IEnumerable<xPersonnel> lstTemp = db.ePersonnels.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID);

            List<xPersonnel> lstResult = lstTemp.ToList<xPersonnel>();
            return lstResult;
        }

        public List<xPersonnel> searchPersonnel(bool IsEnable)
        {
            db = new aModel();
            IEnumerable<xPersonnel> lstTemp = db.ePersonnels.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID);

            List<xPersonnel> lstResult = lstTemp.ToList<xPersonnel>();
            return lstResult;
        }

        public bool checkExist(string Ma, int KeyID)
        {
            bool bRe = false;
            using (aModel db = new aModel())
            {
                if (KeyID > 0)
                    bRe = db.ePersonnels.Any(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.KeyID != KeyID && n.Code.ToUpper().Equals(Ma.ToUpper()));
                else
                    bRe = db.ePersonnels.Any(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.Code.ToUpper().Equals(Ma.ToUpper()));
            }
            return bRe;
        }

        public xPersonnel getEntry(int KeyID)
        {
            try
            {
                _accessModel = new aModel();
               
                if (KeyID == 0) return new xPersonnel() { IsEnable = true };
                var eRe = _accessModel.ePersonnels.FirstOrDefault<xPersonnel>(n => n.KeyID == KeyID);
                return eRe != null ? eRe : new xPersonnel() { IsEnable = true };
            }
            catch
            {
                return new xPersonnel() { IsEnable = true };
            }
        }

        public bool accessEntry(xPersonnel _acEntry)
        {
            bool bRe = false;
            try
            {
                _accessModel = _accessModel ?? new aModel();
                _accessModel.ePersonnels.AddOrUpdate<xPersonnel>(_acEntry);
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { bRe = false; }
            return bRe;
        }

        public bool deleteEntry(int KeyID)
        {
            bool bRe = false;
            try
            {
                _accessModel = _accessModel ?? new aModel();
                _accessModel.ePersonnels.Find(KeyID).IsEnable = false;
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { }
            return bRe;
        }
        #endregion
    }
}
