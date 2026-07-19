using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }

        public Student(int id, string name, int age, string gender, string departmentName)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            DepartmentName = departmentName;
        }

        public override string ToString(){return $"id:{Id}, name:{Name}, age:{Age}, gender:{Gender}, DepartmentName{DepartmentName}";}
    }
}
