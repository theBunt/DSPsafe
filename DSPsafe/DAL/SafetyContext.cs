using DSPsafe.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DSPsafe.DAL
{
    public class SafetyContext : DbContext
    {
        public SafetyContext() : base("AzureConnection")
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<SafetyDetail> SafetyDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }
    }
}