namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class xAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPersonnel { get; set; }
        public string PersonelName { get; set; }
        public int IDAgency { get; set; }
        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public int? IDPermission { get; set; }
        public string PermissionName { get; set; }
        public bool IsEnable { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual xPersonnel xPersonnel { get; set; }
        public virtual xPermission xPermission { get; set; }
    }
}
