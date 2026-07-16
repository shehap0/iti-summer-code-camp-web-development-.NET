using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD06
{
    public class Employee
    {
        int id;
        string name;
        int age;
        decimal salary;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public Employee()
        {
            id = 1;
            name = "Sara";
            age = 22;
            salary = 1234;
        }

        public Employee(int _id,string _name,int _age,decimal _salary)
        {
            id = _id;
            name = _name;
            age = _age;
            salary = _salary;
        }

        //public string Print()
        //{
        //    return $"{id}:{name}:{age}:{salary}";
        //}


        public override string ToString()
        {
            return $"{id}:{name}:{age}:{salary}";
        }

    }

    class SalesEmployee : Employee
    {

    }

    class AnnualEmployee : SalesEmployee { }
}
