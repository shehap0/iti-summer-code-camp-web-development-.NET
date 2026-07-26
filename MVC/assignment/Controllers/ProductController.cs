using assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product() { Id = 1, Title = "laptop", Description = "nvidia gpu laptop", Price = 15000, Count = 10 },
            new Product() { Id = 2, Title = "mouse", Description = "Wireless mouse", Price = 500, Count = 50 },
            new Product() { Id = 3, Title = "keyboard", Description = "mechanical keyboard", Price = 1200, Count = 30 },
            new Product() { Id = 4, Title = "monitor", Description = "4K monitor", Price = 8000, Count = 15 },
            new Product() { Id = 5, Title = "headphones", Description = "noise cancelling", Price = 2000, Count = 25 },
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
