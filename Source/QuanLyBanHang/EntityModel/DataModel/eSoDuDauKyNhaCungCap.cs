using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eSoDuDauKyNhaCungCap")]
    public class eSoDuDauKyNhaCungCap
    {
        [Key]
        public int KeyID { get; set; }
        public int IDNhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
    }
}
