using System;
using System.Windows.Forms;
using System.Collections.Generic;
using QuanLyBanHang.BLL.PERS;
using System.Threading;
using DevExpress.XtraPrinting.Export;

namespace QuanLyBanHang
{
    public partial class frmBaseGrid : DevExpress.XtraEditors.XtraForm
    {
        #region Variables
        #endregion

        #region Form
        #endregion

        #region Methods
        #endregion

        #region Events
        #endregion

        public eFormType fType;
        public bool isEnable = true;

        public frmBaseGrid()
        {
            InitializeComponent();
            btsIsEnable.CheckedChanged += btsChanged;
            btsIsEnable.CheckedChanged += btsIsEnable_CheckedChanged;
        }

        private void btsChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEnable = btsIsEnable.Checked;
            btsIsEnable.Caption = btsIsEnable.Checked ? "Kích hoạt".Translation("capEnable") : "Không kích hoạt".Translation("capDisable");
        }

        private void BarItemVisibility()
        {
            if (fType == eFormType.Default)
            {
                btnAdd.Visibility = clsGeneral.curUserFeature.IsAdd ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnSave.Visibility = (clsGeneral.curUserFeature.IsAdd || clsGeneral.curUserFeature.IsEdit) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void setCaptionButton()
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

        protected virtual void frmBaseGrid_Load(object sender, EventArgs e)
        {
            loadAccessForm();
            btsIsEnable.Caption = btsIsEnable.Checked ? "Kích hoạt".Translation("capEnable") : "Không kích hoạt".Translation("capDisable");
            BarItemVisibility();
            setCaptionButton();
        }

        private void loadAccessForm()
        {
            if (fType == eFormType.Default && (this.Name.StartsWith("frm") || this.Name.StartsWith("bbi")))
            {
                if (this.Name.StartsWith("bbi"))
                    clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature() { IsAdd = true, IsDelete = true, IsEdit = true, IsEnable = true };
                else
                {
                    if (clsGeneral.curPersonnel.KeyID > 0 && clsGeneral.curAccount.IDPermission>0 && clsGeneral.curAccount.IDPermission > 0)
                        clsGeneral.curUserFeature = clsUserRole.Instance.GetUserFeature(this.Name);
                    else if (clsGeneral.curPersonnel.KeyID == 0 && clsGeneral.curAccount.IDPermission == 0)
                        clsGeneral.curUserFeature = new EntityModel.DataModel.xUserFeature() { IsAdd = true, IsDelete = true, IsEdit = true, IsEnable = true };
                }
            }
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

        protected virtual void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btnSaveAndAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void btsIsEnable_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        protected virtual void bbpRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected virtual void bbpPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //protected virtual void ShowGridPopup(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == System.Windows.Forms.MouseButtons.Right)
        //    {
        //        DevExpress.XtraGrid.GridControl gctMain = (DevExpress.XtraGrid.GridControl)sender;
        //        DevExpress.XtraGrid.Views.Grid.GridView grvMain = (DevExpress.XtraGrid.Views.Grid.GridView)gctMain.DefaultView;
        //        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvMain.CalcHitInfo(e.Location);

        //        grvMain.CloseEditor();
        //        grvMain.UpdateCurrentRow();

        //        if (hi.RowHandle >= 0 && (hi.InRow || hi.InRowCell))
        //        {
        //            var idTemp = grvMain.GetRowCellValue(hi.RowHandle, "KeyID");
        //            int id = idTemp != null ? (int)idTemp : 0;

        //            if (clsGeneral.curUserFeature.IsDelete || (clsGeneral.curUserFeature.IsAdd && id <= 0))
        //                bbpDisable.Enabled = true;

        //            bbpPrint.Enabled = true;
        //        }
        //        else
        //        {
        //            bbpDisable.Enabled = bbpPrint.Enabled = false;
        //        }
        //        //bbpAdd.Enabled = clsGeneral.curUserFeature.IsAdd;
        //        popGridMenu.ShowPopup(MousePosition);
        //    }
        //}

        protected virtual void ShowGridPopup(object sender, MouseEventArgs e, bool IsPrint = false)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DevExpress.XtraGrid.GridControl gctMain = (DevExpress.XtraGrid.GridControl)sender;
                DevExpress.XtraGrid.Views.Grid.GridView grvMain = (DevExpress.XtraGrid.Views.Grid.GridView)gctMain.DefaultView;
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi = grvMain.CalcHitInfo(e.Location);

                grvMain.CloseEditor();
                grvMain.UpdateCurrentRow();

                if (hi.RowHandle >= 0 && (hi.InRow || hi.InRowCell))
                {
                    var idTemp = grvMain.GetRowCellValue(hi.RowHandle, "KeyID");
                    int id = idTemp != null ? (int)idTemp : 0;

                    if (clsGeneral.curUserFeature.IsDelete || (clsGeneral.curUserFeature.IsAdd && id <= 0))
                        bbpDisable.Enabled = true;

                    bbpPrint.Enabled = IsPrint;
                }
                else
                {
                    bbpDisable.Enabled = bbpPrint.Enabled = false;
                }
                //bbpAdd.Enabled = clsGeneral.curUserFeature.IsAdd;
                popGridMenu.ShowPopup(MousePosition);
            }
        }

        private void frmBaseGrid_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control is DevExpress.XtraLayout.LayoutControl)
            {
                try
                {
                }
                catch { }
            }
        }

        private void frmBaseGrid_Enter(object sender, EventArgs e)
        {
            loadAccessForm();
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
    }
}