namespace EntityModel.DataModel
{
    using EntityModel.DataModel.CauHinh;
    using EntityModel.DataModel.DanhMuc;
    using EntityModel.DataModel.HeThong;
    using EntityModel.DataModel.DauKy;
    using System.Data.Entity;
    using EntityModel.DataModel.CongNo;
    using EntityModel.DataModel.ChucNang;

    public partial class zModel : DbContext
    {
        public zModel()
            : base(Module.dbConnectString)
        {
        }

        public zModel(string conn)
            : base(conn)
        {
        }

        #region Cấu hình
        public virtual DbSet<eHienThi> eHienThi { get; set; }
        public virtual DbSet<eQuyDoiDonVi> eQuyDoiDonVi { get; set; }
        public virtual DbSet<eQuyDoiTienTe> eQuyDoiTienTe { get; set; }
        #endregion

        #region Hệ thống
        public virtual DbSet<xAccount> xAccount { get; set; }
        public virtual DbSet<xAgency> xAgency { get; set; }
        public virtual DbSet<xPersonnel> xPersonnel { get; set; }
        public virtual DbSet<xAppConfig> xAppConfig { get; set; }
        public virtual DbSet<xDisplay> xDisplay { get; set; }
        public virtual DbSet<xFeature> xFeature { get; set; }
        public virtual DbSet<xLayoutItemCaption> xLayoutItemCaption { get; set; }
        public virtual DbSet<xMsgDictionary> xMsgDictionary { get; set; }
        public virtual DbSet<xPermission> xPermission { get; set; }
        public virtual DbSet<xUserFeature> xUserFeature { get; set; }
        public virtual DbSet<xUserLog> xUserLog { get; set; }
        public virtual DbSet<xLog> xLog { get; set; }
        #endregion

        #region Danh mục
        public virtual DbSet<eDonViTinh> eDonViTinh { get; set; }
        public virtual DbSet<eKhachHang> eKhachHang { get; set; }
        public virtual DbSet<eKho> eKho { get; set; }
        public virtual DbSet<eNhaCungCap> eNhaCungCap { get; set; }
        public virtual DbSet<eNhomDonViTinh> eNhomDonViTinh { get; set; }
        public virtual DbSet<eNhomKhachHang> eNhomKhachHang { get; set; }
        public virtual DbSet<eNhomNhaCungCap> eNhomNhaCungCap { get; set; }
        public virtual DbSet<eNhomSanPham> eNhomSanPham { get; set; }
        public virtual DbSet<eSanPham> eSanPham { get; set; }
        public virtual DbSet<eTienTe> eTienTe { get; set; }
        public virtual DbSet<eTinhThanh> eTinhThanh { get; set; }
        #endregion

        #region Khai báo đầu kỳ
        public virtual DbSet<eTonKhoDauKy> eTonKhoDauKy { get; set; }
        public virtual DbSet<eSoDuDauKyKhachHang> eSoDuDauKyKhachHang { get; set; }
        public virtual DbSet<eSoDuDauKyNhaCungCap> eSoDuDauKyNhaCungCap { get; set; }
        #endregion

        #region Công nợ
        public virtual DbSet<eCongNoNhaCungCap> eCongNoNhaCungCap { get; set; }
        #endregion

        #region Chức năng
        public virtual DbSet<eNhapHangNhaCungCap> eNhapHangNhaCungCap { get; set; }
        public virtual DbSet<eNhapHangNhaCungCapChiTiet> eNhapHangNhaCungCapChiTiet { get; set; }
        public virtual DbSet<eTonKho> eTonKho { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
