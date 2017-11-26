using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eCongNoNhaCungCap")]
    public class eCongNoNhaCungCap
    {
        [Key]
        public int KeyID { get; set; }

        public DateTime Ngay { get; set; }

        public int IDNhaCungCap { get; set; }

        public string MaNhaCungCap { get; set; }

        public string TenNhaCungCap { get; set; }

        public decimal TongTien { get; set; }

        public decimal ThanhToan { get; set; }

        public decimal ConLai { get; set; }

        public decimal NoCu { get; set; }

        public bool IsSoDuDauKy { get; set; }

        public bool IsNhapHang { get; set; }

        public bool IsTraHang { get; set; }

        public bool IsThanhToan { get; set; }

        public int IDMaster { get; set; }
    }
}
