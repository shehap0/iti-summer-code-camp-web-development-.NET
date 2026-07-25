using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
{
    public class Student_Course
    {
        public int Grade { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }   

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }


    }
}
