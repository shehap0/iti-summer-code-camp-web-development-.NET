

using EFDay1.Entities;
using EFDay1.Model;

namespace EFDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            MyContext Db = new MyContext();

            #region db
            //EF Database Creation Strategy
            // Create DB for First Time Only

            Db.Database.EnsureDeleted();      /// Aplicable for development Only

            Db.Database.EnsureCreated();


            #endregion

            Department D = new Department { DeptName = "SD"};
           
            //Employee e1 = new Employee { Name = "Ali", Age = 20, Salary = 3000, DepartmentId = 1 };

            Employee e2 = new Employee { Name = "Heba", Age = 20, Salary = 3000 };
            Employee e3 = new Employee { Name = "Ahmed", Age = 20, Salary = 3000 };




            // Add Employee Object in Local Stroage


            //Db.Departments.Add(D);
            //Db.Employees.Add(e1);
            Db.Employees.Add(e2);
            Db.Employees.Add(e3);




            //Affect to Datebase
            Db.SaveChanges();
            
        }
    }
}
