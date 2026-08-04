using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Title)
            .IsUnique(false);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        Seed(modelBuilder);
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        var electronics = new Category { Id = 1, Name = "Electronics" };
        var fashion = new Category { Id = 2, Name = "Fashion" };
        var food = new Category { Id = 3, Name = "Food & Beverages" };
        var sports = new Category { Id = 5, Name = "Sports & Outdoors" };

        modelBuilder.Entity<Category>().HasData(electronics, fashion, food, sports);

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Title = "Aurora Wireless Headphones",
                Description = "Immersive over-ear headphones with active noise cancellation and 40-hour battery life.",
                Price = 249.99m,
                Count = 32,
                ExpiryDate = new DateTime(2027, 12, 31),
                CategoryId = 1,
                ImagePath = "/images/products/headphones.jpg"
            },
            new Product
            {
                Id = 2,
                Title = "Nebula Smart Watch",
                Description = "Track your fitness and notifications with a vivid AMOLED display and 7-day battery.",
                Price = 199.00m,
                Count = 18,
                ExpiryDate = new DateTime(2027, 10, 15),
                CategoryId = 1,
                ImagePath = "/images/products/smartwatch.jpg"
            },
            new Product
            {
                Id = 3,
                Title = "Midnight Denim Jacket",
                Description = "A timeless classic cut from premium stretch denim for everyday comfort.",
                Price = 89.50m,
                Count = 45,
                ExpiryDate = new DateTime(2028, 01, 31),
                CategoryId = 2,
                ImagePath = "/images/products/jacket.jpg"
            },
            new Product
            {
                Id = 4,
                Title = "Organic Arabica Beans",
                Description = "Single-origin medium roast coffee beans with notes of chocolate and caramel.",
                Price = 14.25m,
                Count = 120,
                ExpiryDate = new DateTime(2026, 12, 05),
                CategoryId = 3,
                ImagePath = "/images/products/coffee.jpg"
            },
            new Product
            {
                Id = 5,
                Title = "Laptops",
                Description = "Looking for nre laptop? explore range of laptops.",
                Price = 34.99m,
                Count = 60,
                ExpiryDate = new DateTime(2027, 06, 30),
                CategoryId = 1,
                ImagePath = "/images/products/laptops.jpg"
            },
            new Product
            {
                Id = 6,
                Title = "TrailBlazer Running Shoes",
                Description = "Feather-light performance sneakers engineered for long-distance comfort.",
                Price = 129.99m,
                Count = 27,
                ExpiryDate = new DateTime(2027, 09, 20),
                CategoryId = 5,
                ImagePath = "/images/products/shoes.jpg"
            }
        );
    }
}
