using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using TakeMEAPIServices.Interfaces;
using TakeMEAPIServices.Models;

namespace TakeMEAPIServices
{
    public class MyContext : DbContext, IMyContext
    {
        public MyContext() { }
        public MyContext(string connectionString) : base(connectionString) { }
        
        public IDbSet<MedicineUser> Medicine { get; set; }
        public IDbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<MedicineUser>().Property(d => d.MedicineId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Entity<MedicineUser>().HasKey(d => d.MedicineId);
        }
    }
}