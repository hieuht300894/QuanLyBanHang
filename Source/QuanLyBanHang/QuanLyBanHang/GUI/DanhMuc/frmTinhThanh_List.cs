﻿using EntityModel.DataModel;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.DanhMuc;
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
    public partial class frmTinhThanh_List : frmBase, IFormList<int>
    {
        #region Variables
        IList<eTinhThanh> lstDanhSach = new List<eTinhThanh>();
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
        public async void LoadData(int KeyID)
        {
            lstDanhSach = new List<eTinhThanh>(await clsTinhThanh.Instance.GetAll());

            await RunMethodAsync(() => { trlDanhSach.DataSource = lstDanhSach; });
            await RunMethodAsync(() => { lokLoai1.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID == 1 || x.KeyID == 2).ToList(); });
            await RunMethodAsync(() => { lokLoai2.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID == 3 || x.KeyID == 4 || x.KeyID == 5 || x.KeyID == 6).ToList(); });
            await RunMethodAsync(() => { lokLoai3.Properties.DataSource = Loai.LoaiDonViHanhChinh().Where(x => x.KeyID == 7 || x.KeyID == 8 || x.KeyID == 9).ToList(); });
            await RunMethodAsync(() => { lokTen1.Properties.DataSource = lstDanhSach.Where(x => x.IDLoai >= 1 && x.IDLoai <= 2).ToList(); });
            await RunMethodAsync(() => { lokTen2.Properties.DataSource = lstDanhSach.Where(x => x.IDLoai >= 3 && x.IDLoai <= 6).ToList(); });
            await RunMethodAsync(() => { lokTen3.Properties.DataSource = lstDanhSach.Where(x => x.IDLoai >= 7 && x.IDLoai <= 9).ToList(); });
        }

        public void InsertEntry()
        {
            //using (frmPermission _frm = new frmPermission())
            //{
            //    _frm.Text = "Thêm mới quyền";
            //    _frm.fType = eFormType.Add;
            //    _frm.ReloadData = this.LoadData;
            //    _frm.ShowDialog();
            //}
        }

        public void UpdateEntry()
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

        public void DeleteEntry()
        {
        }

        public void RefreshEntry()
        {
            LoadData(0);
        }

        protected override void CustomForm()
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
