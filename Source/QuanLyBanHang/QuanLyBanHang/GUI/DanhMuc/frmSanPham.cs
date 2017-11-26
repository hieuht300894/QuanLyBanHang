using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmSanPham : frmBaseGrid
    {
        BindingList<eSanPham> lstEntries = new BindingList<eSanPham>();
        BindingList<eSanPham> lstEdited = new BindingList<eSanPham>();

        public frmSanPham()
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
            IList<eDonViTinh> lstDVT = await clsFunction<eDonViTinh>.Instance.GetAll();
            await RunMethodAsync(() => { rlokDVT.DataSource = lstDVT; });
        }
        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eSanPham>();
            lstEntries = new BindingList<eSanPham>(await clsFunction<eSanPham>.Instance.GetAll());
            lstEntries.ToList().ForEach(x => { x.Color = Color.FromArgb(x.ColorHex); });

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
                eDonViTinh dvt = (eDonViTinh)rlokDVT.GetDataSourceRowByKeyValue(x.IDDonViTinh) ?? new eDonViTinh();
                x.MaDonViTinh = dvt.Ma;
                x.TenDonViTinh = dvt.Ten;

                x.MauSac = rpclr.ColorText.ToString();
                x.ColorHex = x.Color.ToArgb();
            });


            bool chk = false;
            chk = await clsFunction<eSanPham>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
            rlokDVT.ValueMember = "KeyID";
            rlokDVT.DisplayMember = "Ten";

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
            if (!lstEdited.Any(x => x.KeyID == ((eSanPham)e.Row).KeyID)) lstEdited.Add((eSanPham)e.Row);
        }
    }
}
