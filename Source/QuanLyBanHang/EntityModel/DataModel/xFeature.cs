namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("xFeature")]
    public partial class xFeature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public xFeature()
        {
            xUserFeatures = new HashSet<xUserFeature>();
        }

        [Key]
        [StringLength(255)]
        public string KeyID { get; set; }

        [StringLength(255)]
        public string IDGroup { get; set; }

        [Required]
        [StringLength(255)]
        public string VN { get; set; }

        [Required]
        [StringLength(255)]
        public string EN { get; set; }

        public bool IsAdd { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<xUserFeature> xUserFeatures { get; set; }
    }
}
