using System;
using System.Data;


namespace SummerJulG3CSD03
{
    class Program
    {
        static void Main(string[] args)
        {


            #region OOP Violation [encapsulation]
            //Employee e1;   //class ->reference type //ZERO B  //null
            //e1 = new Employee(); //object/instance from Employee  //24B //heap
            ////////new + class=allocation +data initialization
            /////////memory  e1  id|0|  name|null|  age|0|  salary|0| 

            //e1.id = 1;
            //e1.name = "Sara";
            //e1.age = 22;
            //e1.salary = 1234;

            //Console.WriteLine(e1.id);
            //Console.WriteLine(e1.name);
            //Console.WriteLine(e1.age);
            //Console.WriteLine(e1.salary);


            //Employee e2 = new Employee();
            //////new + class=allocation +data initialization
            ///////memory  e2  id|0|  name|null|  age|0|  salary|0| 

            //Console.WriteLine("Enter id");
            //e2.id = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter name");
            //e2.name = Console.ReadLine();

            //Console.WriteLine("Enter age");
            //e2.age = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter salary");
            //e2.salary = decimal.Parse(Console.ReadLine());

            //Console.WriteLine(e2.id);
            //Console.WriteLine(e2.name);
            //Console.WriteLine(e2.age);
            //Console.WriteLine(e2.salary);
            #endregion

            #region OOP
            //Employee e1 = new Employee();
            //Employee e2 = new Employee();

            // e1.id = 33;

            //e1.SetId(1);
            //Console.WriteLine(e1.GetId());

            //e2.SetId(2);
            //Console.WriteLine(e2.GetId());

            //e1.Id = 1;  //call set
            //Console.WriteLine(e1.Id);  //call get

            //e1.SetId(int.Parse(Console.ReadLine()));


            //Console.WriteLine("Enter id");
            //e1.Id = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter name");
            //e1.Name = Console.ReadLine();

            //Console.WriteLine("Enter age");
            //e1.Age = int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter salary");
            //e1.Salary = decimal.Parse(Console.ReadLine());

            //////Console.WriteLine("================");
            //Console.WriteLine(e1.Print());
            //e1.Printv2();
            #endregion

            #region Pass value type to function by value
            //int x = 10, y = 20;

            //Console.WriteLine("Before Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");

            //Utility obj = new Utility();
            //obj.Swap(x, y);  //PASS VALUES swap(10,20)

            //Console.WriteLine("After Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");

            #endregion

            #region Pass value type to function by Reference[alias name]
            //int x = 10, y = 20;

            //Console.WriteLine("Before Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");

            //Utility obj = new Utility();
            //obj.SwapR(ref x, ref y);  //PASS references 

            //Console.WriteLine("After Swap");
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");

            #endregion

            #region Pass reference type by value === by reference
            //int[] arr = { 1, 2, 3, 4, 5 };
            //Utility obj = new Utility();

            ////obj.MultipleArrayByTen(arr);
            //obj.MultipleArrayByTen(ref arr);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            #endregion

            #region this
            /////any member function has hidden input parameter
            /////called className this
            //Employee e1 = new Employee();
            //Employee e2 = new Employee();
            //e1.SetId(1);  //cmpiler  SetId(e1,1)
            //e2.SetId(2);
            #endregion

            #region initialize object V01
            //Employee e1 = new Employee();
            ////new + classs = allocation + default initialization
            ///////memory[heap]  e1  id|0|  name|null|  age|0|  salary|0| 
            //e1.Id = 1;
            //e1.Name = "Sara";
            //e1.Age = 22;
            //e1.Salary = 1234;

            //Employee e2 = new Employee();
            //e2.Id = 1;
            //e2.Name = "Sara";
            //e2.Age = 22;
            //e2.Salary = 1234;

            #endregion

            #region initialize object V02

            //Employee e1 = new Employee();
            /////new + classs = allocation + default initialization
            /////memory[heap]  e1  id|0|  name|null|  age|0|  salary|0| 

            //e1.Initialize();
            //Console.WriteLine(e1.Print());

            //Employee e2 = new Employee();
            //e2.Initialize(1, "Eman", 22, 1234);
            //Console.WriteLine(e2.Print());

            #endregion

            #region initialize object V03

            //Employee e1 = new Employee();
            //////new + classs = allocation + default initialization
            /////////memory[heap]  e1  id|1|  name|sara|  age|22|  salary|1234| 
            //Employee e2 = new Employee();
            //Employee e3 = new Employee(2, "Ahmed", 21, 5678);

            //e3.Id = 3;

            //Console.WriteLine(e1.Print());
            //Console.WriteLine(e2.Print());
            //Console.WriteLine(e3.Print());

            /////constructor:
            /////special function inside class
            /////already exists [hidden]
            /////calling automatically -we cannot call ctor-
            /////when create object/instance from this class

            /////how to write ctor explicitly?
            /////1- has same name of class
            /////2- has no return type even void
            /////3- can be overloaded
            /////4- must be public
            #endregion

            //Employee e5 = new Employee();
            ////destructor
            ///
            #region static variable/class variable/ shared variable
            /////static variable
            /////member variable with keyword static
            /////static variable is variable that o.s will
            /////create ONLY one copy of it
            /////in memory regardless Number of objects created 
            /////static variable always ALIVE till app ends
            /////stored in heap
            /////static variable is called by class name not object name


            Employee e1 = new Employee();
            Employee e2 = new Employee();
            Employee e3 = new Employee();
            Employee e4 = new Employee();
            Employee E5 = new Employee();
       
            /////call static variable
            //Console.WriteLine(Employee.counter);

            //Employee.counter = 222;

            //Console.WriteLine(e1.GetCounter()); //not make sense

            Console.WriteLine(Employee.GetCounter());
            Console.WriteLine(Employee.Counter);
            #endregion

            #region LAb assignments
            ///class Employee
            ///id
            ///name
            ///age
            ///salary
            ///static counter=0
            ///use setters and getters or properties
            
            ///constructor()
            ///constructor(int,string,int,int)
            ///function that print (and return string only)
            ///

            ///in main
            ///one employee read and write
            // Employee e1 = new Employee();
            ///
            ///array of 3 employees read and write
            Employee[] employees = new Employee[3];
            employees[0] = new Employee();
            employees[1] = new Employee();
            employees[2] = new Employee();
           
            //for to read

            //for to print
            #endregion
        }
    }
}
