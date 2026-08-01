using assignment.Data.Context;
using assignment.Models;
using assignment.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public class CategoryController : Controller
    {
        /*------------------------------------------------------------------*/
        private readonly AppDbContext db = new AppDbContext();
        /*------------------------------------------------------------------*/
        public IActionResult Index()
        {
            var categories = db.Categories.Select(c => new CategoryReadVM
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return View(categories);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            var categoryReadVM = new CategoryReadVM
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(categoryReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryCreateVM);
            }

            var category = new Category
            {
                Name = categoryCreateVM.Name!
            };

            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            var categoryEditVM = new CategoryEditVM
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(categoryEditVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(CategoryEditVM categoryEditVM)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryEditVM);
            }

            var categoryInDb = db.Categories.FirstOrDefault(c => c.Id == categoryEditVM.Id);
            if (categoryInDb == null)
            {
                return RedirectToAction("Index");
            }

            categoryInDb.Name = categoryEditVM.Name!;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
    }
}
