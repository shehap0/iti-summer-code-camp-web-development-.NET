using assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new(){Id = 1, Title = "laptop", Description = "nvidia gpu laptop", Price = 15000, Count =10},
            new(){Id = 2, Title = "mouse", Description = "Wireless mouse", Price = 500, Count = 50},
            new(){Id = 3, Title = "keyboard", Description = "mechanical keyboard", Price = 1200, Count = 30},
            new(){Id = 4, Title = "monitor", Description = "4K monitor", Price = 8000, Count = 15},
            new(){Id = 5, Title = "headphones", Description = "noise cancelling", Price = 2000, Count = 25},
        };

        public IActionResult Index()
        {
            ViewData[Constants.PageTitle] = "All Products";
            ViewData[Constants.NumberOfVisits] = 1250;
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ActualCreate(Product product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult ActualEdit(Product editedProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == editedProduct.Id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            product.Title = editedProduct.Title;
            product.Description = editedProduct.Description;
            product.Price = editedProduct.Price;
            product.Count = editedProduct.Count;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult ActualDelete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            products.Remove(product);
            return RedirectToAction("Index");
        }
    }
}
