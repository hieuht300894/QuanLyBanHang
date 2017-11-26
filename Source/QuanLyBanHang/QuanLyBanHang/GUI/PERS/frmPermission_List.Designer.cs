namespace QuanLyBanHang.GUI.PERS
{
    partial class frmPermission_List
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
            this.gctPermission = new DevExpress.XtraGrid.GridControl();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grvPermission = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rdteNgay = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rlokPersonnel = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPersonnel)).BeginInit();
            this.lctPersonnel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lctPersonnel
            // 
            this.lctPersonnel.Controls.Add(this.gctPermission);
            this.lctPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctPersonnel.Location = new System.Drawing.Point(0, 24);
            this.lctPersonnel.Name = "lctPersonnel";
            this.lctPersonnel.Root = this.lcgMain;
            this.lctPersonnel.Size = new System.Drawing.Size(918, 397);
            this.lctPersonnel.TabIndex = 4;
            this.lctPersonnel.Text = "layoutControl1";
            // 
            // gctPermission
            // 
            this.gctPermission.DataSource = this.bindingSource1;
            this.gctPermission.Location = new System.Drawing.Point(12, 12);
            this.gctPermission.MainView = this.grvPermission;
            this.gctPermission.Name = "gctPermission";
            this.gctPermission.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rlokPersonnel,
            this.rdteNgay});
            this.gctPermission.Size = new System.Drawing.Size(894, 373);
            this.gctPermission.TabIndex = 4;
            this.gctPermission.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPermission});
       
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(EntityModel.DataModel.xPermission);
            // 
            // grvPermission
            // 
            this.grvPermission.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grvPermission.GridControl = this.gctPermission;
            this.grvPermission.Name = "grvPermission";
            this.grvPermission.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên quyền";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày tạo";
            this.gridColumn2.ColumnEdit = this.rdteNgay;
            this.gridColumn2.FieldName = "CreatedDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Người tạo";
            this.gridColumn3.ColumnEdit = this.rlokPersonnel;
            this.gridColumn3.FieldName = "CreatedBy";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ngày cập nhật";
            this.gridColumn4.ColumnEdit = this.rdteNgay;
            this.gridColumn4.FieldName = "ModifiedDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // rdteNgay
            // 
            this.rdteNgay.AutoHeight = false;
            this.rdteNgay.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdteNgay.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rdteNgay.Name = "rdteNgay";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Người cập nhật";
            this.gridColumn5.ColumnEdit = this.rlokPersonnel;
            this.gridColumn5.FieldName = "ModifiedBy";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ghi chú";
            this.gridColumn6.FieldName = "Description";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // rlokPersonnel
            // 
            this.rlokPersonnel.AutoHeight = false;
            this.rlokPersonnel.Name = "rlokPersonnel";
            this.rlokPersonnel.NullText = "";
            this.rlokPersonnel.ReadOnly = true;
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgMain.Location = new System.Drawing.Point(0, 0);
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Size = new System.Drawing.Size(918, 397);
            this.lcgMain.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gctPermission;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(898, 377);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmPermission_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 444);
            this.Controls.Add(this.lctPersonnel);
            this.Name = "frmPermission_List";
            this.Text = "Danh sách quyền";
            this.Controls.SetChildIndex(this.lctPersonnel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPersonnel)).EndInit();
            this.lctPersonnel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdteNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rlokPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctPersonnel;
        private DevExpress.XtraGrid.GridControl gctPermission;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPermission;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rlokPersonnel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit rdteNgay;
    }
}