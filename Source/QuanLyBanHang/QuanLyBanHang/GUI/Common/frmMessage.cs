using System;

namespace QuanLyBanHang.GUI.Common
{
    public partial class frmMessage : DevExpress.XtraEditors.XtraForm
    {
        public frmMessage()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.CurrentCulture.Equals("VN"))
            {
                this.Text = "Infomation";
                btnOK.Text = "Comfirm";
            }
        }
    }
}