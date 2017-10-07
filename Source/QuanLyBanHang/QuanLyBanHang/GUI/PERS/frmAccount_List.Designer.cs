namespace QuanLyBanHang.GUI.PER
{
    partial class frmAccount_List
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
            this.lctAccountList = new DevExpress.XtraLayout.LayoutControl();
            this.gctAccountList = new DevExpress.XtraGrid.GridControl();
            this.grvAccountList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rlokPersonnel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colIDPersonnel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsServer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDPermission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colePersonnel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colxPermission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctAccountList)).BeginInit();
            this.lctAccountList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctAccountList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccountList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // lctAccountList
            // 
            this.lctAccountList.Controls.Add(this.gctAccountList);
            this.lctAccountList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctAccountList.Location = new System.Drawing.Point(0, 24);
            this.lctAccountList.Name = "lctAccountList";
            this.lctAccountList.Root = this.layoutControlGroup1;
            this.lctAccountList.Size = new System.Drawing.Size(953, 507);
            this.lctAccountList.TabIndex = 4;
            this.lctAccountList.Text = "layoutControl1";
            // 
            // gctAccountList
            // 
            this.gctAccountList.DataSource = this.bindingSource1;
            this.gctAccountList.Location = new System.Drawing.Point(12, 12);
            this.gctAccountList.MainView = this.grvAccountList;
            this.gctAccountList.Name = "gctAccountList";
            this.gctAccountList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlokPersonnel,
            this.repositoryItemCheckEdit1,
            this.repositoryItemDateEdit1});
            this.gctAccountList.Size = new System.Drawing.Size(929, 483);
            this.gctAccountList.TabIndex = 4;
            this.gctAccountList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAccountList});
            this.gctAccountList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gctAccountList_MouseClick);
            // 
            // grvAccountList
            // 
            this.grvAccountList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDPersonnel,
            this.colIDAgency,
            this.colUserName,
            this.colPassword,
            this.colIsServer,
            this.colIDPermission,
            this.colIsEnable,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colModifiedBy,
            this.colModifiedDate,
            this.colePersonnel,
            this.colxPermission});
            this.grvAccountList.GridControl = this.gctAccountList;
            this.grvAccountList.Name = "grvAccountList";
            this.grvAccountList.DoubleClick += new System.EventHandler(this.grvAccountList_DoubleClick);
            // 
            // rlokPersonnel
            // 
            this.rlokPersonnel.AutoHeight = false;
            this.rlokPersonnel.Name = "rlokPersonnel";
            this.rlokPersonnel.NullText = "";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(953, 507);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gctAccountList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(933, 487);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.xAccount);
            // 
            // colIDPersonnel
            // 
            this.colIDPersonnel.Caption = "Nhân viên";
            this.colIDPersonnel.ColumnEdit = this.rlokPersonnel;
            this.colIDPersonnel.FieldName = "IDPersonnel";
            this.colIDPersonnel.Name = "colIDPersonnel";
            this.colIDPersonnel.OptionsColumn.AllowEdit = false;
            this.colIDPersonnel.Visible = true;
            this.colIDPersonnel.VisibleIndex = 0;
            // 
            // colIDAgency
            // 
            this.colIDAgency.FieldName = "IDAgency";
            this.colIDAgency.Name = "colIDAgency";
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Tài khoản";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            // 
            // colPassword
            // 
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            // 
            // colIsServer
            // 
            this.colIsServer.Caption = "Máy chủ";
            this.colIsServer.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsServer.FieldName = "IsServer";
            this.colIsServer.Name = "colIsServer";
            this.colIsServer.OptionsColumn.AllowEdit = false;
            this.colIsServer.Visible = true;
            this.colIsServer.VisibleIndex = 6;
            // 
            // colIDPermission
            // 
            this.colIDPermission.FieldName = "IDPermission";
            this.colIDPermission.Name = "colIDPermission";
            // 
            // colIsEnable
            // 
            this.colIsEnable.FieldName = "IsEnable";
            this.colIsEnable.Name = "colIsEnable";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "Người tạo";
            this.colCreatedBy.ColumnEdit = this.rlokPersonnel;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 2;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 3;
            // 
            // colModifiedBy
            // 
            this.colModifiedBy.Caption = "Người cập nhật";
            this.colModifiedBy.ColumnEdit = this.rlokPersonnel;
            this.colModifiedBy.FieldName = "ModifiedBy";
            this.colModifiedBy.Name = "colModifiedBy";
            this.colModifiedBy.OptionsColumn.AllowEdit = false;
            this.colModifiedBy.Visible = true;
            this.colModifiedBy.VisibleIndex = 4;
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.Caption = "Ngày cập nhật";
            this.colModifiedDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.OptionsColumn.AllowEdit = false;
            this.colModifiedDate.Visible = true;
            this.colModifiedDate.VisibleIndex = 5;
            // 
            // colePersonnel
            // 
            this.colePersonnel.FieldName = "ePersonnel";
            this.colePersonnel.Name = "colePersonnel";
            // 
            // colxPermission
            // 
            this.colxPermission.FieldName = "xPermission";
            this.colxPermission.Name = "colxPermission";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Mask.EditMask = "dd/MM/yyyy";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // frmAccount_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 531);
            this.Controls.Add(this.lctAccountList);
            this.Name = "frmAccount_List";
            this.Text = "Danh sách tài khoản";
            this.Load += new System.EventHandler(this.frmAccount_List_Load);
            this.Controls.SetChildIndex(this.lctAccountList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctAccountList)).EndInit();
            this.lctAccountList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctAccountList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAccountList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctAccountList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gctAccountList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAccountList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokPersonnel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colIDPersonnel;
        private DevExpress.XtraGrid.Columns.GridColumn colIDAgency;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colIsServer;
        private DevExpress.XtraGrid.Columns.GridColumn colIDPermission;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnable;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colePersonnel;
        private DevExpress.XtraGrid.Columns.GridColumn colxPermission;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}