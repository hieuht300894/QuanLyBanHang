namespace QuanLyBanHang
{
    partial class frmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase));
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barMenu = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDisable = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btsIsEnable = new DevExpress.XtraBars.BarToggleSwitchItem();
            this.btnPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExcel = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.betPercent = new DevExpress.XtraBars.BarEditItem();
            this.rpbPercent = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbpAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbpEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbpDisable = new DevExpress.XtraBars.BarButtonItem();
            this.bbpRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbpConfirm = new DevExpress.XtraBars.BarButtonItem();
            this.bbpCancelConfirm = new DevExpress.XtraBars.BarButtonItem();
            this.bbpPrint = new DevExpress.XtraBars.BarButtonItem();
            this.popGridMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barMenu
            // 
            this.barMenu.AllowCustomization = false;
            this.barMenu.AllowQuickCustomization = false;
            this.barMenu.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar1});
            this.barMenu.DockControls.Add(this.barDockControlTop);
            this.barMenu.DockControls.Add(this.barDockControlBottom);
            this.barMenu.DockControls.Add(this.barDockControlLeft);
            this.barMenu.DockControls.Add(this.barDockControlRight);
            this.barMenu.Form = this;
            this.barMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDisable,
            this.btnRefresh,
            this.btnSave,
            this.btnCancel,
            this.btnClose,
            this.btnSaveAndAdd,
            this.btsIsEnable,
            this.bbpAdd,
            this.bbpEdit,
            this.bbpDisable,
            this.bbpRefresh,
            this.btnPrintPreview,
            this.btnExportExcel,
            this.betPercent,
            this.bbpConfirm,
            this.bbpCancelConfirm,
            this.bbpPrint});
            this.barMenu.MainMenu = this.bar3;
            this.barMenu.MaxItemId = 24;
            this.barMenu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpbPercent});
            this.barMenu.StatusBar = this.bar1;
            // 
            // bar3
            // 
            this.bar3.BarName = "Main menu";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.FloatLocation = new System.Drawing.Point(68, 180);
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDisable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btsIsEnable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrintPreview, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExportExcel)});
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.MultiLine = true;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Main menu";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm mới";
            this.btnAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdd.Glyph")));
            this.btnAdd.Id = 0;
            this.btnAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnAdd.LargeGlyph")));
            this.btnAdd.LargeGlyphDisabled = global::QuanLyBanHang.Properties.Resources.Add_32x32;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Glyph = global::QuanLyBanHang.Properties.Resources.Edit_16x16;
            this.btnEdit.Id = 1;
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnEdit.LargeGlyph = global::QuanLyBanHang.Properties.Resources.Edit_32x32;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDisable
            // 
            this.btnDisable.Caption = "Hủy";
            this.btnDisable.Glyph = global::QuanLyBanHang.Properties.Resources.Delete_16x16;
            this.btnDisable.Id = 2;
            this.btnDisable.LargeGlyph = global::QuanLyBanHang.Properties.Resources.Delete_32x32;
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnDisable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSave.Glyph")));
            this.btnSave.Id = 6;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSave.LargeGlyph")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnSaveAndAdd
            // 
            this.btnSaveAndAdd.Caption = "Lưu và thêm mới";
            this.btnSaveAndAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndAdd.Glyph")));
            this.btnSaveAndAdd.Id = 9;
            this.btnSaveAndAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.S));
            this.btnSaveAndAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndAdd.LargeGlyph")));
            this.btnSaveAndAdd.Name = "btnSaveAndAdd";
            this.btnSaveAndAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnSaveAndAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndAdd_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Hủy";
            this.btnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.Glyph")));
            this.btnCancel.Id = 7;
            this.btnCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Escape));
            this.btnCancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.LargeGlyph")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Glyph = global::QuanLyBanHang.Properties.Resources.Refresh_16x16;
            this.btnRefresh.Id = 5;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.LargeGlyph = global::QuanLyBanHang.Properties.Resources.Refresh_32x32;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btsIsEnable
            // 
            this.btsIsEnable.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btsIsEnable.BindableChecked = true;
            this.btsIsEnable.Caption = "Kích hoạt";
            this.btsIsEnable.Checked = true;
            this.btsIsEnable.Id = 12;
            this.btsIsEnable.Name = "btsIsEnable";
            this.btsIsEnable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "In";
            this.btnPrintPreview.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.Glyph")));
            this.btnPrintPreview.Id = 18;
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPrintPreview.LargeGlyph")));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnPrintPreview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrintPreview_ItemClick);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "Xuất Excel";
            this.btnExportExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Glyph")));
            this.btnExportExcel.Id = 19;
            this.btnExportExcel.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.E));
            this.btnExportExcel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.LargeGlyph")));
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExportExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportExcel_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Bottom Menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.betPercent)});
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Bottom Menu";
            // 
            // betPercent
            // 
            this.betPercent.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.betPercent.Edit = this.rpbPercent;
            this.betPercent.EditValue = 0;
            this.betPercent.Id = 20;
            this.betPercent.Name = "betPercent";
            this.betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.betPercent.Width = 75;
            // 
            // rpbPercent
            // 
            this.rpbPercent.Name = "rpbPercent";
            this.rpbPercent.ReadOnly = true;
            this.rpbPercent.ShowTitle = true;
            this.rpbPercent.Step = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(584, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 38);
            this.barDockControlBottom.Size = new System.Drawing.Size(584, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 14);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(584, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 14);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 8;
            this.btnClose.Name = "btnClose";
            // 
            // bbpAdd
            // 
            this.bbpAdd.Caption = "Thêm";
            this.bbpAdd.Enabled = false;
            this.bbpAdd.Glyph = global::QuanLyBanHang.Properties.Resources.Add_16x16;
            this.bbpAdd.Id = 13;
            this.bbpAdd.Name = "bbpAdd";
            this.bbpAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpAdd_ItemClick);
            // 
            // bbpEdit
            // 
            this.bbpEdit.Caption = "Cập nhật";
            this.bbpEdit.Enabled = false;
            this.bbpEdit.Glyph = global::QuanLyBanHang.Properties.Resources.Edit_16x16;
            this.bbpEdit.Id = 14;
            this.bbpEdit.Name = "bbpEdit";
            this.bbpEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpEdit_ItemClick);
            // 
            // bbpDisable
            // 
            this.bbpDisable.Caption = "Xóa";
            this.bbpDisable.Enabled = false;
            this.bbpDisable.Glyph = global::QuanLyBanHang.Properties.Resources.Delete_16x16;
            this.bbpDisable.Id = 15;
            this.bbpDisable.Name = "bbpDisable";
            this.bbpDisable.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpDelete_ItemClick);
            // 
            // bbpRefresh
            // 
            this.bbpRefresh.Caption = "Làm mới";
            this.bbpRefresh.Glyph = global::QuanLyBanHang.Properties.Resources.Refresh_16x16;
            this.bbpRefresh.Id = 17;
            this.bbpRefresh.Name = "bbpRefresh";
            this.bbpRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpRefresh_ItemClick);
            // 
            // bbpConfirm
            // 
            this.bbpConfirm.Caption = "Xác nhận";
            this.bbpConfirm.Enabled = false;
            this.bbpConfirm.Glyph = global::QuanLyBanHang.Properties.Resources.Apply_16x16;
            this.bbpConfirm.Id = 21;
            this.bbpConfirm.LargeGlyph = global::QuanLyBanHang.Properties.Resources.Apply_32x32;
            this.bbpConfirm.Name = "bbpConfirm";
            this.bbpConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbpConfirm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpConfirm_ItemClick);
            // 
            // bbpCancelConfirm
            // 
            this.bbpCancelConfirm.Caption = "Hủy cập nhật";
            this.bbpCancelConfirm.Enabled = false;
            this.bbpCancelConfirm.Glyph = global::QuanLyBanHang.Properties.Resources.Reset_16x16;
            this.bbpCancelConfirm.Id = 22;
            this.bbpCancelConfirm.LargeGlyph = global::QuanLyBanHang.Properties.Resources.Reset_32x32;
            this.bbpCancelConfirm.Name = "bbpCancelConfirm";
            this.bbpCancelConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbpCancelConfirm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpCancelConfirm_ItemClick);
            // 
            // bbpPrint
            // 
            this.bbpPrint.Caption = "In phiếu";
            this.bbpPrint.Glyph = global::QuanLyBanHang.Properties.Resources.Print_16x16;
            this.bbpPrint.Id = 23;
            this.bbpPrint.Name = "bbpPrint";
            this.bbpPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbpPrint_ItemClick);
            // 
            // popGridMenu
            // 
            this.popGridMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpDisable),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpConfirm),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpCancelConfirm)});
            this.popGridMenu.Manager = this.barMenu;
            this.popGridMenu.Name = "popGridMenu";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 61);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmBase_Load);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.frmBase_ControlAdded);
            this.Enter += new System.EventHandler(this.frmBase_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        public DevExpress.XtraBars.BarButtonItem btnEdit;
        public DevExpress.XtraBars.Bar bar3;
        public DevExpress.XtraBars.BarButtonItem btnDisable;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnSave;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        public DevExpress.XtraBars.BarButtonItem btnSaveAndAdd;
        public DevExpress.XtraBars.BarToggleSwitchItem btsIsEnable;
        public DevExpress.XtraBars.PopupMenu popGridMenu;
        public DevExpress.XtraBars.BarButtonItem bbpRefresh;
        public DevExpress.XtraBars.BarButtonItem bbpAdd;
        public DevExpress.XtraBars.BarButtonItem bbpEdit;
        public DevExpress.XtraBars.BarButtonItem bbpDisable;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        public DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        public DevExpress.XtraBars.BarButtonItem btnExportExcel;
        public DevExpress.XtraBars.BarButtonItem btnAdd;
        public DevExpress.XtraBars.Bar bar1;
        public DevExpress.XtraBars.BarEditItem betPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar rpbPercent;
        private DevExpress.XtraBars.BarButtonItem bbpConfirm;
        protected DevExpress.XtraBars.BarButtonItem bbpCancelConfirm;
        protected DevExpress.XtraBars.BarButtonItem bbpPrint;
        public DevExpress.XtraBars.BarManager barMenu;
    }
}