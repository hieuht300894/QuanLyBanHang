using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eTonKho")]
   public class eTonKho
    {
        [Key]
        public int KeyID { get; set; }

        public DateTime Ngay { get; set; }

        public int IDSanPham { get; set; }

        public string MaSanPham { get; set; }

        public string TenSanPham { get; set; }

        public int IDNhomSanPham { get; set; }

        public string MaNhomSanPham { get; set; }

        public string TenNhomSanPham { get; set; }

        public int IDDonViTinh { get; set; }

        public string MaDonViTinh { get; set; }

        public string TenDonViTinh { get; set; }

        public int IDKho { get; set; }

        public string MaKho { get; set; }

        public string TenKho { get; set; }

        public DateTime? HanSuDung { get; set; }

        public decimal SoLuongNhap { get; set; }

        public decimal SoLuongXuat { get; set; }

        public decimal SoLuongTraNhaCungCap { get; set; }

        public decimal SoLuongKhachHangTra { get; set; }

        public decimal SoLuongTon { get; set; }
    }
}
