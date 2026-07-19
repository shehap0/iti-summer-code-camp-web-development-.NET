using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD07
{
    class Employee :IComparable<Employee>, ICloneable 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public HireDate HDate { get; set; }

        public Employee()
        {
            Id = 1;
            Name = "Sara";
            Age = 22;
            Salary = 1234;
            HDate =/* null;*/ new HireDate();
        }
        public Employee(int _id,string _name,int _age,decimal _salary,HireDate _hdate)
        {
            Id = _id;
            Name = _name;
            Age = _age;
            Salary = _salary;
            HDate = _hdate;
        }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{Salary}:{HDate?.ToString()}";
        }

        //public int CompareTo(object? obj)
        //{

        //   // return this.Name.CompareTo(obj.Name);// error  

        //    var right = obj as Employee;

        //    return this.Name.CompareTo(right.Name);
        //    return this.Age.CompareTo(right.Age);

        //    return this.HDate.Year.CompareTo(right.HDate.Year);
        //    return this.HDate.CompareTo(right.HDate);
        //}

        public object Clone()
        {
            return new Employee // caller this  e1
            {
                Id = this.Id,
                Name = this.Name,
                Age = this.Age,
                Salary = this.Salary,
                HDate = new HireDate { Day = this.HDate.Day, Month = this.HDate.Month, Year = this.HDate.Year },
            };
        }

        public int CompareTo(Employee? other)
        {
            return this.Age.CompareTo(other.Age);
        }
    }
}
