using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1

            Student student = new Student("shehap sherif", 23200274);
            Console.WriteLine(student.PrintInfo());

            #endregion

            #region Task 2

            Professor prof = new Professor("Dr. magdy shyboob");
            Department dept = new Department("software engineering", prof);
            Console.WriteLine(dept.PrintInfo());

            #endregion

            #region Task 3

            House house = new House("67 elsafa street", 505);
            Console.WriteLine(house.PrintInfo());

            #endregion

            #region Task 4

            Patient patient = new Patient("bahaa sultan");
            Doctor doctor = new Doctor("amr diab");
            Console.WriteLine(doctor.Checkup(patient));

            #endregion
        }
    }
}
