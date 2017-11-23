using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.DanhMuc;
using QuanLyBanHang.Model;
using QuanLyBanHang.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmKhachHang : frmBaseGrid
    {
        BindingList<eKhachHang> lstEntries = new BindingList<eKhachHang>();
        BindingList<eKhachHang> lstEdited = new BindingList<eKhachHang>();

        public frmKhachHang()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadRepository();
            LoadData(0);
            CustomForm();
        }

        async void LoadRepository()
        {
            rlokGioiTinh.DataSource = Loai.LoaiGioiTinh();

            IList<eTinhThanh> lstTinhThanh = new List<eTinhThanh>(await clsTinhThanh.Instance.Get63TinhThanh());
            await RunMethodAsync(() => { rlokTinhThanh.DataSource = lstTinhThanh; });
        }
        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eKhachHang>();
            lstEntries = new BindingList<eKhachHang>(await clsFunction<eKhachHang>.Instance.GetAll());
            await RunMethodAsync(() => { gctDanhSach.DataSource = lstEntries; });
        }
        public override bool ValidationForm()
        {
            grvDanhSach.CloseEditor();
            grvDanhSach.UpdateCurrentRow();
            return base.ValidationForm();
        }
        public async override Task<bool> SaveData()
        {
            lstEdited.ToList().ForEach(x =>
            {
                Loai gioiTinh = (Loai)rlokGioiTinh.GetDataSourceRowByKeyValue(x.IDGioiTinh) ?? new Loai();
                eTinhThanh tinhThanh = (eTinhThanh)rlokTinhThanh.GetDataSourceRowByKeyValue(x.IDTinhThanh) ?? new eTinhThanh();

                x.GioiTinh = gioiTinh.Ten;
                x.TinhThanh = tinhThanh.Ten;
            });

            bool chk = false;
            List<eKhachHang> lstInserted = new List<eKhachHang>(lstEdited.Where(x => x.KeyID <= 0));
            chk = await clsFunction<eKhachHang>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            rlokGioiTinh.ValueMember = "KeyID";
            rlokGioiTinh.DisplayMember = "Ten";
            rlokTinhThanh.ValueMember = "KeyID";
            rlokTinhThanh.DisplayMember = "Ten";

            base.CustomForm();

            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.RowUpdated += grvDanhSach_RowUpdated;
            grvDanhSach.InitNewRow += grvDanhSach_InitNewRow;
        }

        private void gctDanhSach_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ShowGridPopup(sender, e, true, false, true, true, true, true);
        }
        private void grvDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!lstEdited.Any(x => x.KeyID == ((eKhachHang)e.Row).KeyID)) lstEdited.Add((eKhachHang)e.Row);
        }
        private void grvDanhSach_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (grvDanhSach.FocusedColumn != colNgaySinh)
                grvDanhSach.SetRowCellValue(grvDanhSach.FocusedRowHandle, colNgaySinh, new DateTime(1900, 1, 1));
        }
    }
}
