namespace TakeMEAPIServices.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TakeMeModel : DbContext
    {
        public TakeMeModel()
            : base("name=TakeMeModel")
        {
        }

        public virtual DbSet<MedicineUser> MedicineUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineUser>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineUser>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<MedicineUser>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MedicineUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
