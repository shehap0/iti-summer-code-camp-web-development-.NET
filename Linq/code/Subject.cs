using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDAY1
{
    public class Subject
    {
        // Properties
        public int Code { get; set; }
        public string Name { get; set; }

        // Constructor
        public Subject(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public Subject()
        {
        }
        public override string ToString()
        {
            return $"{Name} (Code: {Code})";
        }

        //public override string ToString()
        //{
        //    return $"{Name} ";
        //}
    }
}
