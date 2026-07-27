using dotNetSumMVCD02.Models;
using dotNetSumMVCD02.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dotNetSumMVCD02.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> emps = new List<Employee>()
        {
            new(){Id = 1, Name = "Bassem", Age = 25, Salary = 5000},
            new(){Id = 2, Name = "Mohamed", Age = 25, Salary = 5000},
            new(){Id = 3, Name = "Aly", Age = 25, Salary = 5000},
            new(){Id = 4, Name = "Basmala", Age = 25, Salary = 5000},
            new(){Id = 5, Name = "Medhat", Age = 25, Salary = 5000},
        };
        //ViewData
        //ViewBag
        public IActionResult GetAll()
        {

            ViewData[Constants.NumberOfVisits] = 859;
            ViewData[Constants.PageTitle] = "All Employees"; //Similar to LocalStorage in JS

            ViewBag.Hamada = "Hamada"; //=> ViewData["Hamada"] = "Hamada"
            return View(emps);
        }

        public IActionResult GetById(int id) {
            var existEmp = emps.FirstOrDefault(emp => emp.Id == id); //null
            if (existEmp == null)
            {
                //NotFound();
                return RedirectToAction("GetAll");
            }
            EmployeeReadVM emp;
            emp = new EmployeeReadVM()
            {
                Id = existEmp.Id,
                Name = existEmp.Name,
                Age = existEmp.Age,
                Score = 850,
                UniqName = $"{existEmp.Id} - {existEmp.Name}"
            };
            return View(emp);
        }

        //GetAll, GetById, Create, Edit, Delete
        //To Do => Access DB

        //Create => Get, Post => 2 Steps:
        //Get => View Form
        //Post => Receive Data From User

        public IActionResult Create() //Get
        {
            return View();
        }

        //V1
        //public IActionResult ActualCreate(int id, string name, int age, decimal salary) //Post
        //{
        //    var newEmp = new Employee()
        //    {
        //        Id = id,
        //        Name = name,
        //        Age = age,
        //        Salary = salary
        //    };
        //    emps.Add(newEmp);
        //    return RedirectToAction("GetAll");
        //}

        //No Overloading
        //V2
        public IActionResult ActualCreate(Employee employee) //Post
        {
            emps.Add(employee);
            return RedirectToAction("GetAll");
        }

        //Edit => Get, Post
        //Get => View Form to User
        //Post => Receive Data From User

        public IActionResult Edit(int id) //Get
        {
            var empToUpdate = emps.FirstOrDefault(emp => emp.Id == id);
            if (empToUpdate == null)
            {
                return RedirectToAction("GetAll");
            }
            return View(empToUpdate);
        }

        public IActionResult ActualEdit(Employee editedEmp) //Post
        {
            var empToUpdate = emps.FirstOrDefault(emp => emp.Id == editedEmp.Id);
            if (empToUpdate == null)
            {
                return RedirectToAction("GetAll");
            }
            empToUpdate.Name = editedEmp.Name;
            empToUpdate.Age = editedEmp.Age;
            empToUpdate.Salary = editedEmp.Salary;
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            var empToDelete = emps.FirstOrDefault(emp => emp.Id == id);
            if (empToDelete == null)
            {
                return RedirectToAction("GetAll");
            }
            emps.Remove(empToDelete);
            return RedirectToAction("GetAll");
        }

        //Bonus: Show Pop-up to confirm deletion
        //Do you want to Delete this Employee? => Yes, No
        //Yes => Delete, No => Redirect to GetAll
        //Can use JS
    }
}
