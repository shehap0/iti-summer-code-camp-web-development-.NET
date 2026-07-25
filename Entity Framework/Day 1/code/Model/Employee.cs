using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDay1.Model
{
    ////Employee work in one Department

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }


        ////Employee work in one Department

        //public int? DepartmentId { get; set; } //  fk => ? Allow NULL

        //public virtual Department Department { set; get; } //Null




    }
}
