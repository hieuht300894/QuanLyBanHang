using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel
{
    [Table("eTonKhoDauKy")]
    public class eTonKhoDauKy
    {
        [Key]
        public int KeyID { get; set; }
        public int IDSanPham { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int IDDonViTinh { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public int IDKho { get; set; }
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal SoLuong { get; set; }
        public string GhiChu { get; set; }
    }
}
