using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD07
{
    class Utility
    {
        public static void SwapI(int left,int right)
        {
            int tmp = left;
            left = right;
            right = tmp;
        }

        public static void SwapS(string left, string right)
        {
            string tmp;
            tmp= left;
            left = right;
            right = tmp;
        }

        public static void SwapEmp(Employee left, Employee right)
        {
            Employee tmp;
            tmp = left;
            left = right;
            right = tmp;
        }

        public static void Swap<STU>(STU left, STU right)
        {
            STU tmp;
            tmp = left;
            left = right;
            right = tmp;
        }

    }
}
