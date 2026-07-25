using EFDay2.Entites;
using EFDay2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyContext Db = new MyContext();

            #region  EFV01

            Db.Database.EnsureDeleted();
            Db.Database.EnsureCreated();

            Employee e1 = new Employee { Name = "Sara", Age = 20, Salary = 3000 };
            Department d1 = new Department { DeptName = "SD" };



            Db.Employees.Add(e1);
            Db.Departments.Add(d1);



            Db.SaveChanges();

            #endregion


            #region EFV02
            //Db.Database.EnsureDeleted();
            //Db.Database.EnsureCreated();


            //Employee emp = new Employee { Name = "Heba", Age = 22, Salary = 4000, DepartmentId = 1 };


            //Db.Employees.Add(emp);

            //Db.SaveChanges();


            #endregion


            #region Add Departments

            Db.Database.EnsureCreated();

            Department department1 = new Department { DeptName = "SD" };
            Department department2 = new Department { DeptName = "UI" };
            Department department3 = new Department { DeptName = "Mobile" };


            Db.Departments.Add(department1);
            Db.Add(department2);
            Db.Add(department3);

            Db.SaveChanges();

            #endregion


            #region Add Employee
           
            Db.Database.EnsureCreated();

            //Connect to db to Get Department Object // linq to EF
            //var D = Db.Departments.First();

            //Employee e1 = new Employee { Name = "Ali", Age = 15, Salary = 300, Department = D };

            //Db.Add(e1);


            Employee e2 = new Employee { Name = "Hala", Age = 20, Salary = 5000, DepartmentId = 1 };
            Employee e3 = new Employee { Name = "Mohammed", Age = 22, Salary = 4000, DepartmentId = 2 };
            Employee e4 = new Employee { Name = "Ahmed", Age = 30, Salary = 3466, DepartmentId = 3 };
            Employee e5 = new Employee { Name = "Heba", Age = 30, Salary = 6000, DepartmentId = 2 };

            Db.AddRange(new[] { e2, e3, e4, e5 });

            Db.SaveChanges();

            #endregion


            #region Linq Query

            var res = Db.Employees.Where(e => e.Age > 20);


            //var res2 = from i in Db.Employees
            //           select i;

            //var res3 = (from i in Db.Employees
            //            select i).First();

            //// Eager Loading

            //var res4 = Db.Employees.Include(e => e.Department).Where(e => e.Salary > 3000);

            //foreach (var employee in res4)
            //{
            //    Console.WriteLine(employee);
            //}

            //Console.WriteLine();
            //Console.WriteLine(res3);

            #endregion


            #region Update Employee

            // // catch to update

            //var emp = Db.Employees.First(e => e.Id == 5);


            //Console.WriteLine(emp);

            ////emp.Name = "ALaa";

            //Console.WriteLine(emp);

            #endregion


            #region Delete

            // catch to delete

            var emp = Db.Employees.First(e => e.Id == 3);

            Db.Employees.Remove(emp);

            Db.SaveChanges();

            #endregion




        }
    }
}
