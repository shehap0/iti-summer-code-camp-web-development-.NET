using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public HashSet<Student_Course> Student_Courses { get; set; } = new HashSet<Student_Course>();

    }
}
