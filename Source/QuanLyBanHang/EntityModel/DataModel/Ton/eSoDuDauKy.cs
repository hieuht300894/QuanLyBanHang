using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel.Ton
{
    [Table("eSoDuDauKy")]
    public class eSoDuDauKy
    {
        [Key]
        public int KeyID { get; set; }
    }
}
