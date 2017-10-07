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
            this.lctPermission = new DevExpress.XtraLayout.LayoutControl();
            this.gctPermission = new DevExpress.XtraGrid.GridControl();
            this.grvPermission = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ucolKeyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolIsEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokPersonnel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ucolCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolRoles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ucolAccounts = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dkpPermission = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lctRole = new DevExpress.XtraLayout.LayoutControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.chkIsEnable = new DevExpress.XtraEditors.CheckEdit();
            this.btnrCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnrSave = new DevExpress.XtraEditors.SimpleButton();
            this.trlFeature = new DevExpress.XtraTreeList.TreeList();
            this.colVN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colEN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsAdd = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rchkChecked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsEdit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colxUserFeatures = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mmeDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmtySpace = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPermission)).BeginInit();
            this.lctPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dkpPermission.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lctRole)).BeginInit();
            this.lctRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsEnable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmtySpace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lctPermission
            // 
            this.lctPermission.Controls.Add(this.gctPermission);
            this.lctPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctPermission.Location = new System.Drawing.Point(450, 26);
            this.lctPermission.Name = "lctPermission";
            this.lctPermission.Root = this.layoutControlGroup1;
            this.lctPermission.Size = new System.Drawing.Size(550, 363);
            this.lctPermission.TabIndex = 4;
            this.lctPermission.Text = "layoutControl1";
            // 
            // gctPermission
            // 
            this.gctPermission.Location = new System.Drawing.Point(12, 12);
            this.gctPermission.MainView = this.grvPermission;
            this.gctPermission.Name = "gctPermission";
            this.gctPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlokPersonnel});
            this.gctPermission.Size = new System.Drawing.Size(526, 339);
            this.gctPermission.TabIndex = 4;
            this.gctPermission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermission});
            this.gctPermission.DoubleClick += new System.EventHandler(this.grvUserRoleList_DoubleClick);
            this.gctPermission.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gctUserRoleList_MouseClick);
            // 
            // grvPermission
            // 
            this.grvPermission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ucolKeyID,
            this.ucolName,
            this.ucolDescription,
            this.ucolIsEnable,
            this.ucolCreatedBy,
            this.ucolCreatedDate,
            this.ucolModifiedBy,
            this.ucolModifiedDate,
            this.ucolRoles,
            this.ucolAccounts});
            this.grvPermission.GridControl = this.gctPermission;
            this.grvPermission.Name = "grvPermission";
            this.grvPermission.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvUserRoleList_FocusedRowChanged);
            this.grvPermission.Click += new System.EventHandler(this.grvPermission_Click);
            // 
            // ucolKeyID
            // 
            this.ucolKeyID.FieldName = "KeyID";
            this.ucolKeyID.Name = "ucolKeyID";
            this.ucolKeyID.OptionsColumn.AllowEdit = false;
            // 
            // ucolName
            // 
            this.ucolName.Caption = "Tên";
            this.ucolName.FieldName = "Name";
            this.ucolName.Name = "ucolName";
            this.ucolName.OptionsColumn.AllowEdit = false;
            this.ucolName.Visible = true;
            this.ucolName.VisibleIndex = 0;
            // 
            // ucolDescription
            // 
            this.ucolDescription.Caption = "Ghi Chú";
            this.ucolDescription.FieldName = "Description";
            this.ucolDescription.Name = "ucolDescription";
            this.ucolDescription.OptionsColumn.AllowEdit = false;
            this.ucolDescription.Visible = true;
            this.ucolDescription.VisibleIndex = 1;
            // 
            // ucolIsEnable
            // 
            this.ucolIsEnable.FieldName = "IsEnable";
            this.ucolIsEnable.Name = "ucolIsEnable";
            this.ucolIsEnable.OptionsColumn.AllowEdit = false;
            // 
            // ucolCreatedBy
            // 
            this.ucolCreatedBy.Caption = "Người Tạo";
            this.ucolCreatedBy.ColumnEdit = this.rlokPersonnel;
            this.ucolCreatedBy.FieldName = "CreatedBy";
            this.ucolCreatedBy.Name = "ucolCreatedBy";
            this.ucolCreatedBy.OptionsColumn.AllowEdit = false;
            this.ucolCreatedBy.Visible = true;
            this.ucolCreatedBy.VisibleIndex = 2;
            // 
            // rlokPersonnel
            // 
            this.rlokPersonnel.AutoHeight = false;
            this.rlokPersonnel.Name = "rlokPersonnel";
            this.rlokPersonnel.NullText = "";
            // 
            // ucolCreatedDate
            // 
            this.ucolCreatedDate.Caption = "Ngày Tạo";
            this.ucolCreatedDate.FieldName = "CreatedDate";
            this.ucolCreatedDate.Name = "ucolCreatedDate";
            this.ucolCreatedDate.OptionsColumn.AllowEdit = false;
            this.ucolCreatedDate.Visible = true;
            this.ucolCreatedDate.VisibleIndex = 3;
            // 
            // ucolModifiedBy
            // 
            this.ucolModifiedBy.Caption = "Người Cập Nhật";
            this.ucolModifiedBy.ColumnEdit = this.rlokPersonnel;
            this.ucolModifiedBy.FieldName = "ModifiedBy";
            this.ucolModifiedBy.Name = "ucolModifiedBy";
            this.ucolModifiedBy.OptionsColumn.AllowEdit = false;
            this.ucolModifiedBy.Visible = true;
            this.ucolModifiedBy.VisibleIndex = 4;
            // 
            // ucolModifiedDate
            // 
            this.ucolModifiedDate.Caption = "Ngày Cập Nhật";
            this.ucolModifiedDate.FieldName = "ModifiedDate";
            this.ucolModifiedDate.Name = "ucolModifiedDate";
            this.ucolModifiedDate.OptionsColumn.AllowEdit = false;
            this.ucolModifiedDate.Visible = true;
            this.ucolModifiedDate.VisibleIndex = 5;
            // 
            // ucolRoles
            // 
            this.ucolRoles.FieldName = "Roles";
            this.ucolRoles.Name = "ucolRoles";
            this.ucolRoles.OptionsColumn.AllowEdit = false;
            // 
            // ucolAccounts
            // 
            this.ucolAccounts.FieldName = "Accounts";
            this.ucolAccounts.Name = "ucolAccounts";
            this.ucolAccounts.OptionsColumn.AllowEdit = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(550, 363);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gctPermission;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(530, 343);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dkpPermission});
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
            // dkpPermission
            // 
            this.dkpPermission.Controls.Add(this.dockPanel1_Container);
            this.dkpPermission.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dkpPermission.ID = new System.Guid("cde2e7b0-53b7-45c5-ad36-2028da17e497");
            this.dkpPermission.Location = new System.Drawing.Point(0, 26);
            this.dkpPermission.Name = "dkpPermission";
            this.dkpPermission.Options.AllowDockBottom = false;
            this.dkpPermission.Options.AllowDockFill = false;
            this.dkpPermission.Options.AllowDockRight = false;
            this.dkpPermission.Options.AllowDockTop = false;
            this.dkpPermission.Options.AllowFloating = false;
            this.dkpPermission.Options.FloatOnDblClick = false;
            this.dkpPermission.Options.ShowAutoHideButton = false;
            this.dkpPermission.Options.ShowCloseButton = false;
            this.dkpPermission.Options.ShowMaximizeButton = false;
            this.dkpPermission.OriginalSize = new System.Drawing.Size(450, 200);
            this.dkpPermission.Size = new System.Drawing.Size(450, 363);
            this.dkpPermission.Text = "Phân quyền";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.lctRole);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 25);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(442, 334);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // lctRole
            // 
            this.lctRole.Controls.Add(this.lblMessage);
            this.lctRole.Controls.Add(this.chkIsEnable);
            this.lctRole.Controls.Add(this.btnrCancel);
            this.lctRole.Controls.Add(this.btnrSave);
            this.lctRole.Controls.Add(this.trlFeature);
            this.lctRole.Controls.Add(this.mmeDescription);
            this.lctRole.Controls.Add(this.txtName);
            this.lctRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctRole.Location = new System.Drawing.Point(0, 0);
            this.lctRole.Name = "lctRole";
            this.lctRole.Root = this.layoutControlGroup2;
            this.lctRole.Size = new System.Drawing.Size(442, 334);
            this.lctRole.TabIndex = 0;
            this.lctRole.Text = "layoutControl1";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblMessage.Location = new System.Drawing.Point(380, 277);
            this.lblMessage.MinimumSize = new System.Drawing.Size(0, 18);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 18);
            this.lblMessage.StyleController = this.lctRole;
            this.lblMessage.TabIndex = 11;
            this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
            // 
            // chkIsEnable
            // 
            this.chkIsEnable.Location = new System.Drawing.Point(12, 277);
            this.chkIsEnable.Name = "chkIsEnable";
            this.chkIsEnable.Properties.Caption = "Kích hoạt";
            this.chkIsEnable.Size = new System.Drawing.Size(364, 19);
            this.chkIsEnable.StyleController = this.lctRole;
            this.chkIsEnable.TabIndex = 10;
            // 
            // btnrCancel
            // 
            this.btnrCancel.Image = global::QuanLyBanHang.Properties.Resources.Cancel_16x16;
            this.btnrCancel.Location = new System.Drawing.Point(366, 300);
            this.btnrCancel.Name = "btnrCancel";
            this.btnrCancel.Size = new System.Drawing.Size(64, 22);
            this.btnrCancel.StyleController = this.lctRole;
            this.btnrCancel.TabIndex = 9;
            this.btnrCancel.Text = "Hủy bỏ";
            this.btnrCancel.Click += new System.EventHandler(this.btnrCancel_Click);
            // 
            // btnrSave
            // 
            this.btnrSave.Image = global::QuanLyBanHang.Properties.Resources.SaveTo_16x16;
            this.btnrSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnrSave.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btnrSave.Location = new System.Drawing.Point(301, 300);
            this.btnrSave.Name = "btnrSave";
            this.btnrSave.Size = new System.Drawing.Size(61, 22);
            this.btnrSave.StyleController = this.lctRole;
            this.btnrSave.TabIndex = 7;
            this.btnrSave.Text = "Lưu lại";
            this.btnrSave.Click += new System.EventHandler(this.btnrSave_Click);
            // 
            // trlFeature
            // 
            this.trlFeature.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colVN,
            this.colEN,
            this.colIsAdd,
            this.colIsEdit,
            this.colIsDelete,
            this.colxUserFeatures});
            this.trlFeature.DataSource = this.bindingSource1;
            this.trlFeature.KeyFieldName = "KeyID";
            this.trlFeature.Location = new System.Drawing.Point(12, 86);
            this.trlFeature.Name = "trlFeature";
            this.trlFeature.ParentFieldName = "IDGroup";
            this.trlFeature.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rchkChecked});
            this.trlFeature.Size = new System.Drawing.Size(418, 187);
            this.trlFeature.TabIndex = 6;
            this.trlFeature.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.trlFeature_BeforeCheckNode);
            this.trlFeature.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.trlFeature_CellValueChanging);
            // 
            // colVN
            // 
            this.colVN.Caption = "Chức năng";
            this.colVN.FieldName = "VN";
            this.colVN.Name = "colVN";
            this.colVN.OptionsColumn.AllowEdit = false;
            this.colVN.Width = 66;
            // 
            // colEN
            // 
            this.colEN.Caption = "Fuction";
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
            this.colIsAdd.MinWidth = 75;
            this.colIsAdd.Name = "colIsAdd";
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
            this.colIsEdit.MinWidth = 75;
            this.colIsEdit.Name = "colIsEdit";
            // 
            // colIsDelete
            // 
            this.colIsDelete.Caption = "Xóa";
            this.colIsDelete.ColumnEdit = this.rchkChecked;
            this.colIsDelete.FieldName = "IsDelete";
            this.colIsDelete.MinWidth = 75;
            this.colIsDelete.Name = "colIsDelete";
            // 
            // colxUserFeatures
            // 
            this.colxUserFeatures.FieldName = "xUserFeatures";
            this.colxUserFeatures.Name = "colxUserFeatures";
            this.colxUserFeatures.OptionsColumn.AllowEdit = false;
            this.colxUserFeatures.Width = 67;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.xFeature);
            // 
            // mmeDescription
            // 
            this.mmeDescription.Location = new System.Drawing.Point(54, 36);
            this.mmeDescription.Name = "mmeDescription";
            this.mmeDescription.Size = new System.Drawing.Size(376, 46);
            this.mmeDescription.StyleController = this.lctRole;
            this.mmeDescription.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(54, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(376, 20);
            this.txtName.StyleController = this.lctRole;
            this.txtName.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciName,
            this.lciDescription,
            this.layoutControlItem4,
            this.lciCancel,
            this.lciSave,
            this.layoutControlItem2,
            this.lciEmtySpace,
            this.layoutControlItem3});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(442, 334);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lciName
            // 
            this.lciName.Control = this.txtName;
            this.lciName.Location = new System.Drawing.Point(0, 0);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(422, 24);
            this.lciName.Text = "Tên:";
            this.lciName.TextSize = new System.Drawing.Size(39, 13);
            // 
            // lciDescription
            // 
            this.lciDescription.Control = this.mmeDescription;
            this.lciDescription.Location = new System.Drawing.Point(0, 24);
            this.lciDescription.Name = "lciDescription";
            this.lciDescription.Size = new System.Drawing.Size(422, 50);
            this.lciDescription.Text = "Ghi chú:";
            this.lciDescription.TextSize = new System.Drawing.Size(39, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.trlFeature;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(422, 191);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // lciCancel
            // 
            this.lciCancel.Control = this.btnrCancel;
            this.lciCancel.Location = new System.Drawing.Point(354, 288);
            this.lciCancel.Name = "lciCancel";
            this.lciCancel.Size = new System.Drawing.Size(68, 26);
            this.lciCancel.Text = "Lưu";
            this.lciCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lciCancel.TextVisible = false;
            // 
            // lciSave
            // 
            this.lciSave.Control = this.btnrSave;
            this.lciSave.Location = new System.Drawing.Point(289, 288);
            this.lciSave.Name = "lciSave";
            this.lciSave.Size = new System.Drawing.Size(65, 26);
            this.lciSave.Text = "Lưu";
            this.lciSave.TextSize = new System.Drawing.Size(0, 0);
            this.lciSave.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkIsEnable;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 265);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(368, 23);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // lciEmtySpace
            // 
            this.lciEmtySpace.AllowHotTrack = false;
            this.lciEmtySpace.Location = new System.Drawing.Point(0, 288);
            this.lciEmtySpace.Name = "lciEmtySpace";
            this.lciEmtySpace.Size = new System.Drawing.Size(289, 26);
            this.lciEmtySpace.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lblMessage;
            this.layoutControlItem3.Location = new System.Drawing.Point(368, 265);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(54, 23);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 410);
            this.Controls.Add(this.lctPermission);
            this.Controls.Add(this.dkpPermission);
            this.Name = "frmPermission";
            this.Text = "Phân quyền";
            this.Load += new System.EventHandler(this.frmPermission_Load);
            this.Controls.SetChildIndex(this.dkpPermission, 0);
            this.Controls.SetChildIndex(this.lctPermission, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPermission)).EndInit();
            this.lctPermission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dkpPermission.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lctRole)).EndInit();
            this.lctRole.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsEnable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trlFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rchkChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmtySpace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctPermission;
        private DevExpress.XtraGrid.GridControl gctPermission;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermission;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dkpPermission;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraLayout.LayoutControl lctRole;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SimpleButton btnrSave;
        private DevExpress.XtraTreeList.TreeList trlFeature;
        private DevExpress.XtraEditors.MemoEdit mmeDescription;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraLayout.LayoutControlItem lciDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem lciSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokPersonnel;
        private DevExpress.XtraEditors.CheckEdit chkIsEnable;
        private DevExpress.XtraEditors.SimpleButton btnrCancel;
        private DevExpress.XtraLayout.LayoutControlItem lciCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem lciEmtySpace;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn ucolKeyID;
        private DevExpress.XtraGrid.Columns.GridColumn ucolName;
        private DevExpress.XtraGrid.Columns.GridColumn ucolDescription;
        private DevExpress.XtraGrid.Columns.GridColumn ucolIsEnable;
        private DevExpress.XtraGrid.Columns.GridColumn ucolCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn ucolCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn ucolModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn ucolModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn ucolRoles;
        private DevExpress.XtraGrid.Columns.GridColumn ucolAccounts;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colVN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsAdd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colxUserFeatures;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rchkChecked;
    }
}