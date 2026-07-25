using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDay2.Model
{
   
    public class Department
    {
        
        public int DepartmentId { get; set; }
        
        public string DeptName { get; set; }
            


        public virtual HashSet<Employee> Employees { set; get; } = new HashSet<Employee>();

        public override string ToString()
        {
            return $" {DepartmentId} , {DeptName}";
        }


    }
}
