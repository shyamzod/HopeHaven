using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HopeHaven1.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DbContext")
        {
        }

        public DbSet<Therapists> therapists { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
