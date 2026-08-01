using ASP.NETCoreD03.Data.Context;
using ASP.NETCoreD03.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreD03.Controllers
{
    public class DepartmentController : Controller
    {
        /*------------------------------------------------------------------*/
        // Context => DB => Data Access
        private readonly AppDbContext db = new AppDbContext();
        /*------------------------------------------------------------------*/
        public IActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create() // View Form
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/

    }
}
