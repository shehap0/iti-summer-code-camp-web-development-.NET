using Microsoft.EntityFrameworkCore;
using problem_2.Model;

namespace problem_2.Entities
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=problem 2;User Id=sa;Password=Shehap2005!;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<SalesOffice> SalesOffices { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<PropertyOwner> PropertyOwners { get; set; }
    }
}
