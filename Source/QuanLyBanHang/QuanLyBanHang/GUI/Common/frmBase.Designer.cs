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
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaveAndAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
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
            this.bbpDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbpRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbpConfirm = new DevExpress.XtraBars.BarButtonItem();
            this.bbpCancel = new DevExpress.XtraBars.BarButtonItem();
            this.bbpPrintPreview = new DevExpress.XtraBars.BarButtonItem();
            this.bbpSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbpSaveAndAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbpExportExcel = new DevExpress.XtraBars.BarButtonItem();
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
            this.btnDelete,
            this.btnRefresh,
            this.btnSave,
            this.btnCancel,
            this.btnClose,
            this.btnSaveAndAdd,
            this.bbpAdd,
            this.bbpEdit,
            this.bbpDelete,
            this.bbpRefresh,
            this.btnPrintPreview,
            this.btnExportExcel,
            this.betPercent,
            this.bbpConfirm,
            this.bbpCancel,
            this.bbpPrintPreview,
            this.bbpSave,
            this.bbpSaveAndAdd,
            this.bbpExportExcel});
            this.barMenu.MainMenu = this.bar3;
            this.barMenu.MaxItemId = 27;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
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
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.DisabledLargeImage = global::QuanLyBanHang.Properties.Resources.Add_32x32;
            this.btnAdd.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Add_16x16;
            this.btnAdd.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Add_32x32;
            this.btnAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Edit_16x16;
            this.btnEdit.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Edit_32x32;
            this.btnEdit.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Delete_16x16;
            this.btnDelete.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Delete_32x32;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 6;
            this.btnSave.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Save_16x16;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnSave.Name = "btnSave";
            this.btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnSaveAndAdd
            // 
            this.btnSaveAndAdd.Caption = "Lưu và thêm mới";
            this.btnSaveAndAdd.Id = 9;
            this.btnSaveAndAdd.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.SaveAndNew_16x16;
            this.btnSaveAndAdd.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.S));
            this.btnSaveAndAdd.Name = "btnSaveAndAdd";
            this.btnSaveAndAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnCancel
            // 
            this.btnCancel.Caption = "Hủy";
            this.btnCancel.Id = 7;
            this.btnCancel.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Cancel_16x16;
            this.btnCancel.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Escape));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Refresh_16x16;
            this.btnRefresh.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Refresh_32x32;
            this.btnRefresh.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Caption = "In";
            this.btnPrintPreview.Id = 18;
            this.btnPrintPreview.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Printer_16x16;
            this.btnPrintPreview.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P));
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Caption = "Xuất Excel";
            this.btnExportExcel.Id = 19;
            this.btnExportExcel.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.ExportToXLSX_16x16;
            this.btnExportExcel.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.E));
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.betPercent.EditWidth = 75;
            this.betPercent.Id = 20;
            this.betPercent.Name = "betPercent";
            this.betPercent.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
            this.barDockControlTop.Manager = this.barMenu;
            this.barDockControlTop.Size = new System.Drawing.Size(884, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 388);
            this.barDockControlBottom.Manager = this.barMenu;
            this.barDockControlBottom.Size = new System.Drawing.Size(884, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barMenu;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 364);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(884, 24);
            this.barDockControlRight.Manager = this.barMenu;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 364);
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
            this.bbpAdd.Id = 13;
            this.bbpAdd.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Add_16x16;
            this.bbpAdd.Name = "bbpAdd";
            // 
            // bbpEdit
            // 
            this.bbpEdit.Caption = "Cập nhật";
            this.bbpEdit.Enabled = false;
            this.bbpEdit.Id = 14;
            this.bbpEdit.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Edit_16x16;
            this.bbpEdit.Name = "bbpEdit";
            // 
            // bbpDelete
            // 
            this.bbpDelete.Caption = "Xóa";
            this.bbpDelete.Enabled = false;
            this.bbpDelete.Id = 15;
            this.bbpDelete.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Delete_16x16;
            this.bbpDelete.Name = "bbpDelete";
            // 
            // bbpRefresh
            // 
            this.bbpRefresh.Caption = "Làm mới";
            this.bbpRefresh.Enabled = false;
            this.bbpRefresh.Id = 17;
            this.bbpRefresh.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Refresh_16x16;
            this.bbpRefresh.Name = "bbpRefresh";
            // 
            // bbpConfirm
            // 
            this.bbpConfirm.Caption = "Xác nhận";
            this.bbpConfirm.Enabled = false;
            this.bbpConfirm.Id = 21;
            this.bbpConfirm.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Apply_16x16;
            this.bbpConfirm.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Apply_32x32;
            this.bbpConfirm.Name = "bbpConfirm";
            this.bbpConfirm.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbpCancel
            // 
            this.bbpCancel.Caption = "Hủy bỏ";
            this.bbpCancel.Enabled = false;
            this.bbpCancel.Id = 22;
            this.bbpCancel.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Cancel_16x16;
            this.bbpCancel.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Reset_32x32;
            this.bbpCancel.Name = "bbpCancel";
            // 
            // bbpPrintPreview
            // 
            this.bbpPrintPreview.Caption = "In phiếu";
            this.bbpPrintPreview.Enabled = false;
            this.bbpPrintPreview.Id = 23;
            this.bbpPrintPreview.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Print_16x16;
            this.bbpPrintPreview.Name = "bbpPrintPreview";
            // 
            // bbpSave
            // 
            this.bbpSave.Caption = "Lưu";
            this.bbpSave.Enabled = false;
            this.bbpSave.Id = 24;
            this.bbpSave.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.Save_16x16;
            this.bbpSave.Name = "bbpSave";
            // 
            // bbpSaveAndAdd
            // 
            this.bbpSaveAndAdd.Caption = "Lưu và Thêm mới";
            this.bbpSaveAndAdd.Enabled = false;
            this.bbpSaveAndAdd.Id = 25;
            this.bbpSaveAndAdd.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.SaveAndNew_16x16;
            this.bbpSaveAndAdd.Name = "bbpSaveAndAdd";
            // 
            // bbpExportExcel
            // 
            this.bbpExportExcel.Caption = "Xuất Excel";
            this.bbpExportExcel.Enabled = false;
            this.bbpExportExcel.Id = 26;
            this.bbpExportExcel.ImageOptions.Image = global::QuanLyBanHang.Properties.Resources.ExportToXLSX_16x16;
            this.bbpExportExcel.Name = "bbpExportExcel";
            // 
            // popGridMenu
            // 
            this.popGridMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbpSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpSaveAndAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpPrintPreview, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbpExportExcel)});
            this.popGridMenu.Manager = this.barMenu;
            this.popGridMenu.Name = "popGridMenu";
            // 
            // frmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
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
            this.Leave += new System.EventHandler(this.frmBase_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpbPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        public DevExpress.XtraBars.BarButtonItem btnEdit;
        public DevExpress.XtraBars.Bar bar3;
        public DevExpress.XtraBars.BarButtonItem btnDelete;
        public DevExpress.XtraBars.BarButtonItem btnRefresh;
        public DevExpress.XtraBars.BarButtonItem btnSave;
        public DevExpress.XtraBars.BarButtonItem btnCancel;
        public DevExpress.XtraBars.BarButtonItem btnSaveAndAdd;
        public DevExpress.XtraBars.PopupMenu popGridMenu;
        public DevExpress.XtraBars.BarButtonItem bbpRefresh;
        public DevExpress.XtraBars.BarButtonItem bbpAdd;
        public DevExpress.XtraBars.BarButtonItem bbpEdit;
        public DevExpress.XtraBars.BarButtonItem bbpDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        public DevExpress.XtraBars.BarButtonItem btnPrintPreview;
        public DevExpress.XtraBars.BarButtonItem btnExportExcel;
        public DevExpress.XtraBars.BarButtonItem btnAdd;
        public DevExpress.XtraBars.Bar bar1;
        public DevExpress.XtraBars.BarEditItem betPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar rpbPercent;
        private DevExpress.XtraBars.BarButtonItem bbpConfirm;
        public DevExpress.XtraBars.BarManager barMenu;
        public DevExpress.XtraBars.BarButtonItem bbpSave;
        public DevExpress.XtraBars.BarButtonItem bbpSaveAndAdd;
        public DevExpress.XtraBars.BarButtonItem bbpExportExcel;
        public DevExpress.XtraBars.BarButtonItem bbpCancel;
        public DevExpress.XtraBars.BarButtonItem bbpPrintPreview;
    }
}