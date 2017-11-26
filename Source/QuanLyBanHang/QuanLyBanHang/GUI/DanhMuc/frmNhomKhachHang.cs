using DevExpress.XtraGrid.Views.Grid;
using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmNhomKhachHang : frmBaseGrid
    {
        BindingList<eNhomKhachHang> lstEntries = new BindingList<eNhomKhachHang>();
        BindingList<eNhomKhachHang> lstEdited = new BindingList<eNhomKhachHang>();

        public frmNhomKhachHang()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
        }

        public async override void LoadData(object KeyID)
        {
            lstEdited = new BindingList<eNhomKhachHang>();
            lstEntries = new BindingList<eNhomKhachHang>(await clsFunction<eNhomKhachHang>.Instance.GetAll());
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
            bool chk = false;
            chk = await clsFunction<eNhomKhachHang>.Instance.AddOrUpdate(lstEdited.ToList());
            return chk;
        }
        public override void CustomForm()
        {
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
            if (!lstEdited.Any(x => x.KeyID == ((eNhomKhachHang)e.Row).KeyID)) lstEdited.Add((eNhomKhachHang)e.Row);
        }
    }
}
