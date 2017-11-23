using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel.DanhMuc
{
    [Table("eSanPham")]
    public class eSanPham
    {
        [Key]
        public int KeyID { get; set; }

        public string Ma { get; set; }

        public string Ten { get; set; }

        public Color Color { get; set; }

        public int ColorHex { get; set; }

        public string MauSac { get; set; }

        public string KichThuoc { get; set; }

        public int IDDonViTinh { get; set; }

        public string MaDonViTinh { get; set; }

        public string TenDonViTinh { get; set; }

        public string GhiChu { get; set; }
    }
}
