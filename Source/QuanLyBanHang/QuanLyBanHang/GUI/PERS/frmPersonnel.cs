using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPersonnel : frmBase
    {
        #region Variables
        public xPersonnel _iEntry;
        xPersonnel _aEntry;
        #endregion

        #region Form Events
        public frmPersonnel()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadDataForm();
            CustomForm();
        }
        #endregion

        #region Methods
        public override async void LoadDataForm()
        {
            _iEntry = _iEntry ?? new xPersonnel() { IsEnable = true };
            _aEntry = await clsPersonnel.Instance.GetByID(_iEntry.KeyID);
            SetControlValue();
        }
        public override void SetControlValue()
        {
            txtCode.DataBindings.Add("EditValue", _aEntry, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("EditValue", _aEntry, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPhone.DataBindings.Add("EditValue", _aEntry, "Phone", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAddress.DataBindings.Add("EditValue", _aEntry, "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("EditValue", _aEntry, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeDescription.DataBindings.Add("EditValue", _aEntry, "Description", true, DataSourceUpdateMode.OnPropertyChanged);

            if (_aEntry.KeyID == 0)
            {
                txtCode.TabStop = true;
                txtCode.ReadOnly = false;
                txtCode.Select();
            }
            else
            {
                txtCode.TabStop = false;
                txtCode.ReadOnly = true;
                txtFullName.Select();
            }
        }
        public override bool ValidationForm()
        {
            bool bRe = true;
            txtCode.ErrorText = string.Empty;
            txtFullName.ErrorText = string.Empty;
            txtPhone.ErrorText = string.Empty;
            txtAddress.ErrorText = string.Empty;
            txtEmail.ErrorText = string.Empty;

            string setFocusControl = "";

            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()) && !clsGeneral.CheckEmail(txtEmail.Text.Trim()))
            {
                txtEmail.ErrorText = "Email không hợp lệ";
                bRe = false; setFocusControl = txtEmail.Name;
            }

            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                txtFullName.ErrorText = "Vui lòng nhập tên nhân viên";
                bRe = false; setFocusControl = txtFullName.Name;
            }

            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                txtCode.ErrorText = "Vui lòng nhập mã nhân viên";
                bRe = false; setFocusControl = txtCode.Name;
            }
            //else if (clsPersonnel.Instance.checkExist(txtCode.Text, _acEntry.KeyID))
            //{
            //    txtCode.ErrorText = "Mã nhân viên đã tồn tại.".Translation("msgDuplicatedCode", this.Name);
            //    bRe = false; setFocusControl = txtCode.Name;
            //}

            if (!string.IsNullOrEmpty(setFocusControl))
            {
                this.Controls.Find(setFocusControl, true).First().Select();
            }
            return bRe;
        }
        public override async Task<bool> SaveData()
        {
            if (_aEntry.KeyID == 0)
            {
                _aEntry.IsEnable = true;
                _aEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _aEntry.CreatedDate = DateTime.Now.ServerNow();
            }
            else
            {
                _aEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _aEntry.ModifiedDate = DateTime.Now.ServerNow();
            }

            bool bRe = false;
            bRe = await clsPersonnel.Instance.AddOrUpdate(_aEntry);
            return bRe;
        }
        public override void RenewData()
        {
            _iEntry = _aEntry = null;
        }
        public override void CustomForm()
        {
            txtCode.NotUnicode(true, true);
            txtFullName.IsPersonName();
            txtPhone.PhoneOnly();
            base.CustomForm();
        }
        #endregion
    }
}