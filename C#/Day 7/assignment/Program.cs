using System.Collections.Generic;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("### task A: single employee ###");
            Employee e1 = new Employee
            {
                Id = 1,
                Name = "shalaby",
                Age = 21,
                Salary = 6700,
                HDate = new HireDate { Day = 11, Month = 1, Year = 2026 },
                Dept = new Department { DeptId = 101, DeptName = "backend" }
            };
            Console.WriteLine(e1);
            Console.WriteLine();




            Console.WriteLine("### task B: array of 10 employees ###");
            Employee[] employees =
            {
                new Employee(1, "ramadan", 22, 5000, new HireDate(5, 6, 2005), new Department(1, "backend")),
                new Employee(2, "shalaby", 27, 8000, new HireDate(12, 2, 2010), new Department(7, "devops")),
                new Employee(3, "Ziad", 23, 6000, new HireDate(8, 9, 2008), new Department(4, "game dev")),
                new Employee(4, "Mariem", 21, 5500, new HireDate(3, 1, 2015), new Department(5, "sales")),
                new Employee(5, "shehap", 20, 4500, new HireDate(20, 7, 2012), new Department(2, "frontend")),
                new Employee(6, "doma", 26, 7000, new HireDate(14, 4, 2018), new Department(6, "bug bounty")),
                new Employee(7, "esawy", 30, 9000, new HireDate(25, 11, 2006), new Department(3, "tester")),
                new Employee(8, "Laila", 24, 4800, new HireDate(18, 8, 2019), new Department(3, "sales")),
                new Employee(9, "Omar", 28, 6500, new HireDate(7, 5, 2011), new Department(4, "Marketing")),
                new Employee(10, "Dina", 29, 7200, new HireDate(30, 10, 2009), new Department(5, "Sales"))
            };
// 1 backend
// 2 front end
// 3 testers
// 4 game dev
// 5 sales
// 6 bug bounty
// 7 devops

            Console.WriteLine("before sorting:");
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Array.Sort(employees);
            Console.WriteLine("after sorting:");
            foreach (var item in employees)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("### challenge 1: singleton ###");
            CompanySystem o1 = CompanySystem.CreateObject();
            CompanySystem o2 = CompanySystem.CreateObject();
            CompanySystem o3 = CompanySystem.CreateObject();
            Console.WriteLine(o1.GetHashCode());
            Console.WriteLine(o2.GetHashCode());
            Console.WriteLine(o3.GetHashCode());
            if (o1 == o2 && o2 == o3)
                Console.WriteLine("same object - singleton works!");
            Console.WriteLine();

            Console.WriteLine("### challenge 2: point equality ###");
            Point p1 = new Point { X = 3, Y = 4 };
            Point p2 = new Point { X = 3, Y = 4 };
            Point p3 = new Point { X = 5, Y = 6 };
            Console.WriteLine($"p1 = {p1}, p2 = {p2}, p3 = {p3}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
        }
    }
}
