using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eTinhThanh")]
    public class eTinhThanh
    {
        [Key]
        public int KeyID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public int IDLoai { get; set; }
        public string Loai { get; set; }
        public string DienGiai { get; set; }
        public string PostalCode { get; set; }
        public string LocationCode { get; set; }
        public string ZipCode { get; set; }
        public int IDTinhThanh { get; set; }
        public string TinhThanh { get; set; }
    }
}
