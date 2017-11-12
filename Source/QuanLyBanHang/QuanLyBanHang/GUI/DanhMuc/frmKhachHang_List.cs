using EntityModel.DataModel;
using QuanLyBanHang.BLL.DanhMuc;
using QuanLyBanHang.GUI.Common;
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
    public partial class frmKhachHang_List : frmBaseList
    {
        public frmKhachHang_List()
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
            using (frmKhachHang frm = new frmKhachHang())
            {
                frm.Text = "Thêm mới khách hàng";
                frm.fType = eFormType.Add;
                frm.ReloadData = LoadData;
                frm.ShowDialog();
            }
        }

        public override async void LoadData(object KeyID)
        {
            IList<eKhachHang> lstKH = await clsKhachHang.Instance.GetAll();
            await RunMethodAsync(() =>
            {
                gctDanhSach.DataSource = lstKH;
                if (KeyID.GetType() == typeof(int) && (int)KeyID > 0)
                    grvDanhSach.FocusedRowHandle = grvDanhSach.LocateByValue("KeyID", KeyID);
            });
        }

        public override void RefreshEntry()
        {
            LoadData(0);
        }

        public override void UpdateEntry()
        {
            using (frmKhachHang frm = new frmKhachHang())
            {
                frm._iEntry = (eKhachHang)grvDanhSach.GetFocusedRow();
                frm.Text = "Cập nhật khách hàng";
                frm.fType = eFormType.Edit;
                frm.ReloadData = LoadData;
                frm.ShowDialog();
            }
        }

        protected override void CustomForm()
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
