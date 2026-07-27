using dotNetSumMVCD01.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetSumMVCD01.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Title = "Laptop", Description = "High performance laptop", Price = 15000, Count = 10 },
            new Product() { Id = 2, Title = "Mouse", Description = "Wireless mouse", Price = 500, Count = 50 },
            new Product() { Id = 3, Title = "Keyboard", Description = "Mechanical keyboard", Price = 1200, Count = 30 },
            new Product() { Id = 4, Title = "Monitor", Description = "27 inch 4K monitor", Price = 8000, Count = 15 },
            new Product() { Id = 5, Title = "Headphones", Description = "Noise cancelling", Price = 2000, Count = 25 },
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}
