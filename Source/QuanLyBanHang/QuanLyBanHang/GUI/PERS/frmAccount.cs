using EntityModel.DataModel;
using EntityModel.DataModel.HeThong;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.PERS;
using QuanLyBanHang.GUI.Common;
using QuanLyBanHang.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmAccount : frmBase
    {
        #region Variables
        public xAccount _iEntry;
        xAccount _aEntry;
        #endregion

        #region Form Events
        public frmAccount()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadDataForm();
            CustomForm();
        }
        private void lokPersonnel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmPersonnel _frm = new frmPersonnel())
                {
                    _frm.Text = "Thêm mới nhân viên";
                    _frm.fType = eFormType.Add;
                    _frm._ReloadData = this.LoadPersonnel;
                    _frm.ShowDialog();
                }
            }
        }
        private void lokPermission_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmPermission _frm = new frmPermission())
                {
                    _frm.Text = "Thêm mới quyền";
                    _frm.fType = eFormType.Add;
                    _frm._ReloadData = this.LoadPermission;
                    _frm.ShowDialog();
                }
            }
        }

        #region Show/Hide Password
        private void btePassword_Properties_MouseDown(object sender, MouseEventArgs e)
        {
            btePassword.Properties.UseSystemPasswordChar = false;
        }
        private void btePassword_Properties_MouseUp(object sender, MouseEventArgs e)
        {
            btePassword.Properties.UseSystemPasswordChar = true;
        }
        #endregion
        #endregion

        #region Methods
        public override void CustomForm()
        {
            lokPermission.Properties.ValueMember = "KeyID";
            lokPermission.Properties.DisplayMember = "Name";
            lokPersonnel.Properties.ValueMember = "KeyID";
            lokPersonnel.Properties.DisplayMember = "FullName";

            base.CustomForm();

            txtUserName.NotUnicode(true, false);
            btePassword.Properties.MouseDown += btePassword_Properties_MouseDown;
            btePassword.Properties.MouseUp += btePassword_Properties_MouseUp;
            lokPersonnel.Properties.ButtonClick += lokPersonnel_ButtonClick;
            lokPermission.Properties.ButtonClick += lokPermission_ButtonClick;
        }
        public override async void LoadDataForm()
        {
            _iEntry = _iEntry ?? new xAccount() { IsEnable = true };
            _aEntry = await clsAccount.Instance.GetByID(_iEntry.KeyID);

            LoadPersonnel(_aEntry.KeyID);
            LoadPermission(_aEntry.IDPermission);
            SetControlValue();
        }
        private async void LoadPersonnel(object KeyID)
        {
            IList<xPersonnel> lstResult = await clsPersonnel.Instance.SeachPersonnelNoAccount((int)KeyID);
            await RunMethodAsync(() =>
            {
                lokPersonnel.Properties.DataSource = lstResult;
                if ((int)KeyID > 0) lokPersonnel.EditValue = KeyID;
                else lokPersonnel.ItemIndex = 0;
            });
        }
        private async void LoadPermission(object KeyID)
        {
            IList<xPermission> lstResult = await clsPermission.Instance.SearchPermission(true, (int)KeyID);
            await RunMethodAsync(() =>
            {
                lokPermission.Properties.DataSource = lstResult;
                if ((int)KeyID > 0)
                    lokPermission.EditValue = KeyID;
            });
        }
        public override void SetControlValue()
        {
            lokPersonnel.DataBindings.Add("EditValue", _aEntry, "KeyID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            txtUserName.DataBindings.Add("EditValue", _aEntry, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            btePassword.DataBindings.Add("EditValue", _aEntry, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);
            lokPermission.DataBindings.Add("EditValue", _aEntry, "IDPermission", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged);

            if (_aEntry.KeyID == 0)
            {
                lokPersonnel.Properties.Buttons[1].Visible = true;
                lokPersonnel.Enabled = true;
                txtUserName.Enabled = true;
                lokPersonnel.Select();
            }
            else
            {
                lokPersonnel.Properties.Buttons[1].Visible = false;
                lokPersonnel.Enabled = false;
                txtUserName.Enabled = false;
                btePassword.Select();
            }

            _aEntry.Password = clsGeneral.Decrypt(_aEntry.Password);
        }
        public override void RenewData()
        {
            _iEntry = _aEntry = null;
        }
        public override bool ValidationForm()
        {
            bool bRe = true;
            lokPersonnel.ErrorText = string.Empty;
            txtUserName.ErrorText = string.Empty;
            btePassword.ErrorText = string.Empty;
            lokPermission.ErrorText = string.Empty;

            string setFocusControl = "";

            if (lokPermission.ToInt32() == 0)
            {
                lokPermission.ErrorText = "Phân quyền không hợp lệ";
                bRe = false; setFocusControl = lokPermission.Name;
            }

            if (string.IsNullOrEmpty(btePassword.Text.Trim()))
            {
                btePassword.ErrorText = "Mật khẩu không hợp lệ";
                bRe = false; setFocusControl = btePassword.Name;
            }

            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                txtUserName.ErrorText = "Tên đăng nhập không hợp lệ";
                bRe = false; setFocusControl = txtUserName.Name;
            }
            //else if (clsAccount.Instance.checkExist(txtUserName.Text.Trim(), fType == eFormType.Add ? 0 : _acEntry.IDPersonnel))
            //{
            //    txtUserName.ErrorText = "Tên đăng nhập đã tồn tại";
            //    bRe = false; setFocusControl = txtUserName.Name;
            //}

            if (lokPersonnel.ToInt32() == 0)
            {
                lokPersonnel.ErrorText = "Nhân viên không hợp lệ";
                bRe = false; setFocusControl = lokPersonnel.Name;
            }

            if (!string.IsNullOrEmpty(setFocusControl))
            {
                this.Controls.Find(setFocusControl, true).First().Select();
            }
            return bRe;
        }
        public override async Task<bool> SaveData()
        {
            _aEntry.Password = clsGeneral.Encrypt(btePassword.Text);
            _aEntry.PermissionName = lokPermission.Text;

            if (fType == eFormType.Add)
            {
                _aEntry.IsEnable = true;
                _aEntry.PersonelName = lokPersonnel.Text;
                _aEntry.UserName = txtUserName.Text.Trim();
                _aEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _aEntry.CreatedDate = DateTime.Now.ServerNow();
            }
            else
            {
                _aEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _aEntry.ModifiedDate = DateTime.Now.ServerNow();
            }

            bool bRe = false;
            bRe = await clsAccount.Instance.AddOrUpdate(_aEntry);
            return bRe;
        }
        #endregion
    }
}