using assignment.Data.Context;
using assignment.Models;
using assignment.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace assignment.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext db = new AppDbContext();

        public IActionResult Index()
        {
            var productsReadVM = db.Products
                .Include(p => p.Category)
                .Select(p => new ProductReadVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    Count = p.Count,
                    ExpiryDate = p.ExpiryDate,
                    Category = p.Category!.Name
                }).ToList();

            return View(productsReadVM);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = db.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productReadVM = new ProductReadVM
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                ExpiryDate = product.ExpiryDate,
                Category = product.Category!.Name
            };

            return View(productReadVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var productCreateVM = new ProductCreateVM
            {
                Categories = GetCategoriesForDropDown()
            };
            return View(productCreateVM);
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            if (!ModelState.IsValid)
            {
                productCreateVM.Categories = GetCategoriesForDropDown();
                return View(productCreateVM);
            }

            var product = new Product
            {
                Title = productCreateVM.Title!,
                Description = productCreateVM.Description,
                Price = productCreateVM.Price,
                Count = productCreateVM.Count,
                ExpiryDate = productCreateVM.ExpiryDate,
                CategoryId = productCreateVM.CategoryId
            };

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var productEditVM = new ProductEditVM
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                ExpiryDate = product.ExpiryDate,
                CategoryId = product.CategoryId,
                CategoryName = product.Category!.Name,
                Categories = GetCategoriesForDropDown()
            };
            return View(productEditVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM productEditVM)
        {
            if (!ModelState.IsValid)
            {
                productEditVM.Categories = GetCategoriesForDropDown();
                return View(productEditVM);
            }

            var productInDb = db.Products.FirstOrDefault(p => p.Id == productEditVM.Id);
            if (productInDb == null)
            {
                return RedirectToAction("Index");
            }

            productInDb.Title = productEditVM.Title!;
            productInDb.Description = productEditVM.Description;
            productInDb.Price = productEditVM.Price;
            productInDb.Count = productEditVM.Count;
            productInDb.ExpiryDate = productEditVM.ExpiryDate;
            productInDb.CategoryId = productEditVM.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetCategoriesForDropDown()
        {
            return db.Categories
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
        }
    }
}
