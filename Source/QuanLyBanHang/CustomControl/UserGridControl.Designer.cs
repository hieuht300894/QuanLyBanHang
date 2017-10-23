namespace CustomControl
{
    partial class UserGridControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gctMain = new DevExpress.XtraGrid.GridControl();
            this.grvMain = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gctMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // gctMain
            // 
            this.gctMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gctMain.Location = new System.Drawing.Point(0, 0);
            this.gctMain.MainView = this.grvMain;
            this.gctMain.Name = "gctMain";
            this.gctMain.Size = new System.Drawing.Size(600, 300);
            this.gctMain.TabIndex = 0;
            this.gctMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMain});
            // 
            // grvMain
            // 
            this.grvMain.GridControl = this.gctMain;
            this.grvMain.Name = "grvMain";
            this.grvMain.OptionsView.ShowGroupPanel = false;
            // 
            // UserGridControl
            // 
            this.Controls.Add(this.gctMain);
            this.Name = "UserGridControl";
            this.Size = new System.Drawing.Size(600, 300);
            ((System.ComponentModel.ISupportInitialize)(this.gctMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gctMain;
        public DevExpress.XtraGrid.Views.Grid.GridView grvMain;
    }
}
