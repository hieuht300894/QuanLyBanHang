namespace QuanLyBanHang
{
    partial class frmChangePassword
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lctDoiMatKhau = new DevExpress.XtraLayout.LayoutControl();
            this.pteIcon = new DevExpress.XtraEditors.PictureEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.bteConfirmPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.bteNewPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.bteOldPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOldPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciNewPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciConfirmPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciLuu = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciHuy = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lctDoiMatKhau)).BeginInit();
            this.lctDoiMatKhau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pteIcon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteConfirmPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLuu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lctDoiMatKhau
            // 
            this.lctDoiMatKhau.Controls.Add(this.pteIcon);
            this.lctDoiMatKhau.Controls.Add(this.btnCancel);
            this.lctDoiMatKhau.Controls.Add(this.btnSave);
            this.lctDoiMatKhau.Controls.Add(this.bteConfirmPassword);
            this.lctDoiMatKhau.Controls.Add(this.bteNewPassword);
            this.lctDoiMatKhau.Controls.Add(this.bteOldPassword);
            this.lctDoiMatKhau.Controls.Add(this.txtUserName);
            this.lctDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctDoiMatKhau.Location = new System.Drawing.Point(0, 0);
            this.lctDoiMatKhau.Name = "lctDoiMatKhau";
            this.lctDoiMatKhau.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(761, 221, 250, 350);
            this.lctDoiMatKhau.Root = this.layoutControlGroup2;
            this.lctDoiMatKhau.Size = new System.Drawing.Size(412, 149);
            this.lctDoiMatKhau.TabIndex = 0;
            // 
            // pteIcon
            // 
            this.pteIcon.EditValue = global::QuanLyBanHang.Properties.Resources.LoginIcon;
            this.pteIcon.Location = new System.Drawing.Point(12, 12);
            this.pteIcon.Name = "pteIcon";
            this.pteIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pteIcon.Properties.Appearance.Options.UseBackColor = true;
            this.pteIcon.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pteIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pteIcon.Size = new System.Drawing.Size(96, 125);
            this.pteIcon.StyleController = this.lctDoiMatKhau;
            this.pteIcon.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::QuanLyBanHang.Properties.Resources.Cancel_16x16;
            this.btnCancel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(288, 114);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 22);
            this.btnCancel.StyleController = this.lctDoiMatKhau;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::QuanLyBanHang.Properties.Resources.SaveTo_16x16;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(199, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 22);
            this.btnSave.StyleController = this.lctDoiMatKhau;
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // bteConfirmPassword
            // 
            this.bteConfirmPassword.Location = new System.Drawing.Point(187, 88);
            this.bteConfirmPassword.Name = "bteConfirmPassword";
            this.bteConfirmPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLyBanHang.Properties.Resources.Show_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.bteConfirmPassword.Properties.UseSystemPasswordChar = true;
            this.bteConfirmPassword.Size = new System.Drawing.Size(213, 22);
            this.bteConfirmPassword.StyleController = this.lctDoiMatKhau;
            this.bteConfirmPassword.TabIndex = 7;
            this.bteConfirmPassword.MouseLeave += new System.EventHandler(this.bteConfirmPassword_MouseLeave);
            this.bteConfirmPassword.MouseHover += new System.EventHandler(this.bteConfirmPassword_MouseHover);
            // 
            // bteNewPassword
            // 
            this.bteNewPassword.Location = new System.Drawing.Point(187, 62);
            this.bteNewPassword.Name = "bteNewPassword";
            this.bteNewPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLyBanHang.Properties.Resources.Show_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.bteNewPassword.Properties.UseSystemPasswordChar = true;
            this.bteNewPassword.Size = new System.Drawing.Size(213, 22);
            this.bteNewPassword.StyleController = this.lctDoiMatKhau;
            this.bteNewPassword.TabIndex = 6;
            this.bteNewPassword.MouseLeave += new System.EventHandler(this.bteNewPassword_MouseLeave);
            this.bteNewPassword.MouseHover += new System.EventHandler(this.bteNewPassword_MouseHover);
            // 
            // bteOldPassword
            // 
            this.bteOldPassword.Location = new System.Drawing.Point(187, 36);
            this.bteOldPassword.Name = "bteOldPassword";
            this.bteOldPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLyBanHang.Properties.Resources.Show_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.bteOldPassword.Properties.UseSystemPasswordChar = true;
            this.bteOldPassword.Size = new System.Drawing.Size(213, 22);
            this.bteOldPassword.StyleController = this.lctDoiMatKhau;
            this.bteOldPassword.TabIndex = 5;
            this.bteOldPassword.MouseLeave += new System.EventHandler(this.bteOldPassword_MouseLeave);
            this.bteOldPassword.MouseHover += new System.EventHandler(this.bteOldPassword_MouseHover);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(187, 12);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.AllowFocused = false;
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.White;
            this.txtUserName.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtUserName.Properties.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(213, 20);
            this.txtUserName.StyleController = this.lctDoiMatKhau;
            this.txtUserName.TabIndex = 4;
            this.txtUserName.TabStop = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciUserName,
            this.lciOldPassword,
            this.lciNewPassword,
            this.lciConfirmPassword,
            this.lciLuu,
            this.lciHuy,
            this.emptySpaceItem2,
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(412, 149);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // lciUserName
            // 
            this.lciUserName.Control = this.txtUserName;
            this.lciUserName.Location = new System.Drawing.Point(100, 0);
            this.lciUserName.Name = "lciUserName";
            this.lciUserName.Size = new System.Drawing.Size(292, 24);
            this.lciUserName.Text = "Tên đăng nhập";
            this.lciUserName.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciOldPassword
            // 
            this.lciOldPassword.Control = this.bteOldPassword;
            this.lciOldPassword.Location = new System.Drawing.Point(100, 24);
            this.lciOldPassword.Name = "lciOldPassword";
            this.lciOldPassword.Size = new System.Drawing.Size(292, 26);
            this.lciOldPassword.Text = "Mật khẩu cũ";
            this.lciOldPassword.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciNewPassword
            // 
            this.lciNewPassword.Control = this.bteNewPassword;
            this.lciNewPassword.Location = new System.Drawing.Point(100, 50);
            this.lciNewPassword.Name = "lciNewPassword";
            this.lciNewPassword.Size = new System.Drawing.Size(292, 26);
            this.lciNewPassword.Text = "Mật khẩu mới";
            this.lciNewPassword.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciConfirmPassword
            // 
            this.lciConfirmPassword.Control = this.bteConfirmPassword;
            this.lciConfirmPassword.Location = new System.Drawing.Point(100, 76);
            this.lciConfirmPassword.Name = "lciConfirmPassword";
            this.lciConfirmPassword.Size = new System.Drawing.Size(292, 26);
            this.lciConfirmPassword.Text = "Xác thực";
            this.lciConfirmPassword.TextSize = new System.Drawing.Size(72, 13);
            // 
            // lciLuu
            // 
            this.lciLuu.Control = this.btnSave;
            this.lciLuu.Location = new System.Drawing.Point(187, 102);
            this.lciLuu.Name = "lciLuu";
            this.lciLuu.Size = new System.Drawing.Size(89, 27);
            this.lciLuu.TextSize = new System.Drawing.Size(0, 0);
            this.lciLuu.TextVisible = false;
            // 
            // lciHuy
            // 
            this.lciHuy.Control = this.btnCancel;
            this.lciHuy.Location = new System.Drawing.Point(276, 102);
            this.lciHuy.Name = "lciHuy";
            this.lciHuy.Size = new System.Drawing.Size(116, 27);
            this.lciHuy.TextSize = new System.Drawing.Size(0, 0);
            this.lciHuy.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(100, 102);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(87, 27);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pteIcon;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(100, 129);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 149);
            this.ControlBox = false;
            this.Controls.Add(this.lctDoiMatKhau);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChangePassword";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoiMK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lctDoiMatKhau)).EndInit();
            this.lctDoiMatKhau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pteIcon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteConfirmPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciLuu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciHuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctDoiMatKhau;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem lciUserName;
        private DevExpress.XtraEditors.ButtonEdit bteConfirmPassword;
        private DevExpress.XtraEditors.ButtonEdit bteOldPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciOldPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciConfirmPassword;
        private DevExpress.XtraEditors.PictureEdit pteIcon;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.ButtonEdit bteNewPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciNewPassword;
        private DevExpress.XtraLayout.LayoutControlItem lciLuu;
        private DevExpress.XtraLayout.LayoutControlItem lciHuy;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}