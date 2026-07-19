using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD08
{
    static class Utility
    {
        public static bool BySalary(Employee item)
        {
            return item.Salary > 7000;
        }

        public static bool ByDeptId(Employee item)
        {
            return item.DeptId == 20;
        }

        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        public static void PrintEmployee(Employee item)
        {
            Console.WriteLine(item);
        }

        public static int Add(int x,int y)
        {
            return x + y;
        }
    }
}
