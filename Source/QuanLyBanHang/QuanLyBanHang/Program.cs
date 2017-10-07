using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2010 Silver");
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Tahoma", 9F);
            //clsMain ls = new clsMain();
            //if (ls.Start("WHSOFT", @"http://license.phanmemtintan.com:8000/ssposservice.asmx"))
            Application.Run(new GUI.Common.frmMain());
        }
    }
}
