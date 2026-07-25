using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay2Mig.Models
{
    public class Instructor
    {
        [Key]  
        public int Ins_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [EmailAddress] 
        [StringLength(50)]
        public string Email { get; set; }
        [NotMapped]     
        public DateTime? RegisterTime { get; set; } = DateTime.Now;

        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual HashSet<Course> Courses { get; set; } = new HashSet<Course>();


    }
}
