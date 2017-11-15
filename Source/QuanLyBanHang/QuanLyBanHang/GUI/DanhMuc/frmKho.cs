using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.DanhMuc;
using QuanLyBanHang.GUI.Common;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmKho : frmBaseEdit
    {
        public delegate void LoadData(object KeyID);
        public LoadData ReloadData;
        public eKho _iEntry = new eKho();
        eKho _aEntry = new eKho();

        public frmKho()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            MsgAdd = "Thêm mới kho";
            MsgEdit = "Cập nhật kho";
            MsgDelete = "Xóa kho";
            LoadDataForm();
            CustomForm();
        }
        protected override void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.frmBase_FormClosing(sender, e);
            ReloadData?.Invoke(0);
        }

        public override async void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eKho();
            _aEntry = await clsKho.Instance.GetByID(_iEntry.KeyID);

            SetControlValue();
        }
        public override void RenewData()
        {
            _iEntry = _aEntry = null;
        }
        public override async Task<bool> SaveData()
        {
            if (_aEntry.KeyID == 0) { _aEntry.KichHoat = true; }
            else { }

            bool chk = true;
            chk = await clsKho.Instance.AddOrUpdate(_aEntry);
            return chk;
        }
        public override void SetControlValue()
        {
            txtMa.DataBindings.Add("EditValue", _aEntry, "Ma", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("EditValue", _aEntry, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeGhiChu.DataBindings.Add("EditValue", _aEntry, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public override bool ValidationForm()
        {
            bool chk = true;
            return chk;
        }
        public override void CustomForm()
        {
            base.CustomForm();
        }
    }
}
