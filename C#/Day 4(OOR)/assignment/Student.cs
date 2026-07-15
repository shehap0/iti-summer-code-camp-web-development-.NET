using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Student : Person
    {
        private int studentId;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public Student() : base()
        {
            studentId = 0;
        }

        public Student(string _name, int _studentId) : base(_name)
        {
            studentId = _studentId;
        }

        public override string PrintInfo()
        {
            return $"Name: {Name}, Student ID: {studentId}";
        }
    }
}
