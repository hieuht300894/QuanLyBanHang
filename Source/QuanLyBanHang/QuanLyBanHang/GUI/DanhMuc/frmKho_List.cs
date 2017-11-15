using EntityModel.DataModel.DanhMuc;
using QuanLyBanHang.BLL.DanhMuc;
using QuanLyBanHang.GUI.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QuanLyBanHang.GUI.DanhMuc
{
    public partial class frmKho_List : frmBase
    {
        public frmKho_List()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
        }

        public override void DeleteEntry()
        {
        }

        public override void InsertEntry()
        {
            using (frmKho frm = new frmKho())
            {
                frm.Text = "Thêm mới kho";
                frm.fType = eFormType.Add;
                frm._ReloadData = LoadData;
                frm.ShowDialog();
            }
        }

        public override async void LoadData(object KeyID)
        {
            IList<eKho> lstKho = await clsKho.Instance.GetAll();
            await RunMethodAsync(() =>
            {
                gctDanhSach.DataSource = lstKho;
                grvDanhSach.FocusedRowHandle = grvDanhSach.LocateByValue("KeyID", KeyID);
            });
        }

        public override void RefreshEntry()
        {
            LoadData(0);
        }

        public override void UpdateEntry()
        {
            using (frmKho frm = new frmKho())
            {
                frm._iEntry = (eKho)grvDanhSach.GetFocusedRow();
                frm.Text = "Cập nhật kho";
                frm.fType = eFormType.Edit;
                frm._ReloadData = LoadData;
                frm.ShowDialog();
            }
        }

        public override void CustomForm()
        {
            base.CustomForm();
            gctDanhSach.MouseClick += gctDanhSach_MouseClick;
            grvDanhSach.DoubleClick += grvDanhSach_DoubleClick;
        }

        private void gctDanhSach_MouseClick(object sender, MouseEventArgs e)
        {
            base.ShowGridPopup(sender, e, true, true, true, false, true, true);
        }

        private void grvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            UpdateEntry();
        }
    }
}
