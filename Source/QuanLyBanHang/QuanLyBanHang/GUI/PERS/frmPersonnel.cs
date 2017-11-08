﻿using System;
using System.Linq;
using System.Windows.Forms;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.PERS;
using QuanLyBanHang.Service;
using System.Threading.Tasks;

namespace QuanLyBanHang.GUI.PER
{
    public partial class frmPersonnel : frmBase, IFormAccess
    {
        #region Variables
        public delegate void LoadData(int strKey);
        public LoadData ReLoadParent;

        public xPersonnel iEntry;
        xPersonnel _acEntry;
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

        #region Base Button Event
        protected override void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataForm();
        }

        protected async override void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
                await SaveData();
            base.btnSave_ItemClick(sender, e);
        }

        protected async override void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ValidationForm())
                await SaveData();
        }
        #endregion

        #region Methods
        public async void LoadDataForm()
        {
            iEntry = iEntry ?? new xPersonnel() { IsEnable = true };
            _acEntry = await clsPersonnel.Instance.GetByID(iEntry.KeyID);
            await RunMethodAsync(() => { SetControlValue(); });
        }

        public void SetControlValue()
        {
            txtCode.DataBindings.Add("EditValue", _acEntry, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
            txtFullName.DataBindings.Add("EditValue", _acEntry, "FullName", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPhone.DataBindings.Add("EditValue", _acEntry, "Phone", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAddress.DataBindings.Add("EditValue", _acEntry, "Address", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("EditValue", _acEntry, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeDescription.DataBindings.Add("EditValue", _acEntry, "Description", true, DataSourceUpdateMode.OnPropertyChanged);


            //txtCode.EditValue = _acEntry.Code;
            //txtFullName.Text = _acEntry.FullName;
            //txtPhone.Text = _acEntry.Phone;
            //txtAddress.Text = _acEntry.Address;
            //txtEmail.Text = _acEntry.Email;
            //mmeDescription.Text = _acEntry.Description;

            if (_acEntry.KeyID == 0)
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

        public bool ValidationForm()
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
                txtEmail.ErrorText = "Email không hợp lệ".Translation("msgIncorrectEmail", this.Name);
                bRe = false; setFocusControl = txtEmail.Name;
            }

            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                txtFullName.ErrorText = "Vui lòng nhập tên nhân viên".Translation("msgNameIsEmpty", this.Name);
                bRe = false; setFocusControl = txtFullName.Name;
            }

            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                txtCode.ErrorText = "Vui lòng nhập mã nhân viên".Translation("msgCodeIsEmpty", this.Name);
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

        public async Task<bool> SaveData()
        {
            bool bRe = false;

            //_acEntry.FullName = txtFullName.Text.Trim();
            //_acEntry.Phone = txtPhone.Text.Trim();
            //_acEntry.Address = txtAddress.Text.Trim();
            //_acEntry.Email = txtEmail.Text.Trim();
            //_acEntry.Description = mmeDescription.Text.Trim();

            if (_acEntry.KeyID == 0)
            {
                _acEntry.IsEnable = true;
                //_acEntry.Code = txtCode.Text.Trim().ToUpper();
                _acEntry.CreatedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.CreatedDate = DateTime.Now.ServerNow();
            }
            else
            {
                _acEntry.ModifiedBy = clsGeneral.curPersonnel.KeyID;
                _acEntry.ModifiedDate = DateTime.Now.ServerNow();
            }

            bRe = await clsPersonnel.Instance.AddOrUpdate(_acEntry);

            if (bRe && ReLoadParent != null)
                ReLoadParent(_acEntry.KeyID);

            return bRe;
        }

        protected override void CustomForm()
        {
            txtCode.NotUnicode(true, true);
            txtFullName.IsPersonName();
            txtPhone.PhoneOnly();
            base.CustomForm();
        }

        public void ResetData()
        {
        }
        #endregion
    }
}