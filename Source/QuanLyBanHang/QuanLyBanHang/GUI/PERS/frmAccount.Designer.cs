namespace QuanLyBanHang.GUI.PER
{
    partial class frmAccount
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lctAccount = new DevExpress.XtraLayout.LayoutControl();
            this.chkServer = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsEnable = new DevExpress.XtraEditors.CheckEdit();
            this.lokPermission = new DevExpress.XtraEditors.LookUpEdit();
            this.lokPersonnel = new DevExpress.XtraEditors.LookUpEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.btePassword = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPersonnel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPermission = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctAccount)).BeginInit();
            this.lctAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsEnable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokPermission.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokPersonnel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPersonnel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lctAccount
            // 
            this.lctAccount.Controls.Add(this.chkServer);
            this.lctAccount.Controls.Add(this.chkIsEnable);
            this.lctAccount.Controls.Add(this.lokPermission);
            this.lctAccount.Controls.Add(this.lokPersonnel);
            this.lctAccount.Controls.Add(this.txtUserName);
            this.lctAccount.Controls.Add(this.btePassword);
            this.lctAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctAccount.Location = new System.Drawing.Point(0, 26);
            this.lctAccount.Name = "lctAccount";
            this.lctAccount.Root = this.layoutControlGroup1;
            this.lctAccount.Size = new System.Drawing.Size(584, 146);
            this.lctAccount.TabIndex = 4;
            this.lctAccount.Text = "layoutControl1";
            // 
            // chkServer
            // 
            this.chkServer.Location = new System.Drawing.Point(295, 112);
            this.chkServer.Name = "chkServer";
            this.chkServer.Properties.Caption = "Máy chủ";
            this.chkServer.Size = new System.Drawing.Size(277, 19);
            this.chkServer.StyleController = this.lctAccount;
            this.chkServer.TabIndex = 9;
            // 
            // chkIsEnable
            // 
            this.chkIsEnable.Location = new System.Drawing.Point(12, 112);
            this.chkIsEnable.Name = "chkIsEnable";
            this.chkIsEnable.Properties.Caption = "Kích hoạt";
            this.chkIsEnable.Size = new System.Drawing.Size(279, 19);
            this.chkIsEnable.StyleController = this.lctAccount;
            this.chkIsEnable.TabIndex = 8;
            // 
            // lokPermission
            // 
            this.lokPermission.Location = new System.Drawing.Point(87, 88);
            this.lokPermission.Name = "lokPermission";
            this.lokPermission.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokPermission.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Tên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Ghi Chú")});
            this.lokPermission.Properties.NullText = "";
            this.lokPermission.Size = new System.Drawing.Size(485, 20);
            this.lokPermission.StyleController = this.lctAccount;
            this.lokPermission.TabIndex = 7;
            // 
            // lokPersonnel
            // 
            this.lokPersonnel.Location = new System.Drawing.Point(87, 12);
            this.lokPersonnel.Name = "lokPersonnel";
            this.lokPersonnel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLyBanHang.Properties.Resources.Add_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lokPersonnel.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Họ Tên"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Ghi chú")});
            this.lokPersonnel.Properties.NullText = "";
            this.lokPersonnel.Size = new System.Drawing.Size(485, 22);
            this.lokPersonnel.StyleController = this.lctAccount;
            this.lokPersonnel.TabIndex = 6;
            this.lokPersonnel.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lokPersonnel_ButtonClick);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(87, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUserName.Size = new System.Drawing.Size(485, 20);
            this.txtUserName.StyleController = this.lctAccount;
            this.txtUserName.TabIndex = 4;
            // 
            // btePassword
            // 
            this.btePassword.Location = new System.Drawing.Point(87, 62);
            this.btePassword.Name = "btePassword";
            this.btePassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLyBanHang.Properties.Resources.Show_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btePassword.Properties.UseSystemPasswordChar = true;
            this.btePassword.Properties.MouseHover += new System.EventHandler(this.txtPassword_Properties_MouseHover);
            this.btePassword.Properties.MouseLeave += new System.EventHandler(this.txtPassword_Properties_MouseLeave);
            this.btePassword.Size = new System.Drawing.Size(485, 22);
            this.btePassword.StyleController = this.lctAccount;
            this.btePassword.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUserName,
            this.lciPassword,
            this.lciPersonnel,
            this.lciPermission,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 146);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.txtUserName;
            this.lciUserName.Location = new System.Drawing.Point(0, 26);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(564, 24);
            this.lciUserName.Text = "Tên đăng nhập";
            this.lciUserName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciPassword
            // 
            this.lciPassword.Control = this.btePassword;
            this.lciPassword.Location = new System.Drawing.Point(0, 50);
            this.lciPassword.Name = "lciPassword";
            this.lciPassword.Size = new System.Drawing.Size(564, 26);
            this.lciPassword.Text = "Mật khẩu";
            this.lciPassword.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciPersonnel
            // 
            this.lciPersonnel.Control = this.lokPersonnel;
            this.lciPersonnel.Location = new System.Drawing.Point(0, 0);
            this.lciPersonnel.Name = "lciPersonnel";
            this.lciPersonnel.Size = new System.Drawing.Size(564, 26);
            this.lciPersonnel.Text = "Nhân viên";
            this.lciPersonnel.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciPermission
            // 
            this.lciPermission.Control = this.lokPermission;
            this.lciPermission.Location = new System.Drawing.Point(0, 76);
            this.lciPermission.Name = "lciPermission";
            this.lciPermission.Size = new System.Drawing.Size(564, 24);
            this.lciPermission.Text = "Phân quyền";
            this.lciPermission.TextSize = new System.Drawing.Size(72, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkIsEnable;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 100);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(283, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkServer;
            this.layoutControlItem1.Location = new System.Drawing.Point(283, 100);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(281, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 191);
            this.Controls.Add(this.lctAccount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAccount";
            this.Text = "Thêm mới tài khoản";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            this.Controls.SetChildIndex(this.lctAccount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctAccount)).EndInit();
            this.lctAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsEnable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokPermission.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokPersonnel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPersonnel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctAccount;
        private DevExpress.XtraEditors.LookUpEdit lokPersonnel;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraLayout.LayoutControlItem lciPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciPersonnel;
        private DevExpress.XtraEditors.CheckEdit chkIsEnable;
        private DevExpress.XtraEditors.LookUpEdit lokPermission;
        private DevExpress.XtraLayout.LayoutControlItem lciPermission;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.ButtonEdit btePassword;
        private DevExpress.XtraEditors.CheckEdit chkServer;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}