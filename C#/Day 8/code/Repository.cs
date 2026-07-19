using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD08
{
    //like Database
    class Repository
    {
        public static List<Employee> GetEmployees()
        {
            return new List<Employee>() 
            {
                new Employee{Id=1,Name="Ali",Age=24,Salary=1234,DeptId=10},
                new Employee{Id=2,Name="Sara",Age=22,Salary=2234,DeptId=20},
                new Employee{Id=3,Name="Ziad",Age=23,Salary=3234,DeptId=20},
                new Employee{Id=4,Name="Osama",Age=22,Salary=4234,DeptId=30},
                new Employee{Id=5,Name="Ayat",Age=30,Salary=5234,DeptId=30},
                new Employee{Id=6,Name="Saeed",Age=29,Salary=6234,DeptId=20},
                new Employee{Id=7,Name="Ahmed",Age=28,Salary=7234,DeptId=20},
                new Employee{Id=8,Name="Reham",Age=27,Salary=8234,DeptId=10},
                new Employee{Id=9,Name="Mayar",Age=26,Salary=9234,DeptId=10},
                new Employee{Id=10,Name="Abdullah",Age=25,Salary=10234,DeptId=10}
            };
        }
    }
}
