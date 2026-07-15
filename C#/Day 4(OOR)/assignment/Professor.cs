using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Professor
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Professor()
        {
            name = "";
        }

        public Professor(string _name)
        {
            name = _name;
        }

        public string PrintInfo()
        {
            return $"Professor Name: {name}";
        }
    }
}
