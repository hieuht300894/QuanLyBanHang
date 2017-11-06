﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;
using QuanLyBanHang.GUI.Common;
using QuanLyBanHang.BLL.Common;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using QuanLyBanHang.BLL.PERS;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    public class clsEntity
    {
        public static aModel db;
        public static List<xAppConfig> AllConfig = null;
        public static List<xDisplay> AllDisplay = null;
        public static List<xLayoutItemCaption> AllLayoutItemCaption = null;
        public static List<xMsgDictionary> AllMessage = null;

        public static void InitCollection()
        {
            db = db ?? new aModel();
            AllMessage = AllMessage ?? db.xMsgDictionary.ToList();
            AllConfig = AllConfig ?? db.xAppConfig.ToList();
            AllDisplay = AllDisplay ?? db.xDisplay.ToList();
            AllLayoutItemCaption = AllLayoutItemCaption ?? db.xLayoutItemCaption.ToList();
        }


        public static List<xAgency> GetAllAgency()
        {
            db = db ?? new aModel();
            List<xAgency> lstResult = db.xAgency.ToList<xAgency>();
            lstResult.Insert(0, new xAgency() { KeyID = 0, Name = "Not Selected", IsEnable = true });
            return lstResult;
        }

        public static void InitMasterAdmin()
        {
            clsGeneral.curAccount = new xAccount()
            {
                UserName = "Master",
                IDPermission = 0
            };
            clsGeneral.curUserFeature = new xUserFeature()
            {
                IDUserRole = 0,
                IsEnable = true,
                IsAdd = true,
                IsEdit = true,
                IsDelete = true,
                IsSave = true,
                IsPrintPreview = true,
                IsExportExcel = true
            };
            clsGeneral.curPersonnel = new xPersonnel()
            {
                Code = "Master",
                KeyID = 0,
                FullName = "Master",
                CreatedBy = 0,
                CreatedDate = DateTime.Now.ServerNow()
            };

            EntityModel.Module.CurPer = clsGeneral.curPersonnel;
            EntityModel.Module.CurAcc = clsGeneral.curAccount;
        }

        public static bool CheckUser_Login(string _UserName, string _Password, xPersonnel personnel, xAccount account)
        {
            try
            {
                db = new aModel();
                account = db.xAccount.FirstOrDefault(n => n.UserName.Equals(_UserName) && n.Password.Equals(_Password));
                if (account != null)
                {
                    personnel = db.xPersonnel.FirstOrDefault(x => x.KeyID == account.KeyID && x.IsEnable && x.IsAccount);

                    if (personnel != null)
                    {
                        clsGeneral.curAccount = account;
                        clsGeneral.curPersonnel = personnel;
                        clsGeneral.curUserFeature = new xUserFeature() { IsEnable = true };
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        public static string get_Caption(object ribbon, string iName, string pName, string iCaption, int Level)
        {
            try
            {
                xFeature f = db.xFeature.FirstOrDefault(n => n.KeyID.ToUpper().Equals(iName.ToUpper()) && n.IDGroup.Equals(pName.ToUpper()));
                if (f != null)
                {
                    if (!f.GetStringByName(Properties.Settings.Default.CurrentCulture).Equals(iCaption))
                    {
                        f.Level = Level;
                        f.VN = iCaption;
                        f.EN = iName.NoSign().Replace("_List", "").AutoSpace();
                        db.SaveChanges();
                    }
                    return f.GetStringByName(Properties.Settings.Default.CurrentCulture);
                }
                else
                {
                    if (ribbon is RibbonPage || ribbon is RibbonPageGroup || ribbon is BarButtonItemLink || ribbon is BarEditItemLink)
                    {
                        if ((ribbon is BarButtonItemLink || ribbon is BarEditItemLink) && iName.StartsWith("frm"))
                        {
                            f = new xFeature() { KeyID = iName, IDGroup = pName, IsEnable = true };
                            f.VN = iCaption;
                            f.EN = iName.NoSign().Replace("_List", "").AutoSpace();
                            f.Level = Level;
                            db.xFeature.Add(f);
                            db.SaveChanges();
                            return Properties.Settings.Default.CurrentCulture.Equals("VN") ? f.VN : f.EN;
                        }
                        else if (ribbon is RibbonPage || ribbon is RibbonPageGroup)
                        {
                            f = new xFeature() { KeyID = iName, IDGroup = pName, IsEnable = true };
                            f.VN = iCaption;
                            f.EN = iName.NoSign().Replace("_List", "").AutoSpace();
                            f.Level = Level;
                            db.xFeature.Add(f);
                            db.SaveChanges();
                            return Properties.Settings.Default.CurrentCulture.Equals("VN") ? f.VN : f.EN;
                        }
                        else
                        {
                            return Properties.Settings.Default.CurrentCulture.Equals("VN") ? iCaption : iName.NoSign().AutoSpace();
                        }
                    }
                    else
                    {
                        return Properties.Settings.Default.CurrentCulture.Equals("VN") ? iCaption : iName.NoSign().AutoSpace();
                    }
                }

            }
            catch { return Properties.Settings.Default.CurrentCulture.Equals("VN") ? iCaption : iName.NoSign().AutoSpace(); }
        }

        public async static Task<bool> Check_Role(xAccount _iAccount, string cName)
        {
            db = db ?? new aModel();
            if (_iAccount.KeyID == 0)
                return true;
            else if (_iAccount.IDPermission == 0)
                return false;
            else
            {
                xPermission permission = await clsPermission.Instance.GetByID<xPermission>(_iAccount.IDPermission) ?? new xPermission();
                List<xUserFeature> lstRoles = new List<xUserFeature>(clsUserRole.Instance.GetUserFeature(permission.KeyID));
                return lstRoles.Any(n => n.IsEnable && n.IDFeature.Contains(cName));
            }
        }

        public static void UpdateFeatures()
        {
            clsFeature.Instance.UpdateFeaturesCount();
        }
    }

    public static class exEntity
    {
        public static DateTime ServerNow(this DateTime Now)
        {
            DateTime dRe = DateTime.MinValue;
            using (aModel db = new aModel())
            {
                var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
                dRe = dateQuery.AsEnumerable().First();
            }
            return dRe;
        }
    }
}
