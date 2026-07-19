
using System.Collections.Generic;
namespace SummerJulG3CSD07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Interface
            ///in c# multi level inheritance is supported only
            ///class X:Y,Z{} XXX not Supported
            ///issue: i need to inherit data from multiple resources
            ///

            ///interface:
            /////Protocol between classes
            /////reference type
            /////4th thing is written inside namespace
            /////we cannot create object from it
            /////it contains meta data
            /////inside interface 
            ///1-method header[abstract method]
            ///2-auto property
            ///without access modifiers
            ///because it is inherited by public always

            ///class/struct can inherit/implement multiple[more than one] interfaces
            #endregion

            #region Interface Example

            //MyInterface I1 = new IMyInterface();


            //IMyInterface myInterface;


            //Department d1 = new Department();

            //IMyInterface myInterface2 = new Department();


            #endregion


            #region Employee object
            //Employee e1 = new Employee
            //{
            //    Id = 2,
            //    Name = "Ali",
            //    Age = 22,
            //    Salary = 4567,
            //    HDate = new HireDate { Day = 4, Month = 4, Year = 2004 }
            //};

            //Console.WriteLine(e1);
            #endregion



            #region var is implicit type , keyword not a DT  [Linq]
            ///c# is strongly typed

            //int x ;
            //x = 3;
            //var y = 22;

            //var str = "Ali";

            //var map=new Dictionary<string,int>();

            //var z ;  //Compile Error
            #endregion


            #region sort array of built-in DT
            //int[] arr1 = { 133, 6, 4, 1, 5, 4, 3, -9, -99, 777 };
            //string[] names = { "ziad", "Osama", "Sara", "Ali", "Aalaa", "Omar" };

            //for (int i = 0; i < arr1.Length; i++)
            //{
            //    Console.Write($" {arr1[i]}, ");
            //}
            //Console.WriteLine();

            //Array.Sort(arr1);
            //Array.Sort(names);

            //foreach (var item in names)
            //{
            //    Console.Write($"{item}, ");
            //}

            #endregion

            #region sort array of user defined DT
            //Employee[] employees =
            //{
            //    new Employee (),
            //    new Employee {Id=2,Name="Osama",Age=27,Salary=4234,HDate = new HireDate{Day=5,Month=5,Year=2005 } },
            //    new Employee {Id=3,Name="Ziad",Age=23,Salary=3234,HDate = new HireDate{Day=1,Month=1,Year=2001 } },
            //    new Employee {Id=4,Name="Mariem",Age=21,Salary=2234,HDate = new HireDate{Day=2,Month=2,Year=2002 } },
            //    new Employee {Id=5,Name="Ali",Age=20,Salary=1234,HDate = new HireDate{Day=1,Month=1,Year=2000 } }
            //};

            //Array.Sort(employees);



            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Clone
            // int[] arr1 = { 133, 6, 4, 1, 5, 4, 3, -9, -99, 777 };

            // int[] arr2 = arr1;

            //// int[] arr3 = arr2.Clone();  // error => clone return object
            // int[] arr4 = arr1.Clone() as int[];
            // //int[] arr5 = (int[])arr1.Clone();


            // Console.WriteLine(arr1.GetHashCode());
            // Console.WriteLine(arr4.GetHashCode());

            //Employee e1 = new Employee
            //{
            //    Id = 2,
            //    Name = "Ali",
            //    Age = 22,
            //    Salary = 4567,
            //    HDate = new HireDate { Day = 4, Month = 4, Year = 2004 }
            //};
            ////Employee e3 = e1;
            //Employee e2 = e1.Clone() as Employee;

            //Console.WriteLine(e1.GetHashCode());
            //Console.WriteLine(e2.GetHashCode());

            #endregion

            #region Generic
            ////methodolgy of write code once
            ////and can be applicaple with any DT

            /////generic class,interface,methos
            /////
            //int x = 3, y = 5;
            //string str1 = "Ali", str2 = "Osama";
            //Utility.SwapI(x, y);
            //Utility.Swap(x, y);
            //Utility.Swap<int>(x, y);
            //Utility.Swap<Employee>(,)

            #endregion

            #region generic Collections
            ///Array issue???  Fixed-Size

            #region List

            // List<int> l = new List<int>();

            // List<int> Nums = new List<int>(5); //
            // Nums.Add(1);
            // Nums.Add(2);
            // Nums.Add(3);
            // Nums.Add(4);
            // Nums.Add(5);
            // //Console.WriteLine(Nums.Capacity);//
            //Nums.Add(6);
            // Nums.Add(7);
            // Nums.Add(8);
            // Nums.Add(9);
            // Nums.Add(10);
            // Nums.Add(11);
            // Console.WriteLine(Nums.Capacity);//20


            //List<int> arr = new List<int>(1000) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //arr.Add(11);
            //arr.Remove(11);
            //Console.WriteLine(arr.Count);

            //arr[0] = 1000;///update
            //Console.WriteLine(arr[0]); //get select
            //arr[10] = 4000; ///insert ???  ///RUNTIME ERROR
            ///////indexer used in get[select] and update

            //Console.WriteLine(arr.Capacity);

            //arr.TrimExcess();
            //Console.WriteLine(arr.Capacity);

            //arr.AddRange(new int[] { 55, 66, 77, 88, 99, 100 });
            //Console.WriteLine("====================");
            //foreach (int item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //arr.Clear();
            #endregion


            #region Dictionary

            //Dictionary<int, string> map = new Dictionary<int, string>();

            //map.Add(1, "Ali");
            //map.Add(2, "Sara");
            //map.Add(3, "Osama");
            //map.Add(4, "Ali");
            //map.Add(5, "Aalaa");


            //map.Add(5, "Ziad");// error   key already


            //map[6] = "Ahmed"; //insert T
            //map[5] = "Ziad";  //update T
            //Console.WriteLine(map[3]); //select T


            //foreach (var item in map)
            //{
            //    Console.WriteLine($"{item.Key}:{item.Value}");
            //}

            #endregion

            #endregion

            #region SingleObject   ///design patterns [SingleTon]
            //make class create single object from it
            ////V01
            //FTP o1 = new FTP();
            //FTP o2 = new FTP();
            //FTP o3 = new FTP(3, "hgfd");
            //Console.WriteLine(o1.GetHashCode());
            //Console.WriteLine(o2.GetHashCode());
            //Console.WriteLine(o3.GetHashCode());

            //FTP o1 = FTP.CreateObject();
            //FTP o2 = FTP.CreateObject();
            //FTP o3 = FTP.CreateObject();
            //FTP o4 = FTP.CreateObject();

            //Console.WriteLine(o1.GetHashCode());
            //Console.WriteLine(o2.GetHashCode());
            //Console.WriteLine(o3.GetHashCode());
            //Console.WriteLine(o4.GetHashCode());

            #endregion


            #region REFERECE TYPE Object Check Equality
            //Point p1 = new Point { X = 3, Y = 4 };
            //Point p2 = new Point { X = 5, Y = 6 };
            //Point p3 = new Point { X = 3, Y = 4 };
            //Point p4 = p1;
            //Point p5;

            //if (p1 == p4)   ///==  Identity
            //if (p1.Equals(p3)) ///Equals Identity
            //if (object.Equals(p1, p4)) ///Static Equals Identity
            //if (object.ReferenceEquals(p1, p4)) ///Static Equals Identity
            //{
            //    Console.WriteLine("EQ");
            //}
            //else
            //{
            //    Console.WriteLine("NEQ");
            //}


            //if (p1.Equals(p5))
            //{
            //    Console.WriteLine("EQ");
            //}
            //else
            //{
            //    Console.WriteLine("NEQ");
            //}

            #endregion

            #region Lab Assignment
            ///class hiredate  day month year
            ///class department deptid deptname
            ///class Employee id name age salary hiredate department
            ///
            ///in main
            ///one employee read and write
            ///array of 10 employees 
            ///sort that array based on hiredate month
            ///

            ////Try
            //////try singleTon
            //////try check equals  point
            #endregion
        }
    }
}
