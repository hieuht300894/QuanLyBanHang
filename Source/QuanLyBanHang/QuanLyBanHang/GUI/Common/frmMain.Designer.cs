namespace QuanLyBanHang.GUI.Common
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bsiClock = new DevExpress.XtraBars.BarStaticItem();
            this.bsiNhanVien = new DevExpress.XtraBars.BarStaticItem();
            this.frmPersonnel_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmAccount_List = new DevExpress.XtraBars.BarButtonItem();
            this.bsiPCName = new DevExpress.XtraBars.BarStaticItem();
            this.bsiComputerName = new DevExpress.XtraBars.BarStaticItem();
            this.bsiDatabaseName = new DevExpress.XtraBars.BarStaticItem();
            this.frmPermission_List = new DevExpress.XtraBars.BarButtonItem();
            this.bsiDBName = new DevExpress.XtraBars.BarStaticItem();
            this.bbiChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSkin = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.bbiInfomation = new DevExpress.XtraBars.BarButtonItem();
            this.frmTinhThanh_List = new DevExpress.XtraBars.BarButtonItem();
            this.frmKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.frmKho = new DevExpress.XtraBars.BarButtonItem();
            this.frmDonViTinh = new DevExpress.XtraBars.BarButtonItem();
            this.frmSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhaCungCap = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhomDonViTinh = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhomKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhomNhaCungCap = new DevExpress.XtraBars.BarButtonItem();
            this.frmNhomSanPham = new DevExpress.XtraBars.BarButtonItem();
            this.frmSoDuDauKyKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.frmSoDuDauKyNhaCungCap = new DevExpress.XtraBars.BarButtonItem();
            this.frmTonKhoDauKy = new DevExpress.XtraBars.BarButtonItem();
            this.rbpAccount = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgStaff = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpConfig = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgSkin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgDanhMuc = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbgDanhMucNhom = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbgKhaiBaoDauKy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.dlafSkin = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.docManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tbvMain = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.rbpChucNang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbgNhapXuat = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.frmNhapHangNhaCungCap = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.AllowMdiChildButtons = false;
            this.ribbon.ApplicationCaption = "Quản lý bán hàng";
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bsiClock,
            this.bsiNhanVien,
            this.frmPersonnel_List,
            this.frmAccount_List,
            this.bsiPCName,
            this.bsiComputerName,
            this.bsiDatabaseName,
            this.frmPermission_List,
            this.bsiDBName,
            this.bbiChangePassword,
            this.bbiSkin,
            this.bbiInfomation,
            this.frmTinhThanh_List,
            this.frmKhachHang,
            this.frmKho,
            this.frmDonViTinh,
            this.frmSanPham,
            this.frmNhaCungCap,
            this.frmNhomDonViTinh,
            this.frmNhomKhachHang,
            this.frmNhomNhaCungCap,
            this.frmNhomSanPham,
            this.frmSoDuDauKyKhachHang,
            this.frmSoDuDauKyNhaCungCap,
            this.frmTonKhoDauKy,
            this.frmNhapHangNhaCungCap});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 234;
            this.ribbon.Name = "ribbon";
            this.ribbon.PageHeaderItemLinks.Add(this.bsiNhanVien);
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbpAccount,
            this.rbpConfig,
            this.rbpDanhMuc,
            this.rbpChucNang});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(884, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // bsiClock
            // 
            this.bsiClock.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bsiClock.Id = 22;
            this.bsiClock.Name = "bsiClock";
            this.bsiClock.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiNhanVien
            // 
            this.bsiNhanVien.Caption = "Tên nhân viên";
            this.bsiNhanVien.Id = 75;
            this.bsiNhanVien.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bsiNhanVien.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bsiNhanVien.ItemAppearance.Normal.Options.UseFont = true;
            this.bsiNhanVien.ItemAppearance.Normal.Options.UseForeColor = true;
            this.bsiNhanVien.Name = "bsiNhanVien";
            this.bsiNhanVien.TextAlignment = System.Drawing.StringAlignment.Near;
            this.bsiNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bsiNhanVien_ItemClick);
            // 
            // frmPersonnel_List
            // 
            this.frmPersonnel_List.Caption = "Nhân viên";
            this.frmPersonnel_List.Id = 111;
            this.frmPersonnel_List.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.BOResume_32x32;
            this.frmPersonnel_List.Name = "frmPersonnel_List";
            // 
            // frmAccount_List
            // 
            this.frmAccount_List.Caption = "Tài khoản";
            this.frmAccount_List.Id = 112;
            this.frmAccount_List.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.BOUser_32x32;
            this.frmAccount_List.Name = "frmAccount_List";
            // 
            // bsiPCName
            // 
            this.bsiPCName.Id = 115;
            this.bsiPCName.Name = "bsiPCName";
            this.bsiPCName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiComputerName
            // 
            this.bsiComputerName.Caption = "Tên máy:";
            this.bsiComputerName.Id = 117;
            this.bsiComputerName.Name = "bsiComputerName";
            this.bsiComputerName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bsiDatabaseName
            // 
            this.bsiDatabaseName.Caption = "Cơ sở dữ liệu:";
            this.bsiDatabaseName.Id = 119;
            this.bsiDatabaseName.Name = "bsiDatabaseName";
            this.bsiDatabaseName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // frmPermission_List
            // 
            this.frmPermission_List.Caption = "Phân quyền";
            this.frmPermission_List.Id = 120;
            this.frmPermission_List.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.CheckButtons_32x32;
            this.frmPermission_List.Name = "frmPermission_List";
            // 
            // bsiDBName
            // 
            this.bsiDBName.Id = 129;
            this.bsiDBName.Name = "bsiDBName";
            this.bsiDBName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbiChangePassword
            // 
            this.bbiChangePassword.Caption = "Đổi mật khẩu";
            this.bbiChangePassword.Id = 136;
            this.bbiChangePassword.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.BOPermission_32x32;
            this.bbiChangePassword.Name = "bbiChangePassword";
            this.bbiChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangePassword_ItemClick);
            // 
            // bbiSkin
            // 
            this.bbiSkin.Id = 215;
            this.bbiSkin.Name = "bbiSkin";
            // 
            // bbiInfomation
            // 
            this.bbiInfomation.Caption = "Cấu hình";
            this.bbiInfomation.Id = 216;
            this.bbiInfomation.ImageOptions.LargeImage = global::QuanLyBanHang.Properties.Resources.Properties_32x32;
            this.bbiInfomation.Name = "bbiInfomation";
            this.bbiInfomation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInfomation_ItemClick);
            // 
            // frmTinhThanh_List
            // 
            this.frmTinhThanh_List.Caption = "Tỉnh thành";
            this.frmTinhThanh_List.Id = 219;
            this.frmTinhThanh_List.Name = "frmTinhThanh_List";
            // 
            // frmKhachHang
            // 
            this.frmKhachHang.Caption = "Khách hàng";
            this.frmKhachHang.Id = 221;
            this.frmKhachHang.Name = "frmKhachHang";
            // 
            // frmKho
            // 
            this.frmKho.Caption = "Kho";
            this.frmKho.Id = 222;
            this.frmKho.Name = "frmKho";
            // 
            // frmDonViTinh
            // 
            this.frmDonViTinh.Caption = "Đơn vị tính";
            this.frmDonViTinh.Id = 223;
            this.frmDonViTinh.Name = "frmDonViTinh";
            // 
            // frmSanPham
            // 
            this.frmSanPham.Caption = "Sản phẩm";
            this.frmSanPham.Id = 224;
            this.frmSanPham.Name = "frmSanPham";
            // 
            // frmNhaCungCap
            // 
            this.frmNhaCungCap.Caption = "Nhà cung cấp";
            this.frmNhaCungCap.Id = 225;
            this.frmNhaCungCap.Name = "frmNhaCungCap";
            // 
            // frmNhomDonViTinh
            // 
            this.frmNhomDonViTinh.Caption = "ĐVT";
            this.frmNhomDonViTinh.Id = 226;
            this.frmNhomDonViTinh.Name = "frmNhomDonViTinh";
            // 
            // frmNhomKhachHang
            // 
            this.frmNhomKhachHang.Caption = "KH";
            this.frmNhomKhachHang.Id = 227;
            this.frmNhomKhachHang.Name = "frmNhomKhachHang";
            // 
            // frmNhomNhaCungCap
            // 
            this.frmNhomNhaCungCap.Caption = "NCC";
            this.frmNhomNhaCungCap.Id = 228;
            this.frmNhomNhaCungCap.Name = "frmNhomNhaCungCap";
            // 
            // frmNhomSanPham
            // 
            this.frmNhomSanPham.Caption = "SP";
            this.frmNhomSanPham.Id = 229;
            this.frmNhomSanPham.Name = "frmNhomSanPham";
            // 
            // frmSoDuDauKyKhachHang
            // 
            this.frmSoDuDauKyKhachHang.Caption = "Số dư đầu kỳ khách hàng";
            this.frmSoDuDauKyKhachHang.Id = 230;
            this.frmSoDuDauKyKhachHang.Name = "frmSoDuDauKyKhachHang";
            // 
            // frmSoDuDauKyNhaCungCap
            // 
            this.frmSoDuDauKyNhaCungCap.Caption = "Số dư đầu kỳ nhà cung cấp";
            this.frmSoDuDauKyNhaCungCap.Id = 231;
            this.frmSoDuDauKyNhaCungCap.Name = "frmSoDuDauKyNhaCungCap";
            // 
            // frmTonKhoDauKy
            // 
            this.frmTonKhoDauKy.Caption = "Tồn kho";
            this.frmTonKhoDauKy.Id = 232;
            this.frmTonKhoDauKy.Name = "frmTonKhoDauKy";
            // 
            // rbpAccount
            // 
            this.rbpAccount.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgStaff});
            this.rbpAccount.Name = "rbpAccount";
            this.rbpAccount.Text = "Tài khoản";
            // 
            // rbgStaff
            // 
            this.rbgStaff.ItemLinks.Add(this.frmPersonnel_List);
            this.rbgStaff.ItemLinks.Add(this.frmAccount_List);
            this.rbgStaff.ItemLinks.Add(this.frmPermission_List);
            this.rbgStaff.ItemLinks.Add(this.bbiChangePassword);
            this.rbgStaff.Name = "rbgStaff";
            this.rbgStaff.Text = "Nhân viên";
            // 
            // rbpConfig
            // 
            this.rbpConfig.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgSkin});
            this.rbpConfig.Name = "rbpConfig";
            this.rbpConfig.Text = "Thiết lập";
            // 
            // rbgSkin
            // 
            this.rbgSkin.ItemLinks.Add(this.bbiInfomation);
            this.rbgSkin.ItemLinks.Add(this.bbiSkin);
            this.rbgSkin.Name = "rbgSkin";
            this.rbgSkin.Text = "Mặc định";
            // 
            // rbpDanhMuc
            // 
            this.rbpDanhMuc.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgDanhMuc,
            this.rbgDanhMucNhom,
            this.rbgKhaiBaoDauKy});
            this.rbpDanhMuc.Name = "rbpDanhMuc";
            this.rbpDanhMuc.Text = "Danh mục";
            // 
            // rbgDanhMuc
            // 
            this.rbgDanhMuc.ItemLinks.Add(this.frmTinhThanh_List);
            this.rbgDanhMuc.ItemLinks.Add(this.frmKhachHang);
            this.rbgDanhMuc.ItemLinks.Add(this.frmKho);
            this.rbgDanhMuc.ItemLinks.Add(this.frmDonViTinh);
            this.rbgDanhMuc.ItemLinks.Add(this.frmSanPham);
            this.rbgDanhMuc.ItemLinks.Add(this.frmNhaCungCap);
            this.rbgDanhMuc.Name = "rbgDanhMuc";
            this.rbgDanhMuc.Text = "Danh mục chung";
            // 
            // rbgDanhMucNhom
            // 
            this.rbgDanhMucNhom.ItemLinks.Add(this.frmNhomDonViTinh);
            this.rbgDanhMucNhom.ItemLinks.Add(this.frmNhomKhachHang);
            this.rbgDanhMucNhom.ItemLinks.Add(this.frmNhomNhaCungCap);
            this.rbgDanhMucNhom.ItemLinks.Add(this.frmNhomSanPham);
            this.rbgDanhMucNhom.Name = "rbgDanhMucNhom";
            this.rbgDanhMucNhom.Text = "Nhóm danh mục";
            // 
            // rbgKhaiBaoDauKy
            // 
            this.rbgKhaiBaoDauKy.ItemLinks.Add(this.frmSoDuDauKyKhachHang);
            this.rbgKhaiBaoDauKy.ItemLinks.Add(this.frmSoDuDauKyNhaCungCap);
            this.rbgKhaiBaoDauKy.ItemLinks.Add(this.frmTonKhoDauKy);
            this.rbgKhaiBaoDauKy.Name = "rbgKhaiBaoDauKy";
            this.rbgKhaiBaoDauKy.Text = "Khai báo đầu kỳ";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.bsiClock);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiComputerName);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiPCName);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiDatabaseName, true);
            this.ribbonStatusBar.ItemLinks.Add(this.bsiDBName);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 417);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(884, 32);
            // 
            // dlafSkin
            // 
            this.dlafSkin.LookAndFeel.SkinName = "Office 2010 Silver";
            // 
            // docManager
            // 
            this.docManager.MdiParent = this;
            this.docManager.MenuManager = this.ribbon;
            this.docManager.View = this.tbvMain;
            this.docManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tbvMain});
            // 
            // tbvMain
            // 
            this.tbvMain.RootContainer.Element = null;
            // 
            // rbpChucNang
            // 
            this.rbpChucNang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbgNhapXuat});
            this.rbpChucNang.Name = "rbpChucNang";
            this.rbpChucNang.Text = "Chức năng";
            // 
            // rbgNhapXuat
            // 
            this.rbgNhapXuat.ItemLinks.Add(this.frmNhapHangNhaCungCap);
            this.rbgNhapXuat.Name = "rbgNhapXuat";
            this.rbgNhapXuat.Text = "Nhập hàng - trả hàng";
            // 
            // frmNhapHangNhaCungCap
            // 
            this.frmNhapHangNhaCungCap.Caption = "Nhập hàng";
            this.frmNhapHangNhaCungCap.Id = 233;
            this.frmNhapHangNhaCungCap.Name = "frmNhapHangNhaCungCap";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 449);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản lý bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dlafSkin;
        private DevExpress.XtraBars.Docking2010.DocumentManager docManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tbvMain;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpAccount;
        private DevExpress.XtraBars.BarStaticItem bsiClock;
        private DevExpress.XtraBars.BarStaticItem bsiNhanVien;
        private DevExpress.XtraBars.BarButtonItem frmPersonnel_List;
        private DevExpress.XtraBars.BarButtonItem frmAccount_List;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgStaff;
        private DevExpress.XtraBars.BarStaticItem bsiPCName;
        private DevExpress.XtraBars.BarStaticItem bsiComputerName;
        private DevExpress.XtraBars.BarStaticItem bsiDatabaseName;
        private DevExpress.XtraBars.BarButtonItem frmPermission_List;
        private DevExpress.XtraBars.BarStaticItem bsiDBName;
        private DevExpress.XtraBars.BarButtonItem bbiChangePassword;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem bbiSkin;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpConfig;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgSkin;
        private DevExpress.XtraBars.BarButtonItem bbiInfomation;
        private DevExpress.XtraBars.BarButtonItem frmTinhThanh_List;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpDanhMuc;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgDanhMuc;
        private DevExpress.XtraBars.BarButtonItem frmKhachHang;
        private DevExpress.XtraBars.BarButtonItem frmKho;
        private DevExpress.XtraBars.BarButtonItem frmDonViTinh;
        private DevExpress.XtraBars.BarButtonItem frmSanPham;
        private DevExpress.XtraBars.BarButtonItem frmNhaCungCap;
        private DevExpress.XtraBars.BarButtonItem frmNhomDonViTinh;
        private DevExpress.XtraBars.BarButtonItem frmNhomKhachHang;
        private DevExpress.XtraBars.BarButtonItem frmNhomNhaCungCap;
        private DevExpress.XtraBars.BarButtonItem frmNhomSanPham;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgDanhMucNhom;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgKhaiBaoDauKy;
        private DevExpress.XtraBars.BarButtonItem frmSoDuDauKyKhachHang;
        private DevExpress.XtraBars.BarButtonItem frmSoDuDauKyNhaCungCap;
        private DevExpress.XtraBars.BarButtonItem frmTonKhoDauKy;
        private DevExpress.XtraBars.BarButtonItem frmNhapHangNhaCungCap;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpChucNang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbgNhapXuat;
    }
}