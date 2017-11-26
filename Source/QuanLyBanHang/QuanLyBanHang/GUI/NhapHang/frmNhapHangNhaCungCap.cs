using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.ChucNang;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.DanhMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.NhapHang
{
    public partial class frmNhapHangNhaCungCap : frmBase
    {
        IList<eSanPham> lstSanPham = new List<eSanPham>();
        IList<eKho> lstKho = new List<eKho>();
        IList<eNhomSanPham> lstNhomSanPham = new List<eNhomSanPham>();
        eNhapHangNhaCungCap _iEntry;
        eNhapHangNhaCungCap _aEntry;
        BindingList<eNhapHangNhaCungCapChiTiet> lstDetail = new BindingList<eNhapHangNhaCungCapChiTiet>();
        BindingList<eNhapHangNhaCungCapChiTiet> lstDetail_BAK = new BindingList<eNhapHangNhaCungCapChiTiet>();
        BindingList<eNhapHangNhaCungCapChiTiet> lstDetail_Edited = new BindingList<eNhapHangNhaCungCapChiTiet>();
        BindingList<eNhapHangNhaCungCapChiTiet> lstDetail_Deleted = new BindingList<eNhapHangNhaCungCapChiTiet>();

        public frmNhapHangNhaCungCap()
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
            _ReloadData?.Invoke(0);
        }

        async void LoadRepository()
        {
            lstNhomSanPham = await clsFunction<eNhomSanPham>.Instance.GetAll();
            lstSanPham = await clsFunction<eSanPham>.Instance.GetAll();
            lstKho = await clsFunction<eKho>.Instance.GetAll();

            await RunMethodAsync(() =>
            {
                dteNgayNhap.DateTime = DateTime.Now.ServerNow();
                lokNhomSanPham.Properties.DataSource = lstNhomSanPham;
                rlokSanPham.DataSource = lstSanPham;
                rlokKho.DataSource = lstKho;
                gctSanPham.DataSource = lstSanPham;

                var qSanPham = lstSanPham.Select(x => new { x.Ma, x.Ten });
                foreach (var rSanPham in qSanPham)
                {
                    srcMaSanPham.Properties.Items.Add(rSanPham.Ma);
                    srcTenSanPham.Properties.Items.Add(rSanPham.Ten);
                }
            });
        }
        public async override void LoadDataForm()
        {
            lstDetail = new BindingList<eNhapHangNhaCungCapChiTiet>();
            lstDetail_BAK = new BindingList<eNhapHangNhaCungCapChiTiet>();
            lstDetail_Deleted = new BindingList<eNhapHangNhaCungCapChiTiet>();
            lstDetail_Edited = new BindingList<eNhapHangNhaCungCapChiTiet>();

            _iEntry = _iEntry ?? new eNhapHangNhaCungCap();
            _aEntry = await clsNhapHangNhaCungCap.Instance.GetByID(_iEntry.KeyID);
            SetControlValue();
            SetDataSource();
        }
        public override void SetControlValue()
        {
            lokNhaCungCap.DataBindings.Add("EditValue", _aEntry, "IDNhaCungCap", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLoHang.DataBindings.Add("EditValue", _aEntry, "MaLoHang", true, DataSourceUpdateMode.OnPropertyChanged);
            dteNgayNhap.DataBindings.Add("DateTime", _aEntry, "NgayNhap", true, DataSourceUpdateMode.OnPropertyChanged);
            mmeGhiChu.DataBindings.Add("EditValue", _aEntry, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            spnSoTien.DataBindings.Add("Value", _aEntry, "TongTien", true, DataSourceUpdateMode.OnPropertyChanged);
            spnSoLuong.DataBindings.Add("Value", _aEntry, "SoLuong", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public async override void SetDataSource()
        {
            lstDetail = new BindingList<eNhapHangNhaCungCapChiTiet>(await clsNhapHangNhaCungCap.Instance.NhapHangChiTiet(_aEntry.KeyID));
            lstDetail_BAK = new BindingList<eNhapHangNhaCungCapChiTiet>(lstDetail.Clone());
            await RunMethodAsync(() => { gctChiTiet.DataSource = lstDetail; });
        }
        public override bool ValidationForm()
        {
            return base.ValidationForm();
        }
        public override Task<bool> SaveData()
        {
            return base.SaveData();
        }
        public override void CustomForm()
        {
            lokNhaCungCap.Properties.ValueMember = "KeyID";
            lokNhaCungCap.Properties.DisplayMember = "Ten";
            lokNhomSanPham.Properties.ValueMember = "KeyID";
            lokNhomSanPham.Properties.DisplayMember = "Ten";
            rlokKho.ValueMember = "KeyID";
            rlokKho.DisplayMember = "Ten";
            rlokSanPham.ValueMember = "KeyID";
            rlokSanPham.DisplayMember = "Ten";

            base.CustomForm();

            grvChiTiet.OptionsView.ColumnAutoWidth = false;

            lokNhomSanPham.PreviewKeyDown += LokNhomSanPham_PreviewKeyDown;
            srcMaSanPham.PreviewKeyDown += SrcMaSanPham_PreviewKeyDown;
            srcTenSanPham.PreviewKeyDown += SrcTenSanPham_PreviewKeyDown;
            grvChiTiet.InitNewRow += GrvChiTiet_InitNewRow;
            grvChiTiet.RowUpdated += GrvChiTiet_RowUpdated;
            grvChiTiet.CellValueChanged += GrvChiTiet_CellValueChanged;
            rbtnXoa.ButtonClick += RbtnXoa_ButtonClick;
            spnThanhToan.EditValueChanged += SpnThanhToan_EditValueChanged;
        }
        void TimKiemSanPham()
        {
            List<eSanPham> lstTimKiem = new List<eSanPham>(lstSanPham);

            if (!string.IsNullOrEmpty(srcMaSanPham.Text.Trim()))
                lstTimKiem = lstTimKiem.Where(x => x.Ma.ToLower().Contains(srcMaSanPham.Text.Trim().ToLower())).ToList();

            if (!string.IsNullOrEmpty(srcTenSanPham.Text.Trim()))
                lstTimKiem = lstTimKiem.Where(x => x.Ten.ToLower().Contains(srcTenSanPham.Text.Trim().ToLower())).ToList();

            gctSanPham.DataSource = lstTimKiem;
        }
        void CapNhatSoTien()
        {
            spnSoLuong.Value = spnSoTien.Value = 0;
            spnTongNo.Value = spnNoCu.Value;

            _aEntry.SoLuong = _aEntry.ThanhTien = _aEntry.TongTien = 0;

            foreach (eNhapHangNhaCungCapChiTiet item in lstDetail)
            {
                spnSoLuong.Value += item.SoLuong;
                spnSoTien.Value += item.TongTien;
                spnTongNo.Value += item.TongTien;
            }
            spnConLai.Value = spnTongNo.Value - spnThanhToan.Value;
        }

        private void SpnThanhToan_EditValueChanged(object sender, EventArgs e)
        {
            spnConLai.Value = spnTongNo.Value - spnThanhToan.Value;
        }
        private void RbtnXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            eNhapHangNhaCungCapChiTiet item = (eNhapHangNhaCungCapChiTiet)grvChiTiet.GetFocusedRow();
            if (item != null)
            {
                lstDetail.Remove(item);

                if (lstDetail_Edited.Any(x => x.KeyID == item.KeyID))
                    lstDetail_Edited.Remove(item);

                if (lstDetail_Deleted.Any(x => x.KeyID == item.KeyID))
                    lstDetail_Deleted.Remove(item);
            }
        }
        private void GrvChiTiet_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = (GridView)sender;
            view.CellValueChanged -= GrvChiTiet_CellValueChanged;
            view.SetRowCellValue(e.RowHandle, "KeyID", -lstDetail_Edited.Count);
            view.CellValueChanged += GrvChiTiet_CellValueChanged;
        }
        private void GrvChiTiet_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            GridView view = (GridView)sender;
            eNhapHangNhaCungCapChiTiet item = (eNhapHangNhaCungCapChiTiet)e.Row;
            if (!lstDetail_Edited.Any(x => x.KeyID == item.KeyID))
                lstDetail_Edited.Add(item);
        }
        private void GrvChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = (GridView)sender;
            eNhapHangNhaCungCapChiTiet item = (eNhapHangNhaCungCapChiTiet)view.GetFocusedRow();
            if (item == null) return;

            view.CellValueChanged -= GrvChiTiet_CellValueChanged;
            if (e.Column.FieldName.Equals("SoLuongSi") || e.Column.FieldName.Equals("SoLuongLe"))
            {
                item.SoLuong = item.SoLuongSi + item.SoLuongLe;
                item.ThanhTien = item.SoLuong * item.DonGia;
                item.TongTien = item.ThanhTien * ((100 - item.ChietKhau) / 100);
                CapNhatSoTien();
            }
            if (e.Column.FieldName.Equals("DonGia"))
            {
                item.ThanhTien = item.SoLuong * item.DonGia;
                item.TongTien = item.ThanhTien * ((100 - item.ChietKhau) / 100);
                CapNhatSoTien();
            }
            if (e.Column.FieldName.Equals("ChietKhau"))
            {
                item.TongTien = item.ThanhTien * ((100 - item.ChietKhau) / 100);
                CapNhatSoTien();
            }
            view.CellValueChanged += GrvChiTiet_CellValueChanged;
        }
        private void SrcTenSanPham_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) { TimKiemSanPham(); }
        }
        private void SrcMaSanPham_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) { TimKiemSanPham(); }
        }
        private void LokNhomSanPham_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab) { TimKiemSanPham(); }
        }
    }
}
