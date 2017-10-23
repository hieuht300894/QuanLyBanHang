using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using QuanLyBanHang.BLL.Common;
using QuanLyBanHang.BLL.PERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmBase : XtraForm
    {
        #region Variables
        public eFormType fType;
        public List<eFormType> fTypes;
        bool IsLeaveForm = false;
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
            foreach (var item in barTop.Manager.Items)
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
        private void LoadAccessForm()
        {
            fTypes = fTypes ?? new List<eFormType>();
            if (!fTypes.Any(x => x == fType)) fTypes.Add(fType);

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
        #endregion

        #region Events
        protected virtual void frmBase_Load(object sender, EventArgs e)
        {
            LoadAccessForm();
            BarItemVisibility();
            SetCaptionButton();
            InitEvents();
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

        }
        private void btnLoading_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void frmBase_Enter(object sender, EventArgs e)
        {
            if (IsLeaveForm)
            {
                LoadAccessForm();
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

        #region Method Base
        #region ShowGridPopup
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
                    foreach (eFormType _fType in fTypes)
                    {
                        if (_fType == eFormType.Default)
                            bbpAdd.Enabled = clsGeneral.curUserFeature.IsAdd && IsAdd;
                    }
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
        #endregion

        #region Delegate Method
        public void LoadPercent(int Percent)
        {
            betPercent.EditValue = Percent;
        }
        public void LoadMessage(string Msg)
        {
            clsGeneral.showMessage(Msg);
        }
        public void LoadError(Exception Ex)
        {
            clsGeneral.showErrorException(Ex);
        }
        public void OpenProgress()
        {
            Action action = () =>
            {
                barBottom.Visible = true;
                betPercent.EditValue = 0;
                betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            };
            Invoke(action);
        }
        public void CloseProgress()
        {
            Action action = () =>
            {
                barBottom.Visible = false;
                betPercent.EditValue = 0;
                betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            };
            Invoke(action);
        }
        public void ShowAlert(string Title = "", string Text = "")
        {
            alertMsg.Show(this, Title, Text);
        }
        #endregion

        #region LoadData
        private void SetAction<T>(clsSelect<T> select, bool IsShowPercent, bool IsShowMessage, bool IsShowError) where T : class, new()
        {
            if (IsShowPercent)
            {
                select._OpenProgress = OpenProgress;
                select._CloseProgress = CloseProgress;
                select._ReloadPercent = LoadPercent;
            }
            if (IsShowMessage)
            {
                select._ReloadMessage = LoadMessage;
            }
            if (IsShowError)
            {
                select._ReloadError = LoadError;
            }
        }
        public void LoadData<T>(int KeyID, GridControl gctMain, IList<T> ListData, bool IsShowPercent = false, bool IsShowMessage = false, bool IsShowError = false) where T : class, new()
        {
            gctMain.DataSource = ListData;
            clsSelect<T> select = new clsSelect<T>();
            select.Init();
            select.SetEntity(ListData);
            SetAction(select, IsShowPercent, IsShowMessage, IsShowError);
            select._InsertObjectToList = AddData;
            select.StartRun();
        }
        private void AddData<T>(T TObject, IList<T> ListData) where T : class, new()
        {
            Action action = () => { ListData.Add(TObject); };
            Invoke(action);
        }
        #endregion
        #endregion
    }
}