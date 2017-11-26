namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("xPersonnel")]
    public partial class xPersonnel
    {
        [Key]
        public int KeyID { get; set; }
        [Required]
        [StringLength(20)]
        public string Code { get; set; }
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool IsEnable { get; set; }
        public bool IsAccount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
