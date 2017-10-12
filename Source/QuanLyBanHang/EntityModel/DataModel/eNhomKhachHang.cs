using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
   public class eNhomKhachHang
    {
        [Key]
        public int KeyID { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
    }
}
