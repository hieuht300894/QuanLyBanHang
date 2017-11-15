using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.CauHinh
{
    [Table("eHienThi")]
    class eHienThi
    {
        [Key]
        public int KeyID { get; set; }
    }
}
