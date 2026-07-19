using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD08
{
    //inside namespace class,struct,enum,interface,delegate
    //inside namespace there are 2 access modifiers
    //1-public[RECOMMENDED]: Dt can be used inside and outside project 
    //2-internal[default]: Dt can be used inside project ONLY
    //model
    public class Employee //m
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{Salary}:{DeptId}";
        }
    }

    class Department //1
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public Department()
        {
            DeptId = 10;
            DeptName = ".NET";
        }
    }
}
