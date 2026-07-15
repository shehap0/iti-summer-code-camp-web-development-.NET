using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Patient
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Patient()
        {
            name = "";
        }

        public Patient(string _name)
        {
            name = _name;
        }

        public string PrintInfo()
        {
            return $"Patient Name: {name}";
        }
    }
}
