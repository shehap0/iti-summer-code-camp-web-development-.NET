using dotNetSumMVCD01.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetSumMVCD01.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> emps = new List<Employee>()
        { 
            new Employee() { Id = 1, Name = "Bassem", Salary = 50000, Age = 25 },
            new Employee() { Id = 2, Name = "Mohamed", Salary = 50000, Age = 25 },
            new Employee() { Id = 3, Name = "Ali", Salary = 50000, Age = 25 },
            new Employee() { Id = 4, Name = "Hossam", Salary = 50000, Age = 25 },
            new Employee() { Id = 5, Name = "Nada", Salary = 50000, Age = 25 },
        };
        public IActionResult GetAll()
        {
            return View(emps);
        }
        public IActionResult GetById(int id)
        {
            var emp = emps.FirstOrDefault(e => e.Id == id);
            return View(emp);
        }
    }
}
