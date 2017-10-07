using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmError : DevExpress.XtraEditors.XtraForm
    {
        public frmError()
        {
            InitializeComponent();
        }

        private void frmError_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.CurrentCulture.Equals("VN"))
            {
                this.Name = "Error";
                btnContinue.Text = "Continue";
                btnRestart.Text = "Restart";
                btnOK.Text = "Exit";
            }
            this.CenterToScreen();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void llbDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.Size.Height < 200)
            {
                this.MaximumSize = new Size(this.Width, this.Height * 2);
                this.Size = this.MaximumSize;
                llbDetail.Text = Properties.Settings.Default.CurrentCulture.Equals("VN") ? "Ẩn chi tiết >>" : "Hide Detail >>";
                this.CenterToScreen();
            }
            else
            {
                this.MaximumSize = new Size(this.Width, this.Height / 2);
                this.Size = this.MaximumSize;
                llbDetail.Text = Properties.Settings.Default.CurrentCulture.Equals("VN") ? "Hiện chi tiết >>" : "Show Detail >>";
                this.CenterToScreen();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}