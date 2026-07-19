using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD08
{
    static class FilterBy
    {
        public static bool BySalary(Employee item)
        {
            return item.Salary > 7000;
        }

        public static bool ByDeptId(Employee item)
        {
            return item.DeptId == 20;
        }

        public static bool ByName(Employee item)
        {
            return item.Name.ToLower().Contains("a");
        }

        //INFINIT Functions
    }
}
