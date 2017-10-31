using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.Model;
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
    public partial class frmTinhThanh_List : frmBase
    {
        #region Variables
        IList<eTinhThanh> lstDanhSach = new List<eTinhThanh>();
        IList<eTinhThanh> lstDanhSach1= new List<eTinhThanh>();
        IList<eTinhThanh> lstDanhSach2 = new List<eTinhThanh>();
        IList<eTinhThanh> lstDanhSach3 = new List<eTinhThanh>();
        #endregion

        #region Form Events
        public frmTinhThanh_List()
        {
            InitializeComponent();
        }
        protected override void frmBase_Load(object sender, EventArgs e)
        {
            base.frmBase_Load(sender, e);
            LoadData(0);
            CustomForm();
        }
        #endregion

        #region Grid Events
        #endregion

        #region Base Button Events
        protected override void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InsertEntry();
        }

        protected override void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshEntry();
        }

        protected override void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateEntry();
        }

        protected override void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteEntry();
        }

        protected override void bbpAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InsertEntry();
        }

        protected override void bbpEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UpdateEntry();
        }

        protected override void bbpDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteEntry();
        }

        protected override void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RefreshEntry();
        }
        #endregion

        #region Methods
        private void LoadData(int KeyID)
        {
            lstDanhSach = new List<eTinhThanh>();
            trlDanhSach.DataSource = lstDanhSach;
            clsFunction.Instance.SelectAsync(this, trlDanhSach, lstDanhSach, "select top 100000 * from eTinhThanh", new System.Data.SqlClient.SqlParameter[] { });

            lokLoai1.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID == 1 || x.KeyID == 2).ToList();
            lokLoai2.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID == 3 || x.KeyID == 4 || x.KeyID == 5 || x.KeyID == 6).ToList();
            lokLoai3.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID == 7 || x.KeyID == 8 || x.KeyID == 9).ToList();

            lstDanhSach1 = new List<eTinhThanh>();
            lokTen1.Properties.DataSource = lstDanhSach1;
            clsFunction.Instance.SelectAsync(this, lokTen1, lstDanhSach1, "select top 100000 * from eTinhThanh where IDLoai between 1 and 2", new System.Data.SqlClient.SqlParameter[] { });

            lstDanhSach2 = new List<eTinhThanh>();
            lokTen2.Properties.DataSource = lstDanhSach2;
            clsFunction.Instance.SelectAsync(this, lokTen2, lstDanhSach2, "select top 100000 * from eTinhThanh where IDLoai between 3 and 6", new System.Data.SqlClient.SqlParameter[] { });

            lstDanhSach3 = new List<eTinhThanh>();
            lokTen3.Properties.DataSource = lstDanhSach3;
            clsFunction.Instance.SelectAsync(this, lokTen3, lstDanhSach3, "select top 100000 * from eTinhThanh where IDLoai between 7 and 9", new System.Data.SqlClient.SqlParameter[] { });
        }

        private void InsertEntry()
        {
            //using (frmPermission _frm = new frmPermission())
            //{
            //    _frm.Text = "Thêm mới quyền";
            //    _frm.fType = eFormType.Add;
            //    _frm.ReloadData = this.LoadData;
            //    _frm.ShowDialog();
            //}
        }

        private void UpdateEntry()
        {
            //if (grvPermission.RowCount > 0 && grvPermission.FocusedRowHandle >= 0)
            //{
            //    try
            //    {
            //        using (frmPermission _frm = new frmPermission())
            //        {
            //            xPermission _eEntry = (xPermission)grvPermission.GetRow(grvPermission.FocusedRowHandle);
            //            _frm._iEntry = _eEntry;
            //            _frm.Text = "Cập nhật quyền";
            //            _frm.fType = eFormType.Edit;
            //            _frm.ReloadData = this.LoadData;
            //            _frm.ShowDialog();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        clsGeneral.showErrorException(ex, "Exception");
            //    }
            //}
        }

        private void DeleteEntry()
        {
        }

        private void RefreshEntry()
        {
            LoadData(0);
        }

        public override void CustomForm()
        {
            lokLoai1.Properties.ValueMember = "KeyID";
            lokLoai1.Properties.DisplayMember = "Ten";
            lokLoai2.Properties.ValueMember = "KeyID";
            lokLoai2.Properties.DisplayMember = "Ten";
            lokLoai3.Properties.ValueMember = "KeyID";
            lokLoai3.Properties.DisplayMember = "Ten";
            lokTen1.Properties.ValueMember = "KeyID";
            lokTen1.Properties.DisplayMember = "Ten";
            lokTen2.Properties.ValueMember = "KeyID";
            lokTen2.Properties.DisplayMember = "Ten";
            lokTen3.Properties.ValueMember = "KeyID";
            lokTen3.Properties.DisplayMember = "Ten";
            trlDanhSach.ParentFieldName = "IDTinhThanh";
            trlDanhSach.KeyFieldName = "KeyID";
            base.CustomForm();
        }
        #endregion
    }
}
