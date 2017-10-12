using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel
{
    [Table("eNhomKhachHang")]
    public class eNhomKhachHang
    {
        [Key]
        public int KeyID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
}
