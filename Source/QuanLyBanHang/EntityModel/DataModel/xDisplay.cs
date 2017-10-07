namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("xDisplay")]
    public partial class xDisplay
    {
        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(255)]
        public string ParentName { get; set; }

        [Required]
        [StringLength(255)]
        public string Group { get; set; }

        public bool Showing { get; set; }

        [Required]
        [StringLength(255)]
        public string ColumnName { get; set; }

        public string FieldName { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string TextAlign { get; set; }

        public bool EnableEdit { get; set; }

        public int VisibleIndex { get; set; }

        public string Caption { get; set; }
    }
}
