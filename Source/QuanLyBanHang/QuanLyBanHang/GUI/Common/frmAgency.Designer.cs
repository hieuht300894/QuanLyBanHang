namespace QuanLyBanHang.GUI.Common
{
    partial class frmAgency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgency));
            this.lctAgency = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.lokAgency = new DevExpress.XtraEditors.LookUpEdit();
            this.pteLogo = new DevExpress.XtraEditors.PictureEdit();
            this.mmeDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAddress = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAgency = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lctAgency)).BeginInit();
            this.lctAgency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lokAgency.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pteLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAgency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lctAgency
            // 
            this.lctAgency.Controls.Add(this.btnSave);
            this.lctAgency.Controls.Add(this.lokAgency);
            this.lctAgency.Controls.Add(this.pteLogo);
            this.lctAgency.Controls.Add(this.mmeDescription);
            this.lctAgency.Controls.Add(this.txtEmail);
            this.lctAgency.Controls.Add(this.txtPhone);
            this.lctAgency.Controls.Add(this.txtAddress);
            this.lctAgency.Controls.Add(this.txtName);
            this.lctAgency.Controls.Add(this.txtCode);
            this.lctAgency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lctAgency.Location = new System.Drawing.Point(0, 0);
            this.lctAgency.Name = "lctAgency";
            this.lctAgency.Root = this.layoutControlGroup1;
            this.lctAgency.Size = new System.Drawing.Size(484, 283);
            this.lctAgency.TabIndex = 0;
            this.lctAgency.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(386, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 22);
            this.btnSave.StyleController = this.lctAgency;
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lokAgency
            // 
            this.lokAgency.Location = new System.Drawing.Point(68, 12);
            this.lokAgency.Name = "lokAgency";
            this.lokAgency.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lokAgency.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Code"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")});
            this.lokAgency.Properties.NullText = "";
            this.lokAgency.Size = new System.Drawing.Size(260, 20);
            this.lokAgency.StyleController = this.lctAgency;
            this.lokAgency.TabIndex = 11;
            this.lokAgency.EditValueChanged += new System.EventHandler(this.lokAgency_EditValueChanged);
            // 
            // pteLogo
            // 
            this.pteLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.pteLogo.Location = new System.Drawing.Point(332, 12);
            this.pteLogo.Name = "pteLogo";
            this.pteLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pteLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pteLogo.Properties.ZoomAccelerationFactor = 1D;
            this.pteLogo.Size = new System.Drawing.Size(140, 140);
            this.pteLogo.StyleController = this.lctAgency;
            this.pteLogo.TabIndex = 10;
            this.pteLogo.Click += new System.EventHandler(this.pteLogo_Click);
            // 
            // mmeDescription
            // 
            this.mmeDescription.Location = new System.Drawing.Point(68, 156);
            this.mmeDescription.Name = "mmeDescription";
            this.mmeDescription.Size = new System.Drawing.Size(404, 88);
            this.mmeDescription.StyleController = this.lctAgency;
            this.mmeDescription.TabIndex = 9;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(68, 132);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(260, 20);
            this.txtEmail.StyleController = this.lctAgency;
            this.txtEmail.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(68, 108);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(260, 20);
            this.txtPhone.StyleController = this.lctAgency;
            this.txtPhone.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(68, 84);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(260, 20);
            this.txtAddress.StyleController = this.lctAgency;
            this.txtAddress.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(68, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 20);
            this.txtName.StyleController = this.lctAgency;
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(68, 36);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(260, 20);
            this.txtCode.StyleController = this.lctAgency;
            this.txtCode.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciCode,
            this.lciName,
            this.lciAddress,
            this.lciPhone,
            this.lciEmail,
            this.lciDescription,
            this.layoutControlItem1,
            this.lciAgency,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(484, 283);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lciCode
            // 
            this.lciCode.Control = this.txtCode;
            this.lciCode.Location = new System.Drawing.Point(0, 24);
            this.lciCode.Name = "lciCode";
            this.lciCode.Size = new System.Drawing.Size(320, 24);
            this.lciCode.Text = "Code";
            this.lciCode.TextSize = new System.Drawing.Size(53, 13);
            // 
            // lciName
            // 
            this.lciName.Control = this.txtName;
            this.lciName.Location = new System.Drawing.Point(0, 48);
            this.lciName.Name = "lciName";
            this.lciName.Size = new System.Drawing.Size(320, 24);
            this.lciName.Text = "Name";
            this.lciName.TextSize = new System.Drawing.Size(53, 13);
            // 
            // lciAddress
            // 
            this.lciAddress.Control = this.txtAddress;
            this.lciAddress.Location = new System.Drawing.Point(0, 72);
            this.lciAddress.Name = "lciAddress";
            this.lciAddress.Size = new System.Drawing.Size(320, 24);
            this.lciAddress.Text = "Address";
            this.lciAddress.TextSize = new System.Drawing.Size(53, 13);
            // 
            // lciPhone
            // 
            this.lciPhone.Control = this.txtPhone;
            this.lciPhone.Location = new System.Drawing.Point(0, 96);
            this.lciPhone.Name = "lciPhone";
            this.lciPhone.Size = new System.Drawing.Size(320, 24);
            this.lciPhone.Text = "Phone";
            this.lciPhone.TextSize = new System.Drawing.Size(53, 13);
            // 
            // lciEmail
            // 
            this.lciEmail.Control = this.txtEmail;
            this.lciEmail.Location = new System.Drawing.Point(0, 120);
            this.lciEmail.Name = "lciEmail";
            this.lciEmail.Size = new System.Drawing.Size(320, 24);
            this.lciEmail.Text = "Email";
            this.lciEmail.TextSize = new System.Drawing.Size(53, 13);
            // 
            // lciDescription
            // 
            this.lciDescription.Control = this.mmeDescription;
            this.lciDescription.Location = new System.Drawing.Point(0, 144);
            this.lciDescription.MaxSize = new System.Drawing.Size(0, 92);
            this.lciDescription.MinSize = new System.Drawing.Size(70, 92);
            this.lciDescription.Name = "lciDescription";
            this.lciDescription.Size = new System.Drawing.Size(464, 92);
            this.lciDescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lciDescription.Text = "Description";
            this.lciDescription.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.pteLogo;
            this.layoutControlItem1.Location = new System.Drawing.Point(320, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(144, 144);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(144, 144);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(144, 144);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // lciAgency
            // 
            this.lciAgency.Control = this.lokAgency;
            this.lciAgency.Location = new System.Drawing.Point(0, 0);
            this.lciAgency.Name = "lciAgency";
            this.lciAgency.Size = new System.Drawing.Size(320, 24);
            this.lciAgency.Text = "Agency";
            this.lciAgency.TextSize = new System.Drawing.Size(53, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSave;
            this.layoutControlItem2.Location = new System.Drawing.Point(374, 236);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(90, 27);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 236);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(374, 27);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 283);
            this.Controls.Add(this.lctAgency);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgency";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agency";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAgency_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lctAgency)).EndInit();
            this.lctAgency.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lokAgency.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pteLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mmeDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAgency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lctAgency;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit mmeDescription;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem lciCode;
        private DevExpress.XtraLayout.LayoutControlItem lciName;
        private DevExpress.XtraLayout.LayoutControlItem lciAddress;
        private DevExpress.XtraLayout.LayoutControlItem lciPhone;
        private DevExpress.XtraLayout.LayoutControlItem lciEmail;
        private DevExpress.XtraLayout.LayoutControlItem lciDescription;
        private DevExpress.XtraEditors.PictureEdit pteLogo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lokAgency;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraLayout.LayoutControlItem lciAgency;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}