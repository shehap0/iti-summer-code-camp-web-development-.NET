using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public delegate bool StudentDelegate(Student item);

    static class Filtration
    {
        public static List<Student> FilterByAny(List<Student> param, StudentDelegate del){
            var result = new List<Student>();
            foreach (var item in param) if (del(item)) result.Add(item);
            return result;
            }
    }
}