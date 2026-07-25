using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Hospital
    {
        public int HospitalId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        //Hospital has many Doctors
        public virtual HashSet<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}