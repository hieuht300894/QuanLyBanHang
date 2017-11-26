using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eSoDuDauKyKhachHang")]
    public class eSoDuDauKyKhachHang
    {
        [Key]
        public int KeyID { get; set; }
        public int IDKhachHang { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
    }
}
