using assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment.Data.Context
{
    public class AppDbContext : DbContext
    {
        /*------------------------------------------------------------------*/
        public AppDbContext() { }
        /*------------------------------------------------------------------*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        /*------------------------------------------------------------------*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Server=localhost,1433;Database=MVC day5;User Id=sa;Password=Shehap2005!;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        /*------------------------------------------------------------------*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var _categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Clothing" },
                new Category { Id = 3, Name = "Food" },
                new Category { Id = 4, Name = "Books" }
            };

            var _products = new List<Product>()
            {
                new Product { Id = 1, Title = "Laptop", Description = "High performance laptop", Price = 1500, Count = 10, ExpiryDate = new DateOnly(2025, 12, 31), CategoryId = 1, ImageURL = "/images/Product/Laptop.jpg" },
                new Product { Id = 2, Title = "T-Shirt", Description = "Cotton T-Shirt", Price = 25, Count = 50, ExpiryDate = new DateOnly(2026, 6, 30), CategoryId = 2, ImageURL = "/images/Product/T-Shirt.jpg" },
                new Product { Id = 3, Title = "Chocolate", Description = "Dark chocolate bar", Price = 5, Count = 100, ExpiryDate = new DateOnly(2025, 1, 15), CategoryId = 3, ImageURL = "/images/Product/Chocolate.jpg" },
                new Product { Id = 4, Title = "C# Programming", Description = "Learn C# programming", Price = 45, Count = 20, ExpiryDate = new DateOnly(2026, 12, 31), CategoryId = 4, ImageURL = "/images/Product/book.jpg" },
            };

            modelBuilder.Entity<Category>().HasData(_categories);
            modelBuilder.Entity<Product>().HasData(_products);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        /*------------------------------------------------------------------*/
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        /*------------------------------------------------------------------*/
    }
}
