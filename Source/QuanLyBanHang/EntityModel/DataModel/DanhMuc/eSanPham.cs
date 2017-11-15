using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string MauSon { get; set; }

        public string KichThuoc { get; set; }

        public int IDDonViTinh { get; set; }

        public string DonViTinh { get; set; }

        public string GhiChu { get; set; }
    }
}
