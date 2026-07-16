using System;
using System.Data;






namespace SummerJulG3CSD06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Value Type
            //int x = 10;
            //int y = 20;

            //x = y; //assign values
            //y = 55;
            //Console.WriteLine($"x={x}");
            //Console.WriteLine($"y={y}");
            #endregion

            #region Reference Type
            //Employee e1 = new Employee();
            //Employee e2 = new Employee(1, "Osama", 21, 5678);


            ///////////hashcode -> identical number for each object in memory
            //Console.WriteLine("Before e1=e2");
            //Console.WriteLine($"e1 identity {e1.GetHashCode()}");
            //Console.WriteLine($"e2 identity {e2.GetHashCode()}");

            //e1 = e2; //assign referenceType=ReferenceType
            ////////////////////Assign Reference

            //Console.WriteLine("After e1=e2");
            //Console.WriteLine($"e1 identity {e1.GetHashCode()}");
            //Console.WriteLine($"e2 identity {e2.GetHashCode()}");



            #endregion

            #region System.Object
            //Employee e2 = new Employee(1, "Osama", 21, 5678);

            ////Console.WriteLine(e2.ToString());
            //Console.WriteLine(e2);  //call .ToString()



            //Object o1 = new Employee();
            //Console.WriteLine(o1.GetType().Name);
            #endregion

            #region create object via named parameter Less used
            //Employee e1 = new Employee(1, "Sara", 22, 1234);


            ////Employee e11 = new Employee("Sara", 1, 22, 1234); //???


            //Employee e2 = new Employee(_salary: 2222, _id: 2, _age: 30, _name: "Ali");
            #endregion

            #region Create object via property initializer [RECOMMENDED]

            //Employee e11 = new Employee();
            //Employee e1 = new Employee() { Id = 1, Age = 22, Name = "Ali", Salary = 1234 };

            //Employee e3 = new Employee { Id = 1, Age = 22, Name = "Ali", Salary = 1234 };

            //Employee e2 = new() { Id = 2, Name = "Ahmed", Age = 21, Salary = 5678 };


            #endregion

            System.Console.WriteLine(""); // FullY Name qualified

         
            DataTable dt = new DataTable();



        }
    }
}
