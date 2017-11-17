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
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(Properties.Settings.Default.SkinName);
            DevExpress.Utils.AppearanceObject.DefaultFont = Properties.Settings.Default.FontFormat;
            Application.Run(new GUI.Common.frmMain());
        }
    }
}
