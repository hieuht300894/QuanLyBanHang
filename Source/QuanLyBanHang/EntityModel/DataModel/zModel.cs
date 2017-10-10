namespace EntityModel.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class zModel : DbContext
    {
        public zModel()
            : base(Module.dbConnectString)
        {
        }

        public zModel(string conn)
            : base(conn)
        {
        }

        public virtual DbSet<xAccount> xAccount { get; set; }
        public virtual DbSet<xAgency> xAgency { get; set; }
        public virtual DbSet<xPersonnel> xPersonnel { get; set; }
        public virtual DbSet<xAppConfig> xAppConfig { get; set; }
        public virtual DbSet<xDisplay> xDisplay { get; set; }
        public virtual DbSet<xFeature> xFeature { get; set; }
        public virtual DbSet<xLayoutItemCaption> xLayoutItemCaption { get; set; }
        public virtual DbSet<xMsgDictionary> xMsgDictionary { get; set; }
        public virtual DbSet<xPermission> xPermission { get; set; }
        public virtual DbSet<xUserFeature> xUserFeature { get; set; }
        public virtual DbSet<xUserLog> xUserLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<xAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<xAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<xAgency>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<xAgency>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<xPersonnel>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<xPersonnel>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<xPersonnel>()
                .HasOptional(e => e.xAccount)
                .WithRequired(e => e.xPersonnel);

            modelBuilder.Entity<xAppConfig>()
                .Property(e => e.colBinary)
                .IsFixedLength();

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.ParentName)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.Group)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.TextAlign)
                .IsUnicode(false);

            modelBuilder.Entity<xFeature>()
                .Property(e => e.KeyID)
                .IsUnicode(false);

            modelBuilder.Entity<xFeature>()
                .Property(e => e.EN)
                .IsUnicode(false);

            modelBuilder.Entity<xFeature>()
                .HasMany(e => e.xUserFeatures)
                .WithOptional(e => e.xFeature)
                .HasForeignKey(e => e.IDFeature);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.FormName)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.LayoutControlName)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.LayoutControlItem)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.EN)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.Visibility)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.TextLocation)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.ControlAlignment)
                .IsUnicode(false);

            modelBuilder.Entity<xMsgDictionary>()
                .Property(e => e.FormName)
                .IsUnicode(false);

            modelBuilder.Entity<xMsgDictionary>()
                .Property(e => e.MsgName)
                .IsUnicode(false);

            modelBuilder.Entity<xMsgDictionary>()
                .Property(e => e.EN)
                .IsUnicode(false);

            modelBuilder.Entity<xPermission>()
                .HasMany(e => e.xAccounts)
                .WithOptional(e => e.xPermission)
                .HasForeignKey(e => e.IDPermission);

            modelBuilder.Entity<xPermission>()
                .HasMany(e => e.xUserFeatures)
                .WithRequired(e => e.xPermission)
                .HasForeignKey(e => e.IDUserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<xUserFeature>()
                .Property(e => e.IDFeature)
                .IsUnicode(false);
        }
    }
}
