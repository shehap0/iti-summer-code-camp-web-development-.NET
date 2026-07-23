using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        //Doctor work in one Hospital
        public int? HospitalId { get; set; }
        public virtual Hospital Hospital { set; get; }
    }
}