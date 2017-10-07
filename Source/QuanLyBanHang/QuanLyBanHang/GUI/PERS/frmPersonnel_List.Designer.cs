namespace QuanLyBanHang.GUI.PER
{
    partial class frmPersonnel_List
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
            this.lctPersonnel = new DevExpress.XtraLayout.LayoutControl();
            this.gctPersonnelList = new DevExpress.XtraGrid.GridControl();
            this.grvPersonnelList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKeyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDAgency = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsEnable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokPersonnel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPersonnel)).BeginInit();
            this.lctPersonnel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctPersonnelList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonnelList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // lctPersonnel
            // 
            this.lctPersonnel.Controls.Add(this.gctPersonnelList);
            this.lctPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctPersonnel.Location = new System.Drawing.Point(0, 24);
            this.lctPersonnel.Name = "lctPersonnel";
            this.lctPersonnel.Root = this.lcgMain;
            this.lctPersonnel.Size = new System.Drawing.Size(918, 420);
            this.lctPersonnel.TabIndex = 4;
            this.lctPersonnel.Text = "layoutControl1";
            // 
            // gctPersonnelList
            // 
            this.gctPersonnelList.DataSource = this.bindingSource1;
            this.gctPersonnelList.Location = new System.Drawing.Point(12, 12);
            this.gctPersonnelList.MainView = this.grvPersonnelList;
            this.gctPersonnelList.Name = "gctPersonnelList";
            this.gctPersonnelList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlokPersonnel});
            this.gctPersonnelList.Size = new System.Drawing.Size(894, 396);
            this.gctPersonnelList.TabIndex = 4;
            this.gctPersonnelList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPersonnelList});
            this.gctPersonnelList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gctPersonnelList_MouseClick);
            // 
            // grvPersonnelList
            // 
            this.grvPersonnelList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKeyID,
            this.colIDAgency,
            this.colCode,
            this.colFullName,
            this.colAddress,
            this.colEmail,
            this.colPhone,
            this.colDescription,
            this.colIsEnable,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colModifiedBy,
            this.colModifiedDate,
            this.colAccount});
            this.grvPersonnelList.GridControl = this.gctPersonnelList;
            this.grvPersonnelList.Name = "grvPersonnelList";
            this.grvPersonnelList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvPersonnelList.DoubleClick += new System.EventHandler(this.grvPersonnelList_DoubleClick);
            // 
            // colKeyID
            // 
            this.colKeyID.FieldName = "KeyID";
            this.colKeyID.Name = "colKeyID";
            this.colKeyID.OptionsColumn.AllowEdit = false;
            // 
            // colIDAgency
            // 
            this.colIDAgency.FieldName = "IDAgency";
            this.colIDAgency.Name = "colIDAgency";
            this.colIDAgency.OptionsColumn.AllowEdit = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Họ Tên";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.OptionsColumn.AllowEdit = false;
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "Địa Chỉ";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 2;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 3;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "Điện Thoại";
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 4;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Ghi Chú";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.OptionsColumn.AllowEdit = false;
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            // 
            // colIsEnable
            // 
            this.colIsEnable.FieldName = "IsEnable";
            this.colIsEnable.Name = "colIsEnable";
            this.colIsEnable.OptionsColumn.AllowEdit = false;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "Người Tạo";
            this.colCreatedBy.ColumnEdit = this.rlokPersonnel;
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 6;
            // 
            // rlokPersonnel
            // 
            this.rlokPersonnel.AutoHeight = false;
            this.rlokPersonnel.Name = "rlokPersonnel";
            this.rlokPersonnel.NullText = "";
            this.rlokPersonnel.ReadOnly = true;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày Tạo";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 7;
            // 
            // colModifiedBy
            // 
            this.colModifiedBy.Caption = "Người Cập Nhật";
            this.colModifiedBy.ColumnEdit = this.rlokPersonnel;
            this.colModifiedBy.FieldName = "ModifiedBy";
            this.colModifiedBy.Name = "colModifiedBy";
            this.colModifiedBy.OptionsColumn.AllowEdit = false;
            this.colModifiedBy.Visible = true;
            this.colModifiedBy.VisibleIndex = 8;
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.Caption = "Ngày Cập Nhật";
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            this.colModifiedDate.OptionsColumn.AllowEdit = false;
            this.colModifiedDate.Visible = true;
            this.colModifiedDate.VisibleIndex = 9;
            // 
            // colAccount
            // 
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.OptionsColumn.AllowEdit = false;
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Size = new System.Drawing.Size(918, 420);
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gctPersonnelList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(898, 400);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.xPersonnel);
            // 
            // frmPersonnel_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 444);
            this.Controls.Add(this.lctPersonnel);
            this.Name = "frmPersonnel_List";
            this.Text = "Danh sách nhân viên";
            this.Load += new System.EventHandler(this.frmNhanVien_List_Load);
            this.Controls.SetChildIndex(this.lctPersonnel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPersonnel)).EndInit();
            this.lctPersonnel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctPersonnelList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPersonnelList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctPersonnel;
        private DevExpress.XtraGrid.GridControl gctPersonnelList;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPersonnelList;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokPersonnel;
        private DevExpress.XtraGrid.Columns.GridColumn colKeyID;
        private DevExpress.XtraGrid.Columns.GridColumn colIDAgency;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colIsEnable;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}