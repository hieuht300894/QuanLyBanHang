using System;
using System.Linq;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;

namespace QuanLyBanHang
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        #region Variables

        #endregion

        #region Form Events
        public frmChangePassword()
        {
            InitializeComponent();
        }
        private void frmDoiMK_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Text = clsGeneral.curAccount.UserName;
            }
            catch { this.Close(); }
            customForm();
        }
        #endregion

        #region Button Events

        #region Show/Hide Password
        private void bteOldPassword_MouseHover(object sender, EventArgs e)
        {
            bteOldPassword.Properties.UseSystemPasswordChar = false;
        }

        private void bteOldPassword_MouseLeave(object sender, EventArgs e)
        {
            bteOldPassword.Properties.UseSystemPasswordChar = true;
        }

        private void bteNewPassword_MouseHover(object sender, EventArgs e)
        {
            bteNewPassword.Properties.UseSystemPasswordChar = false;
        }

        private void bteNewPassword_MouseLeave(object sender, EventArgs e)
        {
            bteNewPassword.Properties.UseSystemPasswordChar = true;
        }

        private void bteConfirmPassword_MouseHover(object sender, EventArgs e)
        {
            bteConfirmPassword.Properties.UseSystemPasswordChar = false;
        }

        private void bteConfirmPassword_MouseLeave(object sender, EventArgs e)
        {
            bteConfirmPassword.Properties.UseSystemPasswordChar = true;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                try
                {
                    clsGeneral.curAccount.Password = clsGeneral.Encrypt(bteNewPassword.Text.Trim());
                    using (aModel db = new aModel())
                    {
                        db.xAccount.AddOrUpdate(clsGeneral.curAccount);
                        db.SaveChanges();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    clsGeneral.showErrorException(ex, "Exception");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Methods
        private void customForm()
        {
            bteOldPassword.Select();
            lctDoiMatKhau.BestFitFormHeight();
            lctDoiMatKhau.Format();
            this.CenterToScreen();
        }

        private bool validateForm()
        {
            bool bRe = true;
            string setFocusControl = "";
            if (string.IsNullOrEmpty(bteConfirmPassword.Text.Trim()) || (!string.IsNullOrEmpty(bteNewPassword.Text.Trim()) && !bteConfirmPassword.Text.Trim().Equals(bteNewPassword.Text.Trim())))
            {
                bteConfirmPassword.ErrorText = "Xác thực mật khẩu không hợp lệ";
                bRe = false; setFocusControl = bteConfirmPassword.Name;
            }

            if (string.IsNullOrEmpty(bteNewPassword.Text.Trim()))
            {
                bteNewPassword.ErrorText = "Mật khẩu mới không hợp lệ";
                bRe = false; setFocusControl = bteNewPassword.Name;
            }

            if (string.IsNullOrEmpty(bteOldPassword.Text.Trim()))
            {
                bteOldPassword.ErrorText = "Mật khẩu cũ không hợp lệ";
                bRe = false; setFocusControl = bteOldPassword.Name;
            }
            else if (!clsGeneral.Encrypt(bteOldPassword.Text.Trim()).Equals(clsGeneral.curAccount.Password))
            {
                bteOldPassword.ErrorText = "Mật khẩu cũ không hợp lệ";
                bRe = false; setFocusControl = bteOldPassword.Name;
            }
            if(bRe && bteOldPassword.Text.Trim().Equals(bteNewPassword.Text.Trim()))
            {
                bteNewPassword.ErrorText = "Mật khẩu mới không hợp lệ";
                bRe = false; setFocusControl = bteNewPassword.Name;
            }
            else if(bRe && bteNewPassword.Text.Length < 6)
            {
                bteConfirmPassword.ErrorText = bteNewPassword.ErrorText = "Mật khẩu quá ngắn";
                bRe = false; setFocusControl = bteNewPassword.Name;
            }
            if (!string.IsNullOrEmpty(setFocusControl))
                this.Controls.Find(setFocusControl, true).First().Select();

            return bRe;
        }
        #endregion
    }
}