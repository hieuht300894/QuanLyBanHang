using EntityModel.DataModel;
using QuanLyBanHang.BLL.DanhMuc;
using QuanLyBanHang.GUI.Common;
using QuanLyBanHang.Model;
using QuanLyBanHang.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmKhachHang : frmBaseEdit
    {
        public delegate void LoadData(object KeyID);
        public LoadData ReloadData;
        List<eTinhThanh> lstTinhThanh = new List<eTinhThanh>();
        public eKhachHang _iEntry = new eKhachHang();
        eKhachHang _aEntry = new eKhachHang();
        eTinhThanh tinhThanh = new eTinhThanh();
        Loai loaiGioiTinh = new Loai();

        public frmKhachHang()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadRepository();
            LoadDataForm();
            CustomForm();
        }
        protected override void frmBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.frmBase_FormClosing(sender, e);
            ReloadData?.Invoke(0);
        }

        async void LoadRepository()
        {
            lokGioiTinh.Properties.DataSource = Loai.LoaiGioiTinh();

            lstTinhThanh = new List<eTinhThanh>(await clsTinhThanh.Instance.Get63TinhThanh());
            await RunMethodAsync(() => { lokTinhThanh.Properties.DataSource = lstTinhThanh; });
        }

        public override async void LoadDataForm()
        {
            _iEntry = _iEntry ?? new eKhachHang();
            _aEntry = await clsKhachHang.Instance.GetByID(_iEntry.KeyID);

            if (_aEntry.KeyID == 0)
                _aEntry.NgaySinh = new DateTime(1900, 1, 1);

            SetControlValue();
        }

        public override void RenewData()
        {
            _iEntry = _aEntry = null;
        }

        public override async Task<bool> SaveData()
        {
            _aEntry.GioiTinh = lokGioiTinh.Text;
            _aEntry.TinhThanh = lokTinhThanh.Text;

            bool chk = true;
            chk = await clsKhachHang.Instance.AddOrUpdate(_aEntry);
            return chk;
        }

        public override void SetControlValue()
        {
            //txtMaKH.DataBindings.Clear();
            //txtHoKH.DataBindings.Clear();
            //txtTenKH.DataBindings.Clear();
            //lokGioiTinh.DataBindings.Clear();
            //txtSDT.DataBindings.Clear();
            //txtEmail.DataBindings.Clear();
            //mmeDiaChi.DataBindings.Clear();
            //lokTinhThanh.DataBindings.Clear();
            //mmeGhiChu.DataBindings.Clear();
            //dteNgaySinh.DataBindings.Clear();

            txtMaKH.DataBindings.Add("EditValue", _aEntry, "Ma", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHoKH.DataBindings.Add("EditValue", _aEntry, "Ho", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenKH.DataBindings.Add("EditValue", _aEntry, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            lokGioiTinh.DataBindings.Add("EditValue", _aEntry, "IDGioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSDT.DataBindings.Add("EditValue", _aEntry, "SoDienThoai", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("EditValue", _aEntry, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeDiaChi.DataBindings.Add("EditValue", _aEntry, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
            lokTinhThanh.DataBindings.Add("EditValue", _aEntry, "IDTinhThanh", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeGhiChu.DataBindings.Add("EditValue", _aEntry, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            dteNgaySinh.DataBindings.Add("DateTime", _aEntry, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override bool ValidationForm()
        {
            bool chk = true;
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {

            }
            return chk;
        }

        protected override void CustomForm()
        {
            lokGioiTinh.Properties.ValueMember = "KeyID";
            lokGioiTinh.Properties.DisplayMember = "Ten";

            lokTinhThanh.Properties.ValueMember = "KeyID";
            lokTinhThanh.Properties.DisplayMember = "Ten";

            base.CustomForm();
        }
    }
}
