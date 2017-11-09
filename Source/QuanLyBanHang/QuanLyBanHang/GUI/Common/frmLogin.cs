using QuanLyBanHang.MultiLanguage;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace QuanLyBanHang.GUI.Common
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        Bitmap vnFlag, enFlag;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            vnFlag = new Bitmap(Properties.Resources.VNFlag);
            enFlag = new Bitmap(Properties.Resources.UKFlag);

            lcMain.AllowCustomization = false;

            lcMain.BestFitFormHeight();
            txtUserName.Text = Properties.Settings.Default.username;
            txtPassword.Text = Properties.Settings.Default.password;
            if (Properties.Settings.Default.CurrentCulture.Equals("EN"))
                setENCulture();
            else
                setVNCulture();

            if (!string.IsNullOrEmpty(txtUserName.Text.Trim()))
                chkSavePassword.Checked = true;
            else
                chkSavePassword.Checked = false;
        }

        bool ValidateForm()
        {
            bool err = true;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
               // txtUserName.ErrorText = IncorrectUsername;
                err = false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                //txtPassword.ErrorText = IncorrectPassword;
                err = false;
            }
            return err;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (ValidateForm())
            //{
            //    var chkUser = clsEntity.CheckUser_Login(txtUserName.Text, clsGeneral.Encrypt(txtPassword.Text), clsGeneral.curPersonnel, clsGeneral.curAccount);
            //    if (chkUser)
            //    {
            //        Properties.Settings.Default.CurrentCulture = "VN";
            //        Properties.Settings.Default.Save();
            //        Properties.Settings.Default.Reload();
            //        if (chkSavePassword.Checked)
            //        {
            //            Properties.Settings.Default.isSaveUserAndPassword = true;
            //            Properties.Settings.Default.username = txtUserName.Text;
            //            Properties.Settings.Default.password = txtPassword.Text;
            //            Properties.Settings.Default.Save();
            //        }
            //        else
            //        {
            //            Properties.Settings.Default.isSaveUserAndPassword = false;
            //            Properties.Settings.Default.username = "";
            //            Properties.Settings.Default.password = "";
            //            Properties.Settings.Default.Save();
            //        }
            //        Properties.Settings.Default.Reload();
            //        EntityModel.Module.CurPer = clsGeneral.curPersonnel;
            //        EntityModel.Module.CurAcc= clsGeneral.curAccount;
            //        DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        lblMessage.Text = LoginFailed;
            //        txtUserName.Focus();
            //    }
            //}
            //else
            //    return;

            clsEntity.InitMasterAdmin();
            DialogResult = DialogResult.OK;
        }

        private void pteIcon_Click(object sender, EventArgs e)
        {
            //frmSetting _frmsetting = new frmSetting();
            //_frmsetting.ShowDialog();
            frmBackupDatabase frm = new frmBackupDatabase();
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void setVNCulture()
        {
            //this.Text = "Đăng nhập";
            //pteLanguage.Image = vnFlag;
            //IncorrectUsername = "Tên đăng nhập không hợp lệ";
            //IncorrectPassword = "Mật khẩu không hợp lệ";
            //LoginFailed = "Đăng nhập không thành công!";
            //lciUserName.Text = "Tên đăng nhập:";
            //lciPassword.Text = "Mật khẩu:";
            //chkSavePassword.Text = "Nhớ tài khoản và mật khẩu";
            //btnLogin.Text = "Đăng nhập";
            //btnCancel.Text = "Hủy";
        }

        private void setENCulture()
        {
            //this.Text = "Login";
            //pteLanguage.Image = enFlag;
            //IncorrectUsername = "User name incorrect";
            //IncorrectPassword = "Password is incorrect";
            //LoginFailed = "Login failed!";
            //lciUserName.Text = "User name:";
           // lciPassword.Text = "Password:";
            //chkSavePassword.Text = "Remember password";
            //btnLogin.Text = "Login";
            //btnCancel.Text = "Cancel";
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == (Keys.Alt | Keys.F10))
            //{
            //    clsEntity.InitMasterAdmin();
            //    DialogResult = DialogResult.OK;
            //}
            //else if (e.KeyData == Keys.Enter)
            //    btnLogin.PerformClick();
        }
    }
}