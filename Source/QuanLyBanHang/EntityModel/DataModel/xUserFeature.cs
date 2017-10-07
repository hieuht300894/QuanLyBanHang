namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class xUserFeature
    {
        [Key]
        public int KeyID { get; set; }

        public int IDUserRole { get; set; }

        [StringLength(255)]
        public string IDFeature { get; set; }

        public bool IsAdd { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }

        public bool IsEnable { get; set; }

        public virtual xFeature xFeature { get; set; }

        public virtual xPermission xPermission { get; set; }
    }
}
