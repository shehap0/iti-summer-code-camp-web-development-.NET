using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Person()
        {
            name = "";
        }

        public Person(string _name)
        {
            name = _name;
        }

        public virtual string PrintInfo()
        {
            return $"Name: {name}";
        }
    }
}
