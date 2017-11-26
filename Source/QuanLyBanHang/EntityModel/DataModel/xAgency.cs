namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("xAgency")]
    public partial class xAgency
    {
        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public string Credentials { get; set; }

        public string HostAddress { get; set; }

        public int HostPort { get; set; }

        public byte[] Logo { get; set; }

        public string Description { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
