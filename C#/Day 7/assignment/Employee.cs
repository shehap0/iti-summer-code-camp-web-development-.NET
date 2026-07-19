using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public HireDate HDate { get; set; }
        public Department Dept { get; set; }

        public Employee()
        {
            Id = 1;
            Name = "Default";
            Age = 22;
            Salary = 5000;
            HDate = new HireDate();
            Dept = new Department();
        }

        public Employee(int _id, string _name, int _age, double _salary, HireDate _hdate, Department _dept)
        {
            Id = _id;
            Name = _name;
            Age = _age;
            Salary = _salary;
            HDate = _hdate;
            Dept = _dept;
        }

        public override string ToString() {return $"{Id}:{Name}:{Age}:{Salary}:{HDate?.ToString()}:{Dept?.ToString()}";}

        public int CompareTo(Employee? other)
        {
            return this.HDate.Month.CompareTo(other.HDate.Month);
        }
    }
}
