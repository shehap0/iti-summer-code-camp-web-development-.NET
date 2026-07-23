using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Model
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        //each appointment involves one doctor and one patient
        public int? DoctorId { get; set; }
        public virtual Doctor Doctor { set; get; }
        public int? PatientId { get; set; }
        public virtual Patient Patient { set; get; }
    }
}