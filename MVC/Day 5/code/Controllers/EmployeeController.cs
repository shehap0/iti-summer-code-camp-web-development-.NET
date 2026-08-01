using ASP.NETCoreD03.Data.Context;
using ASP.NETCoreD03.Models;
using AspNetCoreGeneratedDocument;
using dotNetSumMVCD04.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreD03.Controllers
{
    public class EmployeeController : Controller
    {
        /*------------------------------------------------------------------*/
        // Context => DB => Data Access
        private readonly AppDbContext db = new AppDbContext();
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            // Get All Employees
            // Map From Domain Model To VM
            var employeesReadVM = db.Employees
                .Include(e => e.Department)
                .Select(e => new EmployeeReadVM
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Salary = e.Salary,
                    ImageURL = e.ImageURL,
                    Department = e.Department!.Name
                }).ToList();

            return View(employeesReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = db.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return RedirectToAction("IndexV01");
            }

            // Map FromDomain Model To View Model
            var employeeReadVM = new EmployeeReadVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                ImageURL = employee.ImageURL,
                Department = employee.Department!.Name
            };

            return View(employeeReadVM);
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            var employeeCreateVM = new EmployeeCreateVM
            {
                Departments = GetDepartmentsForDropDown()
            };
            return View(employeeCreateVM);
        }
        /*------------------------------------------------------------------*/
        // V02
        [HttpPost]
        public IActionResult Create(EmployeeCreateVM employeeCreateVM)
        {
            // employeeCreateVM => Don't Have Id
            // Map From VM To Domain Model
            ModelState.Remove("Image");
            if (!ModelState.IsValid)
            {
                employeeCreateVM.Departments = GetDepartmentsForDropDown();
                return View(employeeCreateVM);
            }
            //Create Unique File Name For Image
            //Guid + Extension (.png,.jpg,.jpeg,...)
            var uniqFileName = Guid.NewGuid().ToString() + Path.GetExtension(employeeCreateVM.Image.FileName);
            //Create Folder Path
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images","Employee");
            //Create Folder If Not Exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //Create File Path
            var filePath = Path.Combine(folderPath, uniqFileName);
            //Save Image To Folder
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                employeeCreateVM.Image.CopyTo(stream);
            }

            var employee = new Employee
            {
                Name = employeeCreateVM.Name,
                Age = employeeCreateVM.Age,
                Salary = employeeCreateVM.Salary,
                ImageURL = "/images/Employee/" + uniqFileName,
                DepartmentId = employeeCreateVM.DepartmentId
            };

            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = db.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            // Map Domain Model To VM
            var employeeEditVM = new EmployeeEditVM
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                DepartmentId = employee.DepartmentId,
                DepartmentName = employee.Department!.Name,
                Departments = GetDepartmentsForDropDown()
            };
            return View(employeeEditVM);
        }
        /*------------------------------------------------------------------*/
        [HttpPost]
        public IActionResult Edit(EmployeeEditVM employeeEditVM)
        {
            //if (id != employee.Id)
            //{
            //    return RedirectToAction("IndexV01");
            //}
            //db.Employees.Update(employee);
            var employeeInDb = db.Employees.FirstOrDefault(e => e.Id == employeeEditVM.Id);
            if (employeeInDb == null)
            {
                return RedirectToAction("Index");
            }

            // Map From VM To Domain Model
            employeeInDb.Name = employeeEditVM.Name;
            employeeInDb.Age = employeeEditVM.Age;
            employeeInDb.Salary = employeeEditVM.Salary;
            employeeInDb.DepartmentId = employeeEditVM.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        public IActionResult Delete(int id)
        {
            var employee = db.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*------------------------------------------------------------------*/
        // Helper Method
        // DRY => Reusable Code => Don't Repeat Yourself
        private List<SelectListItem> GetDepartmentsForDropDown()
        {
            return db.Departments
             .Select(d => new SelectListItem
             {
                 Value = d.Id.ToString(),
                 Text = d.Name
             }).ToList();
        }
        /*------------------------------------------------------------------*/
    }
}
