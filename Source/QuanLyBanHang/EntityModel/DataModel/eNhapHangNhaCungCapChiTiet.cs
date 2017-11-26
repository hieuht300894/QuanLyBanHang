using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eNhapHangNhaCungCapChiTiet")]
    public class eNhapHangNhaCungCapChiTiet
    {
        [Key]
        public int KeyID { get; set; }

        public int IDNhapHangNhaCungCap { get; set; }

        public int IDSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int IDDonViTinh { get; set; }

        public string MaDonViTinh { get; set; }

        public string TenDonViTinh { get; set; }

        public int IDKho { get; set; }

        public string MaKho { get; set; }

        public string TenKho { get; set; }

        public DateTime? HanSuDung { get; set; }

        public decimal SoLuongSi { get; set; }

        public decimal SoLuongLe { get; set; }

        public decimal SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal ThanhTien { get; set; }

        public decimal VAT { get; set; }

        public decimal TienVAT { get; set; }

        public decimal ChietKhau { get; set; }

        public decimal TienChietKhau { get; set; }

        public decimal TongTien { get; set; }

        public string GhiChu { get; set; }
    }
}
