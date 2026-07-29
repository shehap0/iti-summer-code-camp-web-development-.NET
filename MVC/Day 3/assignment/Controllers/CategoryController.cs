using assignment.Data.Context;
using assignment.Models;
using assignment.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment.Controllers
{
    public class CategoryController : Controller
    {
        /*----------------------------------------------------------------*/
        public MyDbContext db = new MyDbContext();
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult IndexV1()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult IndexV2()
        {
            var categories = db.Categories.ToList();
            List<CategoryReadVM> categoryReadVMs = categories.Select(c => new CategoryReadVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(categoryReadVMs);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult DetailsV1(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return RedirectToAction("IndexV1");
            }
            return View(category);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult DetailsV2(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return RedirectToAction("IndexV2");
            }
            CategoryReadVM categoryReadVM = new()
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(categoryReadVM);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateV1(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("IndexV1");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateV2(CategoryCreateVM category)
        {
            Category categoryToCreate = new()
            {
                Name = category.Name
            };

            db.Categories.Add(categoryToCreate);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult EditV1(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult EditV1(Category category)
        {
            var categoryToUpdate = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (categoryToUpdate == null)
            {
                return RedirectToAction("IndexV1");
            }
            categoryToUpdate.Name = category.Name;

            db.Categories.Update(categoryToUpdate);
            db.SaveChanges();
            return RedirectToAction("IndexV1");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult EditV2(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);

            CategoryEditVM categoryEditVM = new()
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(categoryEditVM);
        }
        [HttpPost]
        public IActionResult EditV2(CategoryEditVM category)
        {
            var categoryToUpdate = db.Categories.FirstOrDefault(c => c.Id == category.Id);
            if (categoryToUpdate == null)
            {
                return RedirectToAction("IndexV2");
            }
            categoryToUpdate = new()
            {
                Name = category.Name
            };

            db.Categories.Update(categoryToUpdate);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoryToDelete = db.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryToDelete == null)
            {
                return RedirectToAction("IndexV2");
            }
            db.Categories.Remove(categoryToDelete);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
    }
}
