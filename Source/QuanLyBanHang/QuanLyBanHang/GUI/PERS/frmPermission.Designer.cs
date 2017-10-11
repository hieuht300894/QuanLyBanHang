namespace QuanLyBanHang.GUI.PER
{
    partial class frmPermission
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.mmeDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.trlFeature = new DevExpress.XtraTreeList.TreeList();
            this.colVN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsAdd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rchkChecked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsEdit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsPrintPreview = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsExportExcel = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsSave = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsEnable = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colxUserFeatures = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.rDateEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateEdit.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // rDateEdit
            // 
            this.rDateEdit.Mask.EditMask = "dd/MM/yyyy";
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Appearance.Options.UseFont = true;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblMessage.Location = new System.Drawing.Point(12, 334);
            this.lblMessage.MinimumSize = new System.Drawing.Size(0, 18);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(860, 18);
            this.lblMessage.StyleController = this.layoutControl1;
            this.lblMessage.TabIndex = 11;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.mmeDescription);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.lblMessage);
            this.layoutControl1.Controls.Add(this.trlFeature);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(884, 364);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // mmeDescription
            // 
            this.mmeDescription.Location = new System.Drawing.Point(66, 36);
            this.mmeDescription.Name = "mmeDescription";
            this.mmeDescription.Size = new System.Drawing.Size(806, 46);
            this.mmeDescription.StyleController = this.layoutControl1;
            this.mmeDescription.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(806, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 4;
            // 
            // trlFeature
            // 
            this.trlFeature.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colVN,
            this.colEN,
            this.colIsAdd,
            this.colIsEdit,
            this.colIsDelete,
            this.colIsPrintPreview,
            this.colIsExportExcel,
            this.colIsSave,
            this.colIsEnable,
            this.colxUserFeatures});
            this.trlFeature.Cursor = System.Windows.Forms.Cursors.Default;
            this.trlFeature.DataSource = this.bindingSource1;
            this.trlFeature.KeyFieldName = "KeyID";
            this.trlFeature.Location = new System.Drawing.Point(12, 86);
            this.trlFeature.Name = "trlFeature";
            this.trlFeature.ParentFieldName = "IDGroup";
            this.trlFeature.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rchkChecked});
            this.trlFeature.Size = new System.Drawing.Size(860, 244);
            this.trlFeature.TabIndex = 6;
            // 
            // colVN
            // 
            this.colVN.Caption = "Chức năng";
            this.colVN.FieldName = "VN";
            this.colVN.Name = "colVN";
            this.colVN.OptionsColumn.AllowEdit = false;
            this.colVN.Width = 80;
            // 
            // colEN
            // 
            this.colEN.Caption = "Function";
            this.colEN.FieldName = "EN";
            this.colEN.Name = "colEN";
            this.colEN.OptionsColumn.AllowEdit = false;
            this.colEN.Width = 80;
            // 
            // colIsAdd
            // 
            this.colIsAdd.Caption = "Thêm";
            this.colIsAdd.ColumnEdit = this.rchkChecked;
            this.colIsAdd.FieldName = "IsAdd";
            this.colIsAdd.Name = "colIsAdd";
            this.colIsAdd.Width = 80;
            // 
            // rchkChecked
            // 
            this.rchkChecked.AutoHeight = false;
            this.rchkChecked.Name = "rchkChecked";
            // 
            // colIsEdit
            // 
            this.colIsEdit.Caption = "Sửa";
            this.colIsEdit.ColumnEdit = this.rchkChecked;
            this.colIsEdit.FieldName = "IsEdit";
            this.colIsEdit.Name = "colIsEdit";
            this.colIsEdit.Width = 80;
            // 
            // colIsDelete
            // 
            this.colIsDelete.Caption = "Xóa";
            this.colIsDelete.ColumnEdit = this.rchkChecked;
            this.colIsDelete.FieldName = "IsDelete";
            this.colIsDelete.Name = "colIsDelete";
            this.colIsDelete.Width = 80;
            // 
            // colIsPrintPreview
            // 
            this.colIsPrintPreview.Caption = "In phiếu";
            this.colIsPrintPreview.ColumnEdit = this.rchkChecked;
            this.colIsPrintPreview.FieldName = "IsPrintPreview";
            this.colIsPrintPreview.Name = "colIsPrintPreview";
            this.colIsPrintPreview.Width = 80;
            // 
            // colIsExportExcel
            // 
            this.colIsExportExcel.Caption = "Xuất Excel";
            this.colIsExportExcel.ColumnEdit = this.rchkChecked;
            this.colIsExportExcel.FieldName = "IsExportExcel";
            this.colIsExportExcel.Name = "colIsExportExcel";
            this.colIsExportExcel.Width = 80;
            // 
            // colIsSave
            // 
            this.colIsSave.Caption = "Lưu";
            this.colIsSave.ColumnEdit = this.rchkChecked;
            this.colIsSave.FieldName = "IsSave";
            this.colIsSave.Name = "colIsSave";
            this.colIsSave.Width = 80;
            // 
            // colIsEnable
            // 
            this.colIsEnable.FieldName = "IsEnable";
            this.colIsEnable.Name = "colIsEnable";
            this.colIsEnable.Width = 79;
            // 
            // colxUserFeatures
            // 
            this.colxUserFeatures.FieldName = "xUserFeatures";
            this.colxUserFeatures.Name = "colxUserFeatures";
            this.colxUserFeatures.Width = 79;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.xFeature);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(884, 364);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.trlFeature;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(864, 248);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblMessage;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 322);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(864, 22);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(864, 24);
            this.layoutControlItem2.Text = "Tên quyền";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(51, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.mmeDescription;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 50);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(68, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(864, 50);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Ghi chú";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(51, 13);
            // 
            // frmPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 411);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmPermission";
            this.Text = "Phân quyền";
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.rDateEdit.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rDateEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraTreeList.TreeList trlFeature;
        private DevExpress.XtraEditors.MemoEdit mmeDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkChecked;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsAdd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsPrintPreview;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsExportExcel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsSave;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsEnable;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colxUserFeatures;
    }
}