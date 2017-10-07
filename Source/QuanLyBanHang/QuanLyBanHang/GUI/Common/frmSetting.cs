using DevExpress.XtraReports.UI;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmSetting : DevExpress.XtraEditors.XtraForm
    {
        DialogResult dRe = DialogResult.Cancel;
        string _sqlName, _sqlUser, _sqlPass;
        bool _wAu;

        public frmSetting()
        {
            InitializeComponent();
        }

        #region Form Events
        private void frmSetting_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            //Load giá trị mặc định cho các field
            txtComputerName.Text = Environment.MachineName;
            txtMayChuFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp);
            txtTenFPT.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_user);
            txtPassFTP.EditValue = clsGeneral.Decrypt(Properties.Settings.Default.ftp_pw);

            txtSQLServerName.Text = clsGeneral.Decrypt(Properties.Settings.Default.sServerName);
            tsbSQLAuthentication.IsOn = !Properties.Settings.Default.sWinAu;
            txtSQLUserName.Text = clsGeneral.Decrypt(Properties.Settings.Default.sUserName);
            txtSQLPassword.Text = clsGeneral.Decrypt(Properties.Settings.Default.sPassword);
            cbbDatabase.Enabled = false;
            this.KeyPreview = true;

            loadPrinter();
            //lokPrinter.Format(false);
        }

        //Sự kiện click btnKiemTra
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            _sqlName = txtSQLServerName.Text;
            _sqlUser = txtSQLUserName.Text;
            _sqlPass = txtSQLPassword.Text;
            _wAu = !tsbSQLAuthentication.IsOn;
            if (checkConnection(_sqlName, _wAu, _sqlUser, _sqlPass))
            {
                cbbDatabase.Properties.Items.Clear();
                cbbDatabase.Properties.Items.AddRange(lstDatabase);
                cbbDatabase.Enabled = true;
                btnLuu.Enabled = true;
                cbbDatabase.EditValue = "QuanLyBanHang";
            }
            else
            {
                cbbDatabase.Properties.Items.Clear();
                cbbDatabase.Enabled = false;
            }
        }

        //Xử lý sự kiện btnLuu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ComputerName = txtComputerName.Text;
            Properties.Settings.Default.sServerName = clsGeneral.Encrypt(_sqlName);
            Properties.Settings.Default.sWinAu = !tsbSQLAuthentication.IsOn;
            Properties.Settings.Default.sDBName = clsGeneral.Encrypt(cbbDatabase.Text);
            Properties.Settings.Default.sUserName = clsGeneral.Encrypt(_sqlUser);
            Properties.Settings.Default.sPassword = clsGeneral.Encrypt(_sqlPass);

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            dRe = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSetting_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode.Equals(Keys.S))
                {
                    btnLuu_Click(null, null);
                }
                else if (e.KeyCode.Equals(Keys.H))
                {
                    btnHuy_Click(null, null);
                }
                else if (e.KeyCode.Equals(Keys.E))
                {
                    btnKiemTra_Click(null, null);
                }
            }
        }

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = dRe;
        }

        private void tsbXacThuc_Toggled(object sender, EventArgs e)
        {
            if (tsbSQLAuthentication.IsOn)
            {
                lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lciUserName.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                lciPassword.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        #endregion

        #region Methods
        List<string> lstDatabase;

        private void loadPrinter()
        {
            List<string> lstPrinter = new List<string>();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                lstPrinter.Add(printer);
            }
            lokPrinter.Properties.DataSource = lstPrinter.ToArray();
            lokPrinter.EditValue = Properties.Settings.Default.PrinterName;
        }
        private void printData()
        {
            //PayDebitInfo pay = new PayDebitInfo();
            //DateTime dt = DateTime.Now.ServerNow();
            //pay.DatePaid = "Ngày " + dt.Day + " tháng " + dt.Month + " năm " + dt.Year;
            //eCustomer customer = new eCustomer();
            //if (customer != null)
            //{
            //    pay.Name = customer.Name;
            //    pay.Address = customer.Address;
            //    pay.Contact = customer.Contact;
            //}
            ////pay.Money = lstTotal.Sum(x => x.Pay);
            //pay.MoneyString = clsFormatControl.ToMoneyText(pay.Money);
            //rptPhieuThanhToan rpt = new rptPhieuThanhToan();
            //List<PayDebitInfo> lstOrder = new List<PayDebitInfo>();
            //lstOrder.Add(pay);
            //rpt.DataSource = lstOrder;
            //rpt.Parameters["_Name"].Value = clsGeneral.curAgency.Name;
            //rpt.Parameters["_Address"].Value = clsGeneral.curAgency.Address;
            //rpt.Parameters["_Phone"].Value = clsGeneral.curAgency.Phone;
            //rpt.Parameters["_Mail"].Value = clsGeneral.curAgency.Email;

            //ReportPrintTool report = new ReportPrintTool(rpt);
            //report.PrinterSettings.PrinterName = lokPrinter.Text.Trim();
            //report.PrinterSettings.DefaultPageSettings.Landscape = rpt.Landscape;
            //report.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize(rpt.PaperKind.ToString(), rpt.PageWidth, rpt.PageHeight);

            //try
            //{
            //    if (report.PrinterSettings.IsValid)
            //    {
            //        report.Print();
            //        Properties.Settings.Default.PrinterName = lokPrinter.Text.Trim();
            //        Properties.Settings.Default.Save();
            //    }
            //}
            //catch { }
        }

        public bool checkConnection(string ServerName, bool winAu, string UserName, string Password)
        {
            bool bRe = false;
            if (string.IsNullOrEmpty(ServerName)) return false;
            System.Data.SqlClient.SqlConnectionStringBuilder conB = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                DataSource = ServerName,
                UserID = UserName,
                Password = Password,
                IntegratedSecurity = winAu,
                ConnectTimeout = 10

            };

            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(conB.ConnectionString))
            {
                try
                {
                    con.Open();
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT name from sys.databases", con))
                    {
                        lstDatabase = new List<string>();
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lstDatabase.Add(dr[0].ToString());
                            }
                        }
                    }
                    bRe = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return bRe;
            }
        }
        #endregion

        private void btnCheck_Click(object sender, EventArgs e)
        {
            printData();
        }

        private void cbbDatabase_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbbDatabase.Text))
                btnLuu.Enabled = false;
            else
                btnLuu.Enabled = true;
        }
    }
}
