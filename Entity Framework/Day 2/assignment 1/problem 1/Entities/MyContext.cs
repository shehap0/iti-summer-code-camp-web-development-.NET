using Microsoft.EntityFrameworkCore;
using problem_1.Model;

namespace problem_1.Entities
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=problem 1;User Id=sa;Password=Shehap2005!;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Musician> Musicians { get; set; }
        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
    }
}
