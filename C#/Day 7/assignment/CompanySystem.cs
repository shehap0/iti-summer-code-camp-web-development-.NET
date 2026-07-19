using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class CompanySystem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private CompanySystem()
        {
            Id = 1;
            Name = "DefaultCompany";
        }

        private CompanySystem(int _id, string _name)
        {
            Id = _id;
            Name = _name;
        }

        static CompanySystem obj;

        public static CompanySystem CreateObject()
        {
            if (obj is null)
            {
                obj = new CompanySystem();
                return obj;
            }
            else
            {
                return obj;
            }
        }
    }
}
