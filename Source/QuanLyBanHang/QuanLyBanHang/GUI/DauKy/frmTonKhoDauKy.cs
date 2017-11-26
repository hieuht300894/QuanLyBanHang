using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DauKy
{
    public partial class frmTonKhoDauKy : frmBaseGrid
    {
        BindingList<eTonKhoDauKy> lstEntries = new BindingList<eTonKhoDauKy>();
        BindingList<eTonKhoDauKy> lstEdited = new BindingList<eTonKhoDauKy>();

        public frmTonKhoDauKy()
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

        public async void LoadRepository()
        {
            IList<eSanPham> lstSanPham = await clsFunction<eSanPham>.Instance.GetAll();
            await RunMethodAsync(() => { rlokSanPham.DataSource = lstSanPham; });

            IList<eKho> lstKho = await clsFunction<eKho>.Instance.GetAll();
            await RunMethodAsync(() => { rlokKho.DataSource = lstKho; });
        }
        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eTonKhoDauKy>();
            lstEntries = new BindingList<eTonKhoDauKy>(await clsFunction<eTonKhoDauKy>.Instance.GetAll());
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
                eSanPham sanPham = (eSanPham)rlokSanPham.GetDataSourceRowByKeyValue(x.IDSanPham) ?? new eSanPham();
                x.MaSanPham = sanPham.Ma;
                x.TenSanPham = sanPham.Ten;

                x.IDDonViTinh = sanPham.IDDonViTinh;
                x.MaDonViTinh = sanPham.MaDonViTinh;
                x.TenDonViTinh = sanPham.TenDonViTinh;

                eKho kho = (eKho)rlokKho.GetDataSourceRowByKeyValue(x.IDKho) ?? new eKho();
                x.MaKho = kho.Ma;
                x.TenKho = kho.Ten;
            });

            bool chk = false;
            chk = await clsFunction<eTonKhoDauKy>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            rlokKho.ValueMember = "KeyID";
            rlokKho.DisplayMember = "Ten";

            rlokSanPham.ValueMember = "KeyID";
            rlokSanPham.DisplayMember = "Ten";

            base.CustomForm();
            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.RowUpdated += grvDanhSach_RowUpdated;
            grvDanhSach.InitNewRow += grvDanhSach_InitNewRow;
        }

        private void grvDanhSach_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = (GridView)sender;
            view.SetRowCellValue(e.RowHandle, colKeyID, -lstEdited.Count);
        }
        private void gctDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            ShowGridPopup(sender, e, true, false, true, true, true, true);
        }
        private void grvDanhSach_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if (!lstEdited.Any(x => x.KeyID == ((eTonKhoDauKy)e.Row).KeyID)) lstEdited.Add((eTonKhoDauKy)e.Row);
        }
    }
}
