namespace QuanLyBanHang.GUI.PER
{
    partial class frmPersonnel
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
            this.lctPersonnel = new DevExpress.XtraLayout.LayoutControl();
            this.mmeDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtFullName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPersonnelCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFullName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDescription = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPersonnel)).BeginInit();
            this.lctPersonnel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPersonnelCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // lctPersonnel
            // 
            this.lctPersonnel.Controls.Add(this.mmeDescription);
            this.lctPersonnel.Controls.Add(this.txtEmail);
            this.lctPersonnel.Controls.Add(this.txtPhone);
            this.lctPersonnel.Controls.Add(this.txtAddress);
            this.lctPersonnel.Controls.Add(this.txtFullName);
            this.lctPersonnel.Controls.Add(this.txtCode);
            this.lctPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctPersonnel.Location = new System.Drawing.Point(0, 24);
            this.lctPersonnel.Name = "lctPersonnel";
            this.lctPersonnel.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(539, 44, 250, 350);
            this.lctPersonnel.Root = this.layoutControlGroup1;
            this.lctPersonnel.Size = new System.Drawing.Size(584, 214);
            this.lctPersonnel.TabIndex = 4;
            this.lctPersonnel.Text = "layoutControl1";
            // 
            // mmeDescription
            // 
            this.mmeDescription.Location = new System.Drawing.Point(79, 132);
            this.mmeDescription.Name = "mmeDescription";
            this.mmeDescription.Size = new System.Drawing.Size(493, 70);
            this.mmeDescription.StyleController = this.lctPersonnel;
            this.mmeDescription.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(79, 108);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(493, 20);
            this.txtEmail.StyleController = this.lctPersonnel;
            this.txtEmail.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(79, 84);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(493, 20);
            this.txtPhone.StyleController = this.lctPersonnel;
            this.txtPhone.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(79, 60);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(493, 20);
            this.txtAddress.StyleController = this.lctPersonnel;
            this.txtAddress.TabIndex = 6;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(79, 36);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(493, 20);
            this.txtFullName.StyleController = this.lctPersonnel;
            this.txtFullName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(79, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(493, 20);
            this.txtCode.StyleController = this.lctPersonnel;
            this.txtCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPersonnelCode,
            this.lciFullName,
            this.lciAddress,
            this.lciPhone,
            this.lciEmail,
            this.lciDescription});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 214);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciPersonnelCode
            // 
            this.lciPersonnelCode.Control = this.txtCode;
            this.lciPersonnelCode.Location = new System.Drawing.Point(0, 0);
            this.lciPersonnelCode.Name = "lciPersonnelCode";
            this.lciPersonnelCode.Size = new System.Drawing.Size(564, 24);
            this.lciPersonnelCode.Text = "Mã nhân viên";
            this.lciPersonnelCode.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciFullName
            // 
            this.lciFullName.Control = this.txtFullName;
            this.lciFullName.Location = new System.Drawing.Point(0, 24);
            this.lciFullName.Name = "lciFullName";
            this.lciFullName.Size = new System.Drawing.Size(564, 24);
            this.lciFullName.Text = "Họ tên";
            this.lciFullName.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciAddress
            // 
            this.lciAddress.Control = this.txtAddress;
            this.lciAddress.Location = new System.Drawing.Point(0, 48);
            this.lciAddress.Name = "lciAddress";
            this.lciAddress.Size = new System.Drawing.Size(564, 24);
            this.lciAddress.Text = "Địa chỉ";
            this.lciAddress.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciPhone
            // 
            this.lciPhone.Control = this.txtPhone;
            this.lciPhone.Location = new System.Drawing.Point(0, 72);
            this.lciPhone.Name = "lciPhone";
            this.lciPhone.Size = new System.Drawing.Size(564, 24);
            this.lciPhone.Text = "Điện thoại";
            this.lciPhone.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciEmail
            // 
            this.lciEmail.Control = this.txtEmail;
            this.lciEmail.Location = new System.Drawing.Point(0, 96);
            this.lciEmail.Name = "lciEmail";
            this.lciEmail.Size = new System.Drawing.Size(564, 24);
            this.lciEmail.Text = "Email";
            this.lciEmail.TextSize = new System.Drawing.Size(64, 13);
            // 
            // lciDescription
            // 
            this.lciDescription.Control = this.mmeDescription;
            this.lciDescription.Location = new System.Drawing.Point(0, 120);
            this.lciDescription.Name = "lciDescription";
            this.lciDescription.Size = new System.Drawing.Size(564, 74);
            this.lciDescription.Text = "Ghi chú";
            this.lciDescription.TextSize = new System.Drawing.Size(64, 13);
            // 
            // frmPersonnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.lctPersonnel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonnel";
            this.Text = "Nhân viên";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.Controls.SetChildIndex(this.lctPersonnel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popGridMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctPersonnel)).EndInit();
            this.lctPersonnel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFullName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPersonnelCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctPersonnel;
        private DevExpress.XtraEditors.MemoEdit mmeDescription;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtFullName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lciPersonnelCode;
        private DevExpress.XtraLayout.LayoutControlItem lciFullName;
        private DevExpress.XtraLayout.LayoutControlItem lciAddress;
        private DevExpress.XtraLayout.LayoutControlItem lciPhone;
        private DevExpress.XtraLayout.LayoutControlItem lciEmail;
        private DevExpress.XtraLayout.LayoutControlItem lciDescription;

    }
}