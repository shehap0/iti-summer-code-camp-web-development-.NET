using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Doctor
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Doctor()
        {
            name = "";
        }

        public Doctor(string _name)
        {
            name = _name;
        }

        public string PrintInfo()
        {
            return $"Doctor Name: {name}";
        }

        public string Checkup(Patient _patient)
        {
            return $"Doctor {name} is currently examining Patient {_patient.Name}";
        }
    }
}
