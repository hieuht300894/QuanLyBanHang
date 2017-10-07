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

        public virtual DbSet<xAccount> eAccounts { get; set; }
        public virtual DbSet<xAgency> eAgencies { get; set; }
        public virtual DbSet<xPersonnel> ePersonnels { get; set; }
        public virtual DbSet<xAppConfig> xAppConfigs { get; set; }
        public virtual DbSet<xDisplay> xDisplays { get; set; }
        public virtual DbSet<xFeature> xFeatures { get; set; }
        public virtual DbSet<xLayoutItemCaption> xLayoutItemCaptions { get; set; }
        public virtual DbSet<xMsgDictionary> xMsgDictionaries { get; set; }
        public virtual DbSet<xPermission> xPermissions { get; set; }
        public virtual DbSet<xUserFeature> xUserFeatures { get; set; }
        public virtual DbSet<xUserLog> xUserLogs { get; set; }

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
                .HasOptional(e => e.eAccount)
                .WithRequired(e => e.ePersonnel);

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
                .HasMany(e => e.eAccounts)
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
