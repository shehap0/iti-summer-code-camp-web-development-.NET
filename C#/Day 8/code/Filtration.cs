using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD08
{
    static class Filtration
    {
        public static List<Employee> FilterByDeptId(List<Employee> param)
        {
            var result= new List<Employee>();
            foreach (var item in param) 
            {
                if (item.DeptId == 10)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Employee> FilterBySalary(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (var item in param)
            {
                if (item.Salary > 5000)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Employee> FilterByName(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (var item in param)
            {
                //if (item.Name.Contains("m")|| item.Name.Contains("M"))
                if (item.Name.ToLower().Contains("m"))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //////////////////////////
        public static List<Employee> FilterByAny(List<Employee> param)
        {
            var result = new List<Employee>();
            foreach (var item in param)
            {
                if (FilterBy.ByDeptId(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        //////////////////////////
        public static List<Employee> FilterByDelegate(List<Employee> param,MyDelegate del1)
        {
            var result = new List<Employee>();
            foreach (var item in param)
            {
                if (del1(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }


    }
}
