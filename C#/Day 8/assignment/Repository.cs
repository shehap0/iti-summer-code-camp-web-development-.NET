using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Repository
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student(1, "ramadan", 22, "Male", "backend"),
                new Student(2, "shalaby", 27, "Male", "devops"),
                new Student(3, "Ziad", 23, "Male", "game dev"),
                new Student(4, "Mariem", 21, "Female", "sales"),
                new Student(5, "shehap", 20, "Male", "frontend"),
                new Student(6, "doma", 26, "Male", "bug bounty"),
                new Student(7, "esawy", 30, "Male", "tester"),
                new Student(8, "Laila", 24, "Female", "sales"),
                new Student(9, "Omar", 28, "Male", "Marketing"),
                new Student(10, "Dina", 29, "Female", "Sales")
            };
        }
    }
}
