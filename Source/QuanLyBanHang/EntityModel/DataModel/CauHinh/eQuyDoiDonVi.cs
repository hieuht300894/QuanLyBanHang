using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.DataModel.CauHinh
{
    [Table("eQuyDoiDonVi")]
    class eQuyDoiDonVi
    {
        [Key]
        public int KeyID { get; set; }
    }
}
