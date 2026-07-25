using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFDay2.Model
{
    // How to write Model Classes with EF Runtime
    //1- Ef Conventions
    //2- Data Annotations    ==> using System.ComponentModel.DataAnnotations;
    //3- Fluent Api   ==> OnModelCreating
    //4- External Configuration class  

 
    //1- Ef Conventions
    // 1- PK => premitive int ( int , long int)  Id or ClassNameId
    // 2- Pk => identity Column
    // 3- any Value type column => not null (age ,salary)
    // 4- any Reference type column => Allow Null  (name)
    // 5- String => nvarchar(max) => 5GB
    


    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // int? TO  make age => Allow null 
        public int Age { get; set; }

        public decimal Salary { get; set; }


        // EF Runtime aware that this prop in fk for Department class
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; } 


        public override string ToString() =>
            $"{Id} , {Name} , {Age}, {Salary} , {DepartmentId}, ///{Department}//";
        

    }
}
