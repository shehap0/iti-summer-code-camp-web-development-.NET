using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
{
    public class Course
    {
        [Key]
        public int Crs_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [NotMapped]
        public DateTime? RegisterTime { get; set; }

        public virtual HashSet<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

        public HashSet<Student_Course> Student_Courses { get; set; } = new HashSet<Student_Course>();

    }
}
