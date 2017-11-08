using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.PERS;
using QuanLyBanHang.Service;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmAccount : frmBase, IFormAccess
    {
        #region Variables
        public delegate void LoadData(int KeyID);
        public LoadData ReLoadParent;

        public xAccount iEntry;
        xAccount _acEntry;
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
                    _frm.Text = "Thêm mới nhân viên".Translation("ftxtAddPersonnel", _frm.Name);
                    _frm.fType = eFormType.Add;
                    _frm.ReLoadParent = this.LoadPersonnel;
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
                    _frm.ReloadData = this.LoadPermission;
                    _frm.ShowDialog();
                }
            }
        }

        #region Show/Hide Password
        private void txtPassword_Properties_MouseHover(object sender, EventArgs e)
        {
            btePassword.Properties.UseSystemPasswordChar = false;
        }
        private void txtPassword_Properties_MouseLeave(object sender, EventArgs e)
        {
            btePassword.Properties.UseSystemPasswordChar = true;
        }

        #endregion
        #endregion

        #region Base Button Event
        protected override void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataForm();
        }

        protected async override void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
                if (await SaveData())
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgSaveFailed", this.Name));
        }

        protected async override void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
                if (await SaveData())
                {
                    fType = eFormType.Add;
                    this.Text = "Thêm mới tài khoản".Translation("ftxtAddAccount", this.Name);
                    iEntry = _acEntry = new xAccount() { IsEnable = true };
                    SetControlValue();
                }
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgSaveFailed", this.Name));
        }
        #endregion

        #region Methods
        protected override void CustomForm()
        {
            lokPermission.Properties.ValueMember = "KeyID";
            lokPermission.Properties.DisplayMember = "Name";
            lokPersonnel.Properties.ValueMember = "KeyID";
            lokPersonnel.Properties.DisplayMember = "FullName";

            base.CustomForm();

            txtUserName.NotUnicode(true, false);
            txtUserName.MouseHover += txtPassword_Properties_MouseHover;
            txtUserName.MouseLeave += txtPassword_Properties_MouseLeave;
            lokPersonnel.Properties.ButtonClick += lokPersonnel_ButtonClick;
            lokPermission.Properties.ButtonClick += lokPermission_ButtonClick;
        }
        public async void LoadDataForm()
        {
            iEntry = iEntry ?? new xAccount() { IsEnable = true };
            _acEntry = await clsAccount.Instance.GetByID<xAccount>(iEntry.KeyID);
            await RunMethodAsync(() => { SetControlValue(); });
        }
        private async void LoadPersonnel(int KeyID)
        {
            lokPersonnel.Properties.DataSource = await clsPersonnel.Instance.SeachPersonnelNoAccount(KeyID);

            if (KeyID > 0)
                lokPersonnel.EditValue = KeyID;
            else
                lokPersonnel.ItemIndex = 0;
        }
        private async void LoadPermission(int KeyID)
        {
            lokPermission.Properties.DataSource = await clsPermission.Instance.SearchPermission(true, KeyID);
            if (KeyID > 0)
                lokPermission.EditValue = KeyID;
        }
        public void SetControlValue()
        {
            if (fType == eFormType.Add)
            {
                lokPersonnel.Properties.Buttons[1].Visible = false;
                lokPersonnel.ReadOnly = txtUserName.ReadOnly = false;
                lokPersonnel.Select();
            }
            else
            {
                lokPersonnel.ReadOnly = txtUserName.ReadOnly = true;
                btePassword.Select();
            }

            //lctAccount.BesFitFormHeight();
            this.CenterToScreen();

            LoadPersonnel(_acEntry.KeyID);
            txtUserName.Text = _acEntry.UserName;
            btePassword.Text = clsGeneral.Decrypt(_acEntry.Password);
            LoadPermission(_acEntry.IDPermission);
        }
        public bool ValidationForm()
        {
            bool bRe = true;
            lokPersonnel.ErrorText = string.Empty;
            txtUserName.ErrorText = string.Empty;
            btePassword.ErrorText = string.Empty;
            lokPermission.ErrorText = string.Empty;

            string setFocusControl = "";

            if (lokPermission.ToInt32() == 0)
            {
                lokPermission.ErrorText = "Phân quyền không hợp lệ".Translation("msgUserRoleIncorrect", this.Name);
                bRe = false; setFocusControl = lokPermission.Name;
            }

            if (string.IsNullOrEmpty(btePassword.Text.Trim()))
            {
                btePassword.ErrorText = "Mật khẩu không hợp lệ".Translation("msgPasswordIsEmpty", this.Name);
                bRe = false; setFocusControl = btePassword.Name;
            }

            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                txtUserName.ErrorText = "Tên đăng nhập không hợp lệ".Translation("msgUsernameIsEmpty", this.Name);
                bRe = false; setFocusControl = txtUserName.Name;
            }
            //else if (clsAccount.Instance.checkExist(txtUserName.Text.Trim(), fType == eFormType.Add ? 0 : _acEntry.IDPersonnel))
            //{
            //    txtUserName.ErrorText = "Tên đăng nhập đã tồn tại".Translation("msgDuplicateUsername", this.Name);
            //    bRe = false; setFocusControl = txtUserName.Name;
            //}

            if (lokPersonnel.ToInt32() == 0)
            {
                lokPersonnel.ErrorText = "Nhân viên không hợp lệ".Translation("msgPersonnelIsEmpty", this.Name);
                bRe = false; setFocusControl = lokPersonnel.Name;
            }

            if (!string.IsNullOrEmpty(setFocusControl))
            {
                this.Controls.Find(setFocusControl, true).First().Select();
            }
            return bRe;
        }
        public async Task<bool> SaveData()
        {
            return await Task.Factory.StartNew(() =>
                {
                    bool bRe = false;

                    _acEntry.Password = clsGeneral.Encrypt(btePassword.Text);
                    _acEntry.IDPermission = lokPermission.ToInt32();
                    _acEntry.PermissionName = lokPermission.Text;

                    if (fType == eFormType.Add)
                    {
                        _acEntry.IsEnable = true;
                        _acEntry.KeyID = lokPersonnel.ToInt32();
                        _acEntry.PersonelName = lokPersonnel.Text;
                        _acEntry.UserName = txtUserName.Text.Trim().ToLower();
                        _acEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                        _acEntry.CreatedDate = DateTime.Now.ServerNow();
                    }
                    else
                    {
                        _acEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                        _acEntry.ModifiedDate = DateTime.Now.ServerNow();
                    }

                    bRe = clsAccount.Instance.AddOrUpdate(_acEntry);

                    if (bRe && ReLoadParent != null)
                        ReLoadParent(_acEntry.KeyID);

                    return bRe;
                });
        }
        public void ResetData()
        {
        }
        #endregion
    }
}