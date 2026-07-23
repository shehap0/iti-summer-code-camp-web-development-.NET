using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay1.Model
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
       
        // Departmen has many Employees
        
       //public virtual HashSet<Employee> Employees { get; set; } = new HashSet<Employee>(); //Null
   
    }
}
