using assignment.Data.Context;
using assignment.Models;
using assignment.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace assignment.Controllers
{
    public class ProductController : Controller
    {
        /*----------------------------------------------------------------*/
        public MyDbContext db = new MyDbContext();
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult IndexV1()
        {
            var products = db.Products.Include(p => p.Category).ToList();
            return View(products);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult IndexV2()
        {
            var products = db.Products.Include(p => p.Category).ToList();
            List<ProductReadVM> productReadVMs = products.Select(p => new ProductReadVM
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Price = p.Price,
                Count = p.Count,
                CategoryName = p.Category.Name
            }).ToList();

            return View(productReadVMs);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult DetailsV1(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("IndexV1");
            }
            return View(product);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult DetailsV2(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return RedirectToAction("IndexV2");
            }
            ProductReadVM productReadVM = new()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryName = product.Category.Name
            };
            return View(productReadVM);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV1()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateV1(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("IndexV1");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV2()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = Helper.Helper.GetCategoriesDropDown()
            };

            return View(productCreateVM);
        }
        [HttpPost]
        public IActionResult CreateV2(ProductCreateVM product)
        {
            Product productToCreate = new()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId
            };

            db.Products.Add(productToCreate);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult EditV1(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View(product);
        }
        [HttpPost]
        public IActionResult EditV1(Product product)
        {
            var productToUpdate = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate == null)
            {
                return RedirectToAction("IndexV1");
            }
            productToUpdate.Title = product.Title;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.Count = product.Count;
            productToUpdate.CategoryId = product.CategoryId;

            db.Products.Update(productToUpdate);
            db.SaveChanges();
            return RedirectToAction("IndexV1");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult EditV2(int id)
        {
            var product = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);

            ProductEditVM productEditVM = new()
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Categories = Helper.Helper.GetCategoriesDropDown()
            };

            return View(productEditVM);
        }
        [HttpPost]
        public IActionResult EditV2(ProductEditVM product)
        {
            var productToUpdate = db.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate == null)
            {
                return RedirectToAction("IndexV2");
            }
            productToUpdate = new()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Count = product.Count,
                CategoryId = product.CategoryId,
            };

            db.Products.Update(productToUpdate);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var productToDelete = db.Products.FirstOrDefault(p => p.Id == id);
            if (productToDelete == null)
            {
                return RedirectToAction("IndexV2");
            }
            db.Products.Remove(productToDelete);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
    }
}
