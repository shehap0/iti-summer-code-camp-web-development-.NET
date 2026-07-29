using dotNetSumMVCD03.Data.Context;
using dotNetSumMVCD03.Models;
using dotNetSumMVCD03.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dotNetSumMVCD03.Controllers
{
    public class EmployeeController : Controller
    {
        /*----------------------------------------------------------------*/
        public MyDbContext db = new MyDbContext();
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult IndexV1() //Without VM
        {
            var emps = db.Employees.Include(e => e.Department).ToList(); //Link //Join
            return View(emps);
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult IndexV2() //With VM
        {
            //Domain Mode (Need To Map)
            var emps = db.Employees.Include(e => e.Department).ToList(); //Link //Join
            //VM Model
            List<EmployeeReadVM> employeeReadVMs = emps.Select(e => new EmployeeReadVM //Mapping
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Salary = e.Salary,
                DepartmentName = e.Department.Name
            }).ToList();

            return View(employeeReadVMs);
        }
        /*----------------------------------------------------------------*/
        //Details
        /*----------------------------------------------------------------*/
        public IActionResult DetailsV1(int id) //Without VM
        {
            var emp = db.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return RedirectToAction("IndexV1");
            }
            return View(emp);
        }
        /*----------------------------------------------------------------*/
        public IActionResult DetailsV2(int id)
        {
            var emp = db.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (emp == null)
            {
                return RedirectToAction("IndexV2");
            }
            EmployeeReadVM employeeReadVM = new()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                DepartmentName = emp.Department.Name
            };
            return View(employeeReadVM);
        }
        /*----------------------------------------------------------------*/
        //Create
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV1() //Show Form (Without VM)
        {
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            return View();
            
        }
        [HttpPost]
        public IActionResult CreateV1(Employee emp) //Add Data in DB (Without VM)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("IndexV1");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult CreateV2() //Show Form (With VM)
        {
            //ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            //var depts = Helper.Helper.GetDeptsDropDown();

            EmployeeCreateVM departments = new()
            {
                Departments = Helper.Helper.GetDeptsDropDown()
            };

            return View(departments);

        }
        [HttpPost]
        public IActionResult CreateV2(EmployeeCreateVM emp) //Add Data in DB (With VM)
        {
            //Map from VM To Domain Model
            Employee empToCreate = new()
            {
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                DepartmentId = emp.DepartmentId
            };

            db.Employees.Add(empToCreate);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
        /*----------------------------------------------------------------*/
        //Edit
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult EditV1(int id) //Show Form (Without VM)
        {
            var emp = db.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == id);
            ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            return View(emp);

        }
        [HttpPost]
        public IActionResult EditV1(Employee emp) //Add Data in DB (Without VM)
        {
            var empToUpdate = db.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == emp.Id);
            if (empToUpdate == null)
            {
                return RedirectToAction("IndexV1");
            }
            empToUpdate.Name = emp.Name;
            empToUpdate.Age = emp.Age;
            empToUpdate.Salary = emp.Salary;
            empToUpdate.DepartmentId = emp.DepartmentId;

            db.Employees.Update(empToUpdate);
            db.SaveChanges();
            return RedirectToAction("IndexV1");
        }
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult EditV2(int id) //Show Form (With VM)
        {
            //ViewBag.Departments = new SelectList(db.Departments, "Id", "Name");
            //var depts = Helper.Helper.GetDeptsDropDown();

            var emp = db.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == id);

            EmployeeEditVM departments = new()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                DepartmentId = emp.DepartmentId,
                DepartmentName = emp.Department.Name,
                Departments = Helper.Helper.GetDeptsDropDown()
            };

            return View(departments);

        }
        [HttpPost]
        public IActionResult EditV2(EmployeeEditVM emp) //Add Data in DB (With VM)
        {
            var empToUpdate = db.Employees.Include(d => d.Department).FirstOrDefault(e => e.Id == emp.Id);
            if (empToUpdate == null)
            {
                return RedirectToAction("IndexV2");
            }
            //Map from VM To Domain Model
            empToUpdate = new()
            {
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                DepartmentId = emp.DepartmentId,
            };

            db.Employees.Update(empToUpdate);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
        /*----------------------------------------------------------------*/
        //Delete
        /*----------------------------------------------------------------*/
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var empToDelete = db.Employees.FirstOrDefault(e => e.Id == id);
            if (empToDelete == null)
            {
                return RedirectToAction("IndexV2");
            }
            db.Employees.Remove(empToDelete);
            db.SaveChanges();
            return RedirectToAction("IndexV2");
        }
    }
}
