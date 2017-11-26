using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eNhaCungCap")]
    public class eNhaCungCap
    {
        [Key]
        public int KeyID { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public string DiaChi { get; set; }

        public string DienThoai { get; set; }

        public string NguoiLienHe { get; set; }

        public string GhiChu { get; set; }

        public int IDTinhThanh { get; set; }

        public string TinhThanh { get; set; }

        public bool KichHoat { get; set; }
    }
}
