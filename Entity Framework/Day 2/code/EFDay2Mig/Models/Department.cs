using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
{
    public class Department
    {

        public int DepartmentId { get; set; }

        public string DeptName { get; set; }


        public virtual HashSet<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
        public virtual HashSet<Student> Students { get; set; } = new HashSet<Student>();

    }
}
