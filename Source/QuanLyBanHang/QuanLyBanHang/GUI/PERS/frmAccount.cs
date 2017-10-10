using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.PERS;
using System;
using System.Linq;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmAccount : frmBase
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

            loadDataForm();
            customForm();
        }
        private void lokPersonnel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                using (frmPersonnel _frm = new frmPersonnel())
                {
                    _frm.Text = "Thêm mới nhân viên".Translation("ftxtAddPersonnel", _frm.Name);
                    _frm.fType = eFormType.Add;
                    _frm.ReLoadParent = this.loadPersonnel;
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
                    _frm.ReloadData = this.loadPermission;
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
            loadDataForm();
        }

        protected override void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validationForm())
                if (saveData())
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgSaveFailed", this.Name));
        }

        protected override void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validationForm())
                if (saveData())
                {
                    fType = eFormType.Add;
                    this.Text = "Thêm mới tài khoản".Translation("ftxtAddAccount", this.Name);
                    iEntry = _acEntry = new xAccount() { IsEnable = true };
                    setControlValue();
                }
                else
                    clsGeneral.showMessage("Lưu dữ liệu không thành công.\r\nVui lòng kiểm tra lại".Translation("msgSaveFailed", this.Name));
        }
        #endregion

        #region Methods
        private void customForm()
        {
            txtUserName.NotUnicode(true, false);
            lokPersonnel.Format();
            lokPermission.Format();
            lctAccount.BestFitText();

            txtUserName.MouseHover += txtPassword_Properties_MouseHover;
            txtUserName.MouseLeave += txtPassword_Properties_MouseLeave;
            lokPersonnel.Properties.ButtonClick += lokPersonnel_ButtonClick;
            lokPermission.Properties.ButtonClick += lokPermission_ButtonClick;
        }
        private void loadDataForm()
        {
            iEntry = iEntry ?? new xAccount() { IsEnable = true };
            _acEntry = clsAccount.Instance.GetEntry(iEntry.IDPersonnel);
            setControlValue();
        }
        private void loadPersonnel(int KeyID)
        {
            lokPersonnel.Properties.DataSource = clsPersonnel.Instance.SearchNoAccount(true, KeyID);
            lokPersonnel.Properties.ValueMember = "KeyID";
            lokPersonnel.Properties.DisplayMember = "FullName";
            if (KeyID > 0)
                lokPersonnel.EditValue = KeyID;
            else
                lokPersonnel.ItemIndex = 0;
        }
        private void loadPermission(int KeyID)
        {
            lokPermission.Properties.DataSource = clsPermission.Instance.SearchPermission(true, KeyID);
            lokPermission.Properties.ValueMember = "KeyID";
            lokPermission.Properties.DisplayMember = "Name";
            if (KeyID > 0)
                lokPermission.EditValue = KeyID;
        }
        private void setControlValue()
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

            loadPersonnel(_acEntry.IDPersonnel);
            txtUserName.Text = _acEntry.UserName;
            btePassword.Text = clsGeneral.Decrypt(_acEntry.Password);
            loadPermission(_acEntry.IDPermission.HasValue ? _acEntry.IDPermission.Value : 0);
        }
        private bool validationForm()
        {
            bool bRe = true;
            lokPersonnel.ErrorText = string.Empty;
            txtUserName.ErrorText = string.Empty;
            btePassword.ErrorText = string.Empty;
            lokPermission.ErrorText = string.Empty;

            string setFocusControl = "";

            if (lokPermission.ToInt() == 0)
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

            if (lokPersonnel.ToInt() == 0)
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
        private bool saveData()
        {
            bool bRe = false;

            _acEntry.Password = clsGeneral.Encrypt(btePassword.Text);
            _acEntry.IDPermission = lokPermission.ToInt();
            _acEntry.PermissionName = lokPermission.Text;

            if (fType == eFormType.Add)
            {
                _acEntry.IsEnable = true;
                _acEntry.IDPersonnel = lokPersonnel.ToInt();
                _acEntry.PersonelName = lokPersonnel.Text;
                _acEntry.UserName = txtUserName.Text.Trim().ToLower();
                _acEntry.IDAgency = clsGeneral.curPersonnel.IDAgency;
                _acEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
            }
            else
            {
                _acEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
            }

            bRe = _acEntry.xPersonnel == null ? clsAccount.Instance.InsertEntry(_acEntry) : clsAccount.Instance.UpdateEntry(_acEntry);

            if (bRe && ReLoadParent != null)
                ReLoadParent(_acEntry.IDPersonnel);

            return bRe;
        }
        #endregion
    }
}