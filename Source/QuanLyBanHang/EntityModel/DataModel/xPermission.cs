namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class xPermission
    {
        public xPermission()
        {
            xAccounts = new HashSet<xAccount>();
            xUserFeatures = new HashSet<xUserFeature>();
        }

        [Key]
        public int KeyID { get; set; }
        public int IDAgency { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnable { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual ICollection<xAccount> xAccounts { get; set; }
        public virtual ICollection<xUserFeature> xUserFeatures { get; set; }
    }
}
