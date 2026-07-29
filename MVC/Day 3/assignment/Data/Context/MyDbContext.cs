using assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment.Data.Context
{
    public class MyDbContext : DbContext
    {
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost,1433;Database=MVC;User Id=sa;Password=Shehap2005!;TrustServerCertificate=true;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Books" },
                new Category { Id = 4, Name = "Sports" },
                new Category { Id = 5, Name = "Food" },
            };

            var products = new List<Product>
            {
                new Product { Id = 1, Title = "Laptop", Description = "High performance laptop", Price = 15000, Count = 10, CategoryId = 1 },
                new Product { Id = 2, Title = "T-Shirt", Description = "Cotton T-Shirt", Price = 200, Count = 50, CategoryId = 2 },
                new Product { Id = 3, Title = "C# Book", Description = "Learn C# programming", Price = 350, Count = 30, CategoryId = 3 },
                new Product { Id = 4, Title = "Football", Description = "Professional football", Price = 500, Count = 25, CategoryId = 4 },
                new Product { Id = 5, Title = "Chocolate", Description = "Dark chocolate bar", Price = 50, Count = 100, CategoryId = 5 },
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
