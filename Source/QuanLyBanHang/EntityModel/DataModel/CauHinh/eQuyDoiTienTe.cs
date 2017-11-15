using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.CauHinh
{
    [Table("eQuyDoiTienTe")]
    public class eQuyDoiTienTe
    {
        [Key]
        public int KeyID { get; set; }
    }
}
