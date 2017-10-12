﻿using System;
using System.Windows.Forms;
using System.Linq;
using QuanLyBanHang.BLL.PERS;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;

namespace QuanLyBanHang
{
    public partial class frmBase : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        public eFormType fType;
        public List<eFormType> fTypes;
        bool IsLeaveForm = false;
        public RepositoryItemDateEdit rDateEdit = new RepositoryItemDateEdit();
        #endregion

        #region Form
        public frmBase()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void BarItemVisibility()
        {
            foreach (eFormType _fType in fTypes)
            {
                if (_fType == eFormType.Default)
                {
                    btnAdd.Visibility = clsGeneral.curUserFeature.IsAdd ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    btnEdit.Visibility = clsGeneral.curUserFeature.IsEdit ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    btnDelete.Visibility = clsGeneral.curUserFeature.IsDelete ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                if (_fType == eFormType.Add || _fType == eFormType.Edit)
                {
                    if (_fType == eFormType.Edit && clsGeneral.curUserFeature.IsEdit && clsGeneral.curUserFeature.IsSave)
                    {
                        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnSaveAndAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    if (_fType == eFormType.Add && clsGeneral.curUserFeature.IsAdd && clsGeneral.curUserFeature.IsSave)
                    {
                        btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnSaveAndAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                if (_fType == eFormType.Print)
                {
                    btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    btnExportExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
        }
        private void SetCaptionButton()
        {
            foreach (var item in bar3.Manager.Items)
            {
                if (item is DevExpress.XtraBars.BarButtonItem)
                {
                    if (!Properties.Settings.Default.CurrentCulture.Equals("VN"))
                    {
                        DevExpress.XtraBars.BarButtonItem btn = (DevExpress.XtraBars.BarButtonItem)item;
                        btn.Caption = btn.Name.AutoSpace();
                    }
                }
            }
        }
        private void loadAccessForm()
        {
            fTypes = fTypes ?? new List<eFormType>();
            if (!fTypes.Any(x => x == fType)) fTypes.Add(fType);

            //if (_fType == eFormType.Default && (this.Name.StartsWith("frm") || this.Name.StartsWith("bbi")))
            //{
            //    if (this.Name.StartsWith("bbi"))
            //        clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature()
            //        {
            //            IsAdd = true,
            //            IsDelete = true,
            //            IsEdit = true,
            //            IsEnable = true
            //        };
            //    else
            //    {
            //        if (clsGeneral.curPersonnel.KeyID > 0 && clsGeneral.curAccount.IDPermission.HasValue && clsGeneral.curAccount.IDPermission > 0)
            //            clsGeneral.curUserFeature = clsUserRole.Instance.getUserFeature(this.Name);
            //        else if (clsGeneral.curPersonnel.KeyID == 0 && clsGeneral.curAccount.IDPermission.HasValue && clsGeneral.curAccount.IDPermission == 0)
            //            clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature() { IsAdd = true, IsDelete = true, IsEdit = true, IsEnable = true };
            //    }
            //}

            if (clsGeneral.curPersonnel.KeyID > 0 && clsGeneral.curAccount.IDPermission > 0 && clsGeneral.curAccount.IDPermission > 0)
                clsGeneral.curUserFeature = clsUserRole.Instance.GetUserFeature(this.Name);
            else if (clsGeneral.curPersonnel.KeyID == 0 && clsGeneral.curAccount.IDPermission == 0)
                clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature() { IsAdd = true, IsDelete = true, IsEdit = true, IsSave = true, IsExportExcel = true, IsPrintPreview = true, IsEnable = true };
        }
        private void InitEvents()
        {
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDelete.ItemClick += btnDelete_ItemClick;

            btnSave.ItemClick += btnSave_ItemClick;
            btnSaveAndAdd.ItemClick += btnSaveAndAdd_ItemClick;
            btnCancel.ItemClick += btnCancel_ItemClick;

            btnRefresh.ItemClick += btnRefresh_ItemClick;
            btnPrintPreview.ItemClick += btnPrintPreview_ItemClick;
            btnExportExcel.ItemClick += btnExportExcel_ItemClick;

            bbpAdd.ItemClick += bbpAdd_ItemClick;
            bbpEdit.ItemClick += bbpEdit_ItemClick;
            bbpDelete.ItemClick += bbpDelete_ItemClick;

            bbpSave.ItemClick += bbpSave_ItemClick;
            bbpSaveAndAdd.ItemClick += bbpSaveAndAdd_ItemClick;
            bbpCancel.ItemClick += bbpCancel_ItemClick;

            bbpRefresh.ItemClick += bbpRefresh_ItemClick;
            bbpPrintPreview.ItemClick += bbpPrintPreview_ItemClick;
            bbpExportExcel.ItemClick += bbpExportExcel_ItemClick;
        }
        private void CustomForm()
        {
            rDateEdit.Format();
        }
        protected virtual void ShowGridPopup(object sender, MouseEventArgs e,
            bool IsAdd = false, bool IsEdit = false, bool IsDelete = false,
            bool IsSave = false, bool IsPrintPreview = false, bool IsExportExcel = false)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridControl gctMain = (GridControl)sender;
                GridView grvMain = (GridView)gctMain.DefaultView;
                GridHitInfo hi = grvMain.CalcHitInfo(e.Location);

                if (hi.RowHandle >= 0 && (hi.InRow || hi.InRowCell))
                {
                    foreach (eFormType _fType in fTypes)
                    {
                        if (_fType == eFormType.Default)
                        {
                            bbpAdd.Enabled = clsGeneral.curUserFeature.IsAdd && IsAdd;
                            bbpEdit.Enabled = clsGeneral.curUserFeature.IsEdit && IsEdit;
                            bbpDelete.Enabled = clsGeneral.curUserFeature.IsDelete && IsDelete;
                            bbpRefresh.Enabled = true;
                        }
                        if (_fType == eFormType.Add || _fType == eFormType.Edit)
                        {
                            if (_fType == eFormType.Add && clsGeneral.curUserFeature.IsAdd && clsGeneral.curUserFeature.IsSave)
                            {
                                bbpSave.Enabled = clsGeneral.curUserFeature.IsSave && IsSave;
                                bbpSaveAndAdd.Enabled = clsGeneral.curUserFeature.IsSave && IsSave;
                            }
                            if (_fType == eFormType.Edit && clsGeneral.curUserFeature.IsEdit && clsGeneral.curUserFeature.IsSave)
                            {
                                bbpSave.Enabled = clsGeneral.curUserFeature.IsSave && IsSave;
                                bbpSaveAndAdd.Enabled = clsGeneral.curUserFeature.IsSave && IsSave;
                            }
                            bbpCancel.Enabled = true;
                        }
                        if (_fType == eFormType.Print)
                        {
                            bbpPrintPreview.Enabled = clsGeneral.curUserFeature.IsPrintPreview && IsPrintPreview;
                            bbpExportExcel.Enabled = clsGeneral.curUserFeature.IsExportExcel && IsExportExcel;
                        }
                    }
                }
                else
                {
                    bbpAdd.Enabled = false;
                    bbpEdit.Enabled = false;
                    bbpDelete.Enabled = false;
                    bbpSave.Enabled = false;
                    bbpSaveAndAdd.Enabled = false;
                    bbpCancel.Enabled = false;
                    bbpPrintPreview.Enabled = false;
                    bbpExportExcel.Enabled = false;
                }

                bbpAdd.Visibility = bbpAdd.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpEdit.Visibility = bbpEdit.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpDelete.Visibility = bbpDelete.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpRefresh.Visibility = bbpRefresh.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpSave.Visibility = bbpSave.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpSaveAndAdd.Visibility = bbpSave.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpCancel.Visibility = bbpSave.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpPrintPreview.Visibility = bbpPrintPreview.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                bbpExportExcel.Visibility = bbpExportExcel.Enabled ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;

                popGridMenu.ShowPopup(MousePosition);
            }
        }
        protected virtual void _showPercent(int value)
        {
            betPercent.EditValue = value;
            if (value == 100)
                betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        protected virtual void _showMessage(bool status)
        {
            clsGeneral.showMessage("Đã xóa xong dữ liệu.");
        }
        #endregion

        #region Events
        protected virtual void frmBase_Load(object sender, EventArgs e)
        {
            loadAccessForm();
            BarItemVisibility();
            SetCaptionButton();
            InitEvents();
            CustomForm();
        }
        protected virtual void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void bbpAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void bbpEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void bbpDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void bbpSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        protected virtual void bbpSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        protected virtual void bbpCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        protected virtual void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        protected virtual void bbpExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        protected virtual void bbpPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        protected virtual void frmBase_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is DevExpress.XtraLayout.LayoutControl)
            {
                try
                {
                    ((DevExpress.XtraLayout.LayoutControl)e.Control).Translation();
                }
                catch { }
            }
        }
        private void frmBase_Enter(object sender, EventArgs e)
        {
            if (IsLeaveForm)
            {
                loadAccessForm();
                IsLeaveForm = !IsLeaveForm;
            }
        }
        private void frmBase_Leave(object sender, EventArgs e)
        {
            if (!IsLeaveForm)
            {
                IsLeaveForm = !IsLeaveForm;
            }
        }
        #endregion


    }
}