namespace QuanLyBanHang.GUI.Common
{
    partial class frmError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmError));
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.pnTop = new DevExpress.XtraEditors.PanelControl();
            this.llbDetail = new System.Windows.Forms.LinkLabel();
            this.pteIcon = new DevExpress.XtraEditors.PictureEdit();
            this.btnContinue = new DevExpress.XtraEditors.SimpleButton();
            this.btnRestart = new DevExpress.XtraEditors.SimpleButton();
            this.pnBottom = new DevExpress.XtraEditors.PanelControl();
            this.meError = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnTop)).BeginInit();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pteIcon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnBottom)).BeginInit();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meError.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(299, 65);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Thoát";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Appearance.Options.UseFont = true;
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMessage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(109, 2);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(5, 5, 5, 2);
            this.lblMessage.Size = new System.Drawing.Size(273, 7);
            this.lblMessage.TabIndex = 5;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.llbDetail);
            this.pnTop.Controls.Add(this.lblMessage);
            this.pnTop.Controls.Add(this.pteIcon);
            this.pnTop.Controls.Add(this.btnContinue);
            this.pnTop.Controls.Add(this.btnRestart);
            this.pnTop.Controls.Add(this.btnOK);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(384, 111);
            this.pnTop.TabIndex = 7;
            // 
            // llbDetail
            // 
            this.llbDetail.AutoSize = true;
            this.llbDetail.Location = new System.Drawing.Point(297, 91);
            this.llbDetail.Name = "llbDetail";
            this.llbDetail.Size = new System.Drawing.Size(82, 13);
            this.llbDetail.TabIndex = 7;
            this.llbDetail.TabStop = true;
            this.llbDetail.Text = "Hiện chi tiết >>";
            this.llbDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbDetail_LinkClicked);
            // 
            // pteIcon
            // 
            this.pteIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pteIcon.EditValue = global::QuanLyBanHang.Properties.Resources.Error;
            this.pteIcon.Location = new System.Drawing.Point(2, 2);
            this.pteIcon.Name = "pteIcon";
            this.pteIcon.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pteIcon.Properties.Appearance.Options.UseBackColor = true;
            this.pteIcon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pteIcon.Properties.Padding = new System.Windows.Forms.Padding(25);
            this.pteIcon.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pteIcon.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pteIcon.Properties.ZoomAccelerationFactor = 1D;
            this.pteIcon.Size = new System.Drawing.Size(107, 107);
            this.pteIcon.TabIndex = 3;
            // 
            // btnContinue
            // 
            this.btnContinue.Location = new System.Drawing.Point(127, 65);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(80, 23);
            this.btnContinue.TabIndex = 4;
            this.btnContinue.Text = "Tiếp tục";
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(213, 65);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(80, 23);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Khởi động lại";
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.meError);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBottom.Location = new System.Drawing.Point(0, 111);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(384, 0);
            this.pnBottom.TabIndex = 8;
            // 
            // meError
            // 
            this.meError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.meError.Location = new System.Drawing.Point(2, 1);
            this.meError.Name = "meError";
            this.meError.Size = new System.Drawing.Size(380, 0);
            this.meError.TabIndex = 0;
            // 
            // frmError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 110);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2013";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmError";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lỗi";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnTop)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pteIcon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnBottom)).EndInit();
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meError.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pteIcon;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        public DevExpress.XtraEditors.LabelControl lblMessage;
        private DevExpress.XtraEditors.PanelControl pnTop;
        private DevExpress.XtraEditors.PanelControl pnBottom;
        public DevExpress.XtraEditors.MemoEdit meError;
        private System.Windows.Forms.LinkLabel llbDetail;
        private DevExpress.XtraEditors.SimpleButton btnContinue;
        private DevExpress.XtraEditors.SimpleButton btnRestart;
    }
}