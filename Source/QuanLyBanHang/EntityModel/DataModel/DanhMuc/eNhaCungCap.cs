using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel.DanhMuc
{
    [Table("eNhaCungCap")]
    public class eNhaCungCap
    {
        [Key]
        public int KeyID { get; set; }
    }
}
