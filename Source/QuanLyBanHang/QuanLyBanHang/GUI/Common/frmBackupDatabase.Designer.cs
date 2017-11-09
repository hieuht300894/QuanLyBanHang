namespace QuanLyBanHang.GUI.Common
{
    partial class frmBackupDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackupDatabase));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.rgMode = new DevExpress.XtraEditors.RadioGroup();
            this.lokDB = new DevExpress.XtraEditors.LookUpEdit();
            this.lbMessage = new DevExpress.XtraEditors.ListBoxControl();
            this.pgPercent = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnRun = new DevExpress.XtraEditors.SimpleButton();
            this.rgFunction = new DevExpress.XtraEditors.RadioGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciBackup = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bteFile = new DevExpress.XtraEditors.ButtonEdit();
            this.lciRestore = new DevExpress.XtraLayout.LayoutControlItem();
            this.btePath = new DevExpress.XtraEditors.ButtonEdit();
            this.lciPath = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokDB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgFunction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPath)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btePath);
            this.layoutControl1.Controls.Add(this.bteFile);
            this.layoutControl1.Controls.Add(this.rgMode);
            this.layoutControl1.Controls.Add(this.lokDB);
            this.layoutControl1.Controls.Add(this.lbMessage);
            this.layoutControl1.Controls.Add(this.pgPercent);
            this.layoutControl1.Controls.Add(this.btnRun);
            this.layoutControl1.Controls.Add(this.rgFunction);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(639, 13, 450, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(384, 311);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // rgMode
            // 
            this.rgMode.EditValue = 1;
            this.rgMode.Location = new System.Drawing.Point(77, 115);
            this.rgMode.Name = "rgMode";
            this.rgMode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Toàn bộ"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Mới nhất"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Giao dịch")});
            this.rgMode.Size = new System.Drawing.Size(295, 25);
            this.rgMode.StyleController = this.layoutControl1;
            this.rgMode.TabIndex = 10;
            // 
            // lokDB
            // 
            this.lokDB.Location = new System.Drawing.Point(77, 12);
            this.lokDB.Name = "lokDB";
            this.lokDB.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::QuanLyBanHang.Properties.Resources.Refresh_16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.lokDB.Properties.NullText = "";
            this.lokDB.Size = new System.Drawing.Size(295, 22);
            this.lokDB.StyleController = this.layoutControl1;
            this.lokDB.TabIndex = 9;
            // 
            // lbMessage
            // 
            this.lbMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbMessage.HorizontalScrollbar = true;
            this.lbMessage.Location = new System.Drawing.Point(12, 188);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(360, 111);
            this.lbMessage.StyleController = this.layoutControl1;
            this.lbMessage.TabIndex = 8;
            // 
            // pgPercent
            // 
            this.pgPercent.Location = new System.Drawing.Point(12, 170);
            this.pgPercent.Name = "pgPercent";
            this.pgPercent.Properties.Step = 1;
            this.pgPercent.Size = new System.Drawing.Size(360, 14);
            this.pgPercent.StyleController = this.layoutControl1;
            this.pgPercent.TabIndex = 7;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(276, 144);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(96, 22);
            this.btnRun.StyleController = this.layoutControl1;
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "Hoàn tất";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // rgFunction
            // 
            this.rgFunction.EditValue = 1;
            this.rgFunction.Location = new System.Drawing.Point(77, 86);
            this.rgFunction.Name = "rgFunction";
            this.rgFunction.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Sao lưu"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Phục hồi")});
            this.rgFunction.Properties.ItemsLayout = DevExpress.XtraEditors.RadioGroupItemsLayout.Flow;
            this.rgFunction.Size = new System.Drawing.Size(295, 25);
            this.rgFunction.StyleController = this.layoutControl1;
            this.rgFunction.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.lciBackup,
            this.layoutControlItem6,
            this.lciRestore,
            this.lciPath});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(384, 311);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rgFunction;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(364, 29);
            this.layoutControlItem2.Text = "Chức năng";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnRun;
            this.layoutControlItem3.Location = new System.Drawing.Point(264, 132);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pgPercent;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 158);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(364, 18);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 132);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(264, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lbMessage;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 176);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(364, 115);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // lciBackup
            // 
            this.lciBackup.Control = this.lokDB;
            this.lciBackup.Location = new System.Drawing.Point(0, 0);
            this.lciBackup.Name = "lciBackup";
            this.lciBackup.Size = new System.Drawing.Size(364, 26);
            this.lciBackup.Text = "Cơ sở dữ liệu";
            this.lciBackup.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.rgMode;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 103);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(364, 29);
            this.layoutControlItem6.Text = "Chế độ";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(62, 13);
            // 
            // bteFile
            // 
            this.bteFile.Location = new System.Drawing.Point(77, 62);
            this.bteFile.Name = "bteFile";
            this.bteFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bteFile.Size = new System.Drawing.Size(295, 20);
            this.bteFile.StyleController = this.layoutControl1;
            this.bteFile.TabIndex = 11;
            // 
            // lciRestore
            // 
            this.lciRestore.Control = this.bteFile;
            this.lciRestore.Location = new System.Drawing.Point(0, 50);
            this.lciRestore.Name = "lciRestore";
            this.lciRestore.Size = new System.Drawing.Size(364, 24);
            this.lciRestore.Text = "Tập tin";
            this.lciRestore.TextSize = new System.Drawing.Size(62, 13);
            this.lciRestore.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // btePath
            // 
            this.btePath.Location = new System.Drawing.Point(77, 38);
            this.btePath.Name = "btePath";
            this.btePath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btePath.Size = new System.Drawing.Size(295, 20);
            this.btePath.StyleController = this.layoutControl1;
            this.btePath.TabIndex = 12;
            // 
            // lciPath
            // 
            this.lciPath.Control = this.btePath;
            this.lciPath.Location = new System.Drawing.Point(0, 26);
            this.lciPath.Name = "lciPath";
            this.lciPath.Size = new System.Drawing.Size(364, 24);
            this.lciPath.Text = "Đường dẫn";
            this.lciPath.TextSize = new System.Drawing.Size(62, 13);
            // 
            // frmBackupDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBackupDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu/ phục hồi dữ liệu";
            this.Load += new System.EventHandler(this.frmBackupDatabase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rgMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokDB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgFunction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPath)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ProgressBarControl pgPercent;
        private DevExpress.XtraEditors.SimpleButton btnRun;
        private DevExpress.XtraEditors.RadioGroup rgFunction;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ListBoxControl lbMessage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LookUpEdit lokDB;
        private DevExpress.XtraLayout.LayoutControlItem lciBackup;
        private DevExpress.XtraEditors.RadioGroup rgMode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.ButtonEdit bteFile;
        private DevExpress.XtraLayout.LayoutControlItem lciRestore;
        private DevExpress.XtraEditors.ButtonEdit btePath;
        private DevExpress.XtraLayout.LayoutControlItem lciPath;
    }
}