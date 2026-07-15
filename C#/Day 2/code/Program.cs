namespace SummerJulG3CSD02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region IF
            /////if(condition)
            /////{
            ///////code here if condition is true
            /////}
            /////else
            /////{
            ///////code here if condition is false
            /////}

            ///if (condition)
            ///{
            /// code here if condition is true
            ///}
            ///else if (condition)
            ///{
            /// code here if condition is true
            ///}
            ///else if(condition)
            ///{
            /// code here if condition is true
            ///}
            ///else
            ///{
            /// code here if condition is false
            ///}
            ///




            //int grade;
            //Console.WriteLine("Enter Grade");
            //grade = int.Parse(Console.ReadLine());  //TryParse()
            //if (grade >= 85)
            //{
            //    Console.WriteLine("A");
            //}
            //else if (grade >= 75 && grade < 84)
            //{
            //    Console.WriteLine("B");
            //}
            //else if (grade >= 65 && grade < 74)
            //{
            //    Console.WriteLine("C");
            //}
            //else
            //{
            //    Console.WriteLine("WRONG INPUT");
            //}
            #endregion

            #region Switch
            ////switch is applicaple with check specific values
            ////switch can run with int ,string,char

            /////switch(variable)
            /////{
            /////case value1:
            /////////code here
            /////break;
            /////case value2:
            /////////code here
            /////break;
            /////case value3:
            /////////code here
            /////break;
            /////default:
            /////code here
            /////break;
            /////}



            //int month;
            //Console.WriteLine("Enter month number");
            //month = int.Parse(Console.ReadLine());  //2

            //switch (month)
            //{
            //    case 1:
            //        Console.WriteLine("Jan");
            //        break;
            //    case 2:
            //        Console.WriteLine("Feb");
            //        break;
            //    case 3:
            //        Console.WriteLine("Mar");
            //        break;
            //    case 4:
            //        Console.WriteLine("Apr");
            //        break;
            //    default:
            //        Console.WriteLine("Not Valid input");
            //        break;
            //}

            //char grade;
            //Console.WriteLine("Enter grade character");
            //grade = char.Parse(Console.ReadLine()); //A

            //switch (grade)
            //{
            //    case 'a':
            //    case 'A':
            //        Console.WriteLine("Excellent");
            //        break;
            //    case 'b':
            //    case 'B':
            //        Console.WriteLine("VG");
            //        break;
            //    case 'c':
            //    case 'C':
            //        Console.WriteLine("G");
            //        break;
            //    case 'd':
            //    case 'D':
            //        Console.WriteLine("Fair");
            //        break;
            //    default:
            //        Console.WriteLine("Invalid !!!");
            //        break;
            //}
            #endregion

            #region for loop
            //Console.WriteLine("Ahmed");
            //Console.WriteLine("Ahmed");
            //Console.WriteLine("Ahmed");
            //Console.WriteLine("Ahmed");
            //Console.WriteLine("Ahmed");

            ////copy and paste => bad programming

            ////for loop
            /////for(initial value;condition[true];increment/decrement)
            /////{
            ////////code here
            /////}
            /////


            ///   #1     #2 #5    #4
            //for (int i = 1; i < 6; i++)
            //{
            //    //#3
            //    Console.WriteLine("Ahmed");
            //}
            //memory i 1 2 3 4 5 6
            //o/p
            //Ahmed
            //Ahmed
            //Ahmed
            //Ahmed
            //Ahmed
            //for(int i = 1; i <= 10; i++) { }
            //for (int i = 10; i > 0; i--) { }

            //for (int i = 0; i < 3; i++) // 3
            //{
            //    for (int j = 0; j < 4; j++) // 4
            //    {
            //        Console.WriteLine($"{i},{j}");
            //    }
            //}
            ////memory i 0 1  2 j 0 1 2 3 4 0
            ////o/p
            /////0,0
            /////0,1
            /////0,2
            /////0,3
            /////1,0


            #endregion

            #region do- while
            ///do
            ///{
            /////code here
            ///}
            ///while(condition[true]);
            ///

            //int number;
            //int container = 0;
            //do
            //{
            //    Console.WriteLine("Enter #");
            //    number = int.Parse(Console.ReadLine());
            //    container += number;

            //    Console.WriteLine($"tmp {container}");

            //} while (container < 100);
            //Console.WriteLine($"container={container}");




            //int evenNum;
            //do
            //{
            //    Console.WriteLine("enter even #");
            //    evenNum = int.Parse(Console.ReadLine());
            //} while (evenNum % 2 == 0);

            //Console.WriteLine($"odd # is {evenNum}");
            #endregion

            #region While
            /////while(condition[true])
            /////{
            ////////code here
            /////}
            /////
            //int number;
            //int container = 0;
            //while (container < 100)
            //{
            //    Console.WriteLine("Enter #");
            //    number = int.Parse(Console.ReadLine());
            //    container += number;

            //    Console.WriteLine($"tmp {container}");

            //}
            //Console.WriteLine($"container={container}");
            #endregion

            #region Arrays Declaration [Reference type]

            /////20 students
            /////5 subjects
            /////100 variable
            /////way to store variable for each student carries 5 subjects -> 20 variable
            /////later we can create 1 variable carries 20 students with 5 subjects
            /////

            /////thats called array:
            /////Array:
            /////////fixed size collection of data with same DT
            /////////stored sequentially in memory
            /////
            //int x;   // x 4B
            //int[] arr;  //ZERO Bytes in memory [Reference type] allocate with [new]

            //////declare array carry 5 integers
            //int[] arr = new int[5];   //mamory arr |0|0|0|0|0|
            ////new +array => allocation in memory + initialization with default values 
            ////size of arr   5 * 4=20 B

            /////declare array of 10 decimal
            //decimal[] numbers = new decimal[10];
            #endregion

            #region Use array to store data
            //int[] arr = new int[5];
            /////arr|0|0|0|0|0|
            /////new +array=allocation +initalization

            /////access each integer in array
            /////use indexer
            ////////arr|0|0|0|0|0|
            /////index  0 1 2 3 4
            /////
            //arr[0] = 10;
            //arr[1] = 20;
            //arr[2] = 30;
            //arr[3] = 40;
            //arr[4] = 50;
            ////////arr|10|20|30|40|50|
            //arr[5] = 60;  //error at runtime //index out of range

            //Console.WriteLine(arr[0]);
            //Console.WriteLine(arr[1]);
            //Console.WriteLine(arr[2]);
            //Console.WriteLine(arr[3]);
            //Console.WriteLine(arr[4]);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"Enter number at index {i}");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Console.WriteLine($"number at index {i} is {arr[i]}");
            //}
            #endregion

            #region array declaration with default values
            //int[] arr1 = new int[5];  //|0|0|0|0|0|
            //int[] arr2 = new int[5] { 1, 2, 3, 4, 5 };  //|1|2|3|4|5|
            //int[] arr3 = new int[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            ////int[] arr4 = new int[]; //compile error
            //int[] arr5 = new int[] { 1, 2, 3, 4, 5 }; // arr5 |1|2|3|4|5|
            //int[] arr6 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // new int [10] {}
            #endregion

            #region 2D Array
            ///int[,] arr=new int[rowSize,colSize];
            //int[,] arr = new int[3, 4];
            //arr   3 * 4 * intSize B
            //
            //arr[0, 0] = 1;
            //arr[0, 1] = 2;
            //arr[0, 2] = 3;
            //arr[0, 3] = 4;
            //arr[1, 0] = 5;

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.WriteLine($"enter # at index {i},{j}");
            //        arr[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        Console.Write($"{arr[i, j]}\t");
            //    }
            //    Console.WriteLine();
            //}
            #endregion

            #region struct
            ///array sore data with same dt []
            ///if i wanna stor data about employee
            ///int id
            ///string name
            ///int age
            ///decimal salary
            ///
            ///can we store in array? No
            ///
            ///struct: data type with my own definitions
            ///struct: data type can carry several unrelated data types
            ///
            #endregion

           

            #region Struct with user defined DT [Employee] example   struct [value type]
            Employee e1;  //variable from employee   //24B
            Employee e2;  //variable from employee   //24B

            /////memory  e1  id|unassigned| name|ua| age|ua| salary|ua|
            /////memory  e2  id|ua| name|ua| age|ua| salary|ua|

            


            //Console.WriteLine(e1.id);


            //e1.id = 1;
            //e1.name = "Ali";
            //e1.age = 22;
            //e1.salary = 1234;
            /////memory  e1  id|1| name|Ali| age|22| salary|1234|

            //Console.WriteLine(e1); //className
            //Console.WriteLine(e1.id);
            //Console.WriteLine(e1.name);
            //Console.WriteLine(e1.age);
            //Console.WriteLine(e1.salary);

            //Console.WriteLine("======================================");

            //Console.WriteLine("Please enter id");
            //e2.id = int.Parse(Console.ReadLine());

            //Console.WriteLine("Please enter name");
            //e2.name = Console.ReadLine();

            //Console.WriteLine("Please enter age");
            //e2.age = int.Parse(Console.ReadLine());

            //Console.WriteLine("Please enter salary");
            //e2.salary = decimal.Parse(Console.ReadLine());

            //Console.WriteLine(e2.id);
            //Console.WriteLine(e2.name);
            //Console.WriteLine(e2.age);
            //Console.WriteLine(e2.salary);
            #endregion

            #region Array of 3 Employees
            Employee[] employees;   //ZEROOOOO B   //NULL

            employees = new Employee[3];
            ////new + array=allocation + initialization
            /////employees   24 *3 B
            /////
            //Console.WriteLine(employees[0].id);

            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine("Please enter id");
            //    employees[i].id = int.Parse(Console.ReadLine());

            //    Console.WriteLine("Please enter name");
            //    employees[i].name = Console.ReadLine();

            //    Console.WriteLine("Please enter age");
            //    employees[i].age = int.Parse(Console.ReadLine());

            //    Console.WriteLine("Please enter salary");
            //    employees[i].salary = decimal.Parse(Console.ReadLine());
            //}
            //for (int i = 0; i < employees.Length; i++)
            //{
            //    Console.WriteLine(employees[i].id);
            //    Console.WriteLine(employees[i].name);
            //    Console.WriteLine(employees[i].age);
            //    Console.WriteLine(employees[i].salary);
            //}
            #endregion

            #region Lab Assignments
            
            ///lab assignments
            ///READ ALL DATA FROM USER AT RUNTIME
            ///

            ///1D array
            ///1- array of 10 intergers and get min and max value   |5|4|2|-1|-33|55|66|77|88|100|
            ///2- array of 10 integers and sort it ascending without any built in function
            ///3-[Bonus] array of 10 integers and search number and get index
            ////////|4|5|6|7|8|9|2|3|66|77|88|99|100|
            ////////enter number to search
            ////////888
            ////////not found
            ////////88
            ////////found at index 10
            ////////4
            /////////found at index 0

            ///2D
            ///4- array of 3 rows,4 cols read and write   int[,]arr=new int[3,4];


            ///5-[Bonus] calculate your birth date
            ////////////////////
            ///1,3,5,7,8,10,12     31days
            ///4,6,9,11           30 days
            ///2      28,29 leap year    2000,2004,2008,2020


            ///while ->   do while

            /////plz enter your year from 1980->2023
            //2000
            /////plz enter your month
            //2
            /////plz enter your day
            //29


            /////you're 24y  3 months and 5 days

            //int currentday = DateTime.Now.day;
            //int currentmonth = DateTime.Now.Month;
            //int currentyear = DateTime.Now.Year;

            //int day, month, year;

            //6-simple calculator
            ///enter #1
            ///5
            ///enter #2
            ///6
            ///enter operator
            ///+
            ///5+6=11
            ///continue y or n?
            ///y
            //////enter #1
            ///5
            ///enter #2
            ///6
            ///enter operator
            ///*
            ///5*6=30
            ///continue y or n?
            ///n


            ///serach ====>  function

            #endregion
        }
    }
}
