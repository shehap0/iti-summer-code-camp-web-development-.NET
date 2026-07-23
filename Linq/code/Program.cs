
using System.Linq;
using System.Security.Cryptography;

namespace LINQDAY1

{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Implicit typed local variable (var keyword not DT)
            //int x = 2;
            //var D = 123.345;
            //Console.WriteLine(D.GetType());

            // D = "Hello"; // Not vaild, C# is a Strongly Typed Lan
            ////Cannot implicitly convert type 'string' to 'double'


            #endregion


            #region Extension Method

            List<int> list = new List<int>() { 1, 3, 4, 6, 8 };

            list.First();


            #endregion


            #region  Anonymous Type

            //Employee E = new Employee() { Id = 1, Name = " Ahmed", Salary = 3000.0 };

            //var Emp = new { Id = 1, Name = " Ahmed", Salary = 3000.0 };

            //Console.WriteLine(Emp); // This will print the object  

            //Console.WriteLine(Emp.GetType());
            //Console.WriteLine(Emp.Name);
            //Emp.Name = "Heba"; // WRONG // Read Only // Immutable Object

            ////// Same Data Type as long as same property name , same property data type and same sequence

            //var Emp2 = new { Id = 2, Name = " Heba", Salary = 3000.0 };

            //Console.WriteLine(Emp2.GetType());

            ////// New Anonymous  Data type
            //var Emp3 = new { Id = 1, Name = " Ahmed" };
            //Console.WriteLine(Emp3.GetType());


            #endregion


            #region Linq ??
            // Linq Queries Against any Sequence 
            // Sequence : class or struct Implement IEnumerable <T> Interface
            // Local Sequence : L2O, L2ADO, L2XML
            // Remote Sequence : L2SQL , L2EF
            // Sequence Contains Elements


            List<int> lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
           
            List<string> lst2 = new List<string>() { "ahmed", "ali", "heba", "sally" };

           
            #region How to Write Linq Query
            /// Fluent Syntax  => Function Chaining  

            //Static Function member in Enumerable Class

            var res = Enumerable.Where(lst, i => i % 2 == 0);

            var  x =  Enumerable.Where(lst , i => i % 2 != 0);


            // Extension Method  (most used)

            var res1 = lst.Where(i => i % 2 == 0).OrderByDescending(i => i);
           
            //Console.WriteLine(res1.GetType());

            /// Query Expression  or Query Syntax (SQL like)
            /// 
      
            // 3 select name
            // 1 from stu
            // 2 where id = 2


            var res3 = from i in lst
                       where i % 2 == 0
                       select i;

            // Sql Like Style , valid for  only subset of ( 40+  LINQ Operator)
            // Some cases it is easier to write qurey using  Query Expression  vs Fluent Syntax ( Join , Group)
            // Start with From , introduce Range Variable (i) : represent each and every element in Input Sequence
            // End with Select or Group By



            #endregion


            #region Linq Execution
            /// Most of LINQ Operators ==> Deffered Execution

            //var Result = lst.Where(i => i % 2 == 0);

            ////var xxx = 22; // in M     x | 22   4 B

            //Console.WriteLine(Result.GetType());

            //foreach (var item in Result)
            //{
            //    Console.Write($" {item}, ");
            //}
            //Console.WriteLine();

            //lst.Remove(2);
            //lst.AddRange(new int[] { 12, 14, 15, 16 });

            //foreach (var item in Result)
            //{
            //    Console.Write($" {item}, ");
            //}


            /// Imidiate Execution 
            /// Casting , Element Operators are Imidiate Execution Operators
            /// 

            //var Result1 = lst.Where(i => i % 2 == 0).ToList();


            //foreach (var item in Result1)
            //{
            //    Console.Write($" {item}, ");
            //}
            //Console.WriteLine();

            //lst.Remove(2);
            //lst.AddRange(new int[] { 12, 14, 15, 16 });

            //foreach (var item in Result1)
            //{
            //    Console.Write($" {item}, ");
            //}

            #endregion

            #endregion


            #region Data

            List<Student> students = new List<Student>()
            {
                    new Student()
                    {
                        ID=1,
                        FirstName="Sara",
                        LastName="Mohammed",
                        Subjects=new Subject[]{
                            new Subject(){ Code=22,Name="EF"},
                            new Subject(){ Code=33,Name="UML"}}
                    },

                    new Student()
                    {
                        ID=2,
                        FirstName="Mona",
                        LastName="Gala",
                        Subjects=new Subject []
                        {
                            new Subject(){ Code=22,Name="EF"},
                            new Subject (){ Code=34,Name="XML"},
                            new Subject (){ Code=25, Name="JS"}
                        }
                    },

                    new Student()
                    {
                        ID=3,
                        FirstName="Yara",
                        LastName="Yousf",
                        Subjects=new Subject []
                        {
                            new Subject (){ Code=22,Name="EF"},
                            new Subject (){ Code=25,Name="JS"}
                        }
                    },

                    new Student()
                    {
                        ID=4,
                        FirstName="Ali",
                        LastName="Ali",
                        Subjects=new Subject []
                        {
                            new Subject ()
                            {
                                Code=33,Name="UML"}
                        }
                    },

                    new Student()
                    {
                        ID=5,
                        FirstName="Ali",
                        LastName="Ahmed",
                        Subjects=new Subject[]{
                            new Subject(){ Code=22,Name="EF"},
                            new Subject(){ Code=33,Name="UML"}}
                    },
            };


            List<Subject> subjects = new List<Subject>() { };



            //// Displaying student information
            //foreach (var student in students)
            //{
            //    Console.WriteLine($"Student ID: {student.ID}");
            //    Console.WriteLine($"Name: {student.FirstName} {student.LastName}");
            //    Console.WriteLine("Subjects:");
            //    foreach (var subject in student.Subjects)
            //    {
            //        Console.WriteLine($"- Code: {subject.Code}, Name: {subject.Name}");
            //    }
            //    Console.WriteLine();
            //}

            #endregion


            #region Where -> Filteration

            //var res101 = students.Where(s => s.FirstName == "Ali");

            // sql like ??



            //var resul = from student in students
            //            where student.FirstName == "Ali"
            //            select student;



            //foreach (var student in res101)
            //{
            //    Console.WriteLine(student);
            //}

            ////// Indexed Where Valid only in Fluent Syntax
            ////// Can't be Written using Query Expression

            //var res2 = students.Where((s, i) => (s.FirstName == "Ali") && (i == 0));



            #endregion


            #region Select --> Transformation Operator

            // Trasform every Element in Input sequence to a New Element in Output sequence of New DataType (or Same DT)

            var res301 = students.Select(S => S.FirstName);



            //foreach (var s in res301)
            //{
            //    Console.WriteLine(s);
            //}

            // sql like ??
            var re = from student in students
                     select student.FirstName; 

            // ex: select the name of student when id > 2
            var res222222 = from i in students
                            where i.ID > 2
                            select i.LastName;

            var ww =  students.Where(s => s.ID > 2).Select(s=> s.LastName);

            // ex: select the name of students as Full Name

            var wwww =  students.Select(s => new {FullName = s.FirstName + ' ' + s.LastName});
          
           

            // Indexed Select Valid only in Fluent Syntax
            // Can't be Written using Query Expression

            var res4 = students.Select((s, i) => new { index = i, Name = s.FirstName + " " + s.LastName });

            


            #endregion


            #region Ordering Elements 
           
            // select fn
            // from stuednt
            // order by fn ,id 
          

            var res5 = students.OrderBy(s => s.LastName);

            res5 = from s in students
                   orderby s.LastName 
                   select s;

            res5 = students.OrderByDescending(s => s.LastName);


            res5 = from s in students
                   orderby s.LastName descending
                   select s;


            res5 = students.OrderBy(s => s.FirstName)
                            .ThenBy(s => s.ID);

            res5 = from s in students
                   orderby s.FirstName ,s.ID
                   select s;



            res5 = students.OrderBy(s => s.LastName)
                           .ThenByDescending(s => s.ID);

            res5 = from s in students
                   orderby s.LastName  , s.ID descending
                   select s;


            res5 = students.OrderByDescending(s => s.LastName)
                          .ThenByDescending(s => s.ID);

            res5 = from s in students
                   orderby s.LastName descending, s.ID descending
                   select s;
            #endregion


            #region  Element Operators ( Single Output) - Imidiate Execution



            // Exists in Fluent Syntax Only

            var result = students.First();



            //result = students.First(S => S.FirstName == "Ali");


            // Console.WriteLine(result.ID);

            // result = students.Last();

            // result = students.Last(S => S.FirstName == "Ali");

            ////Console.WriteLine(result.ID);

            //List<Student> students2 = new List<Student>();

            //result = students2.First();
            //result = students2.Last();


            // // If input sequence have no elements ===> Throw Exception

            //result = students2.FirstOrDefault();
            //result = students2.LastOrDefault();




            result = students.ElementAt(0); // index
            //result = students.ElementAt(100); // throw exception

            //result = students.ElementAtOrDefault(100);



            //Console.WriteLine(result?.FirstName ?? "NotFound!!");



            //result = students.Single();
            // // Return Single element in seq (Only One input seq)
            // // Throw exception if Empty or More than One element exists

            // result = students.Single(s=> s.ID == 1); // Check uniqe value 

            // result = students.SingleOrDefault(); //Throw exception if More than One element exists
            // // Noooo if Empty element exists



            // /////// Hybird Syntax (Query Expression) . Fluent syntax
            // ///

            // var WW = (from s in students
            //           where s.FirstName == "Ali"
            //           select s).First();//id = 4




            #endregion


            #region Aggregate (Single Output) - Imidiate Execution
            // Sum , MAX, MIN, COUNT , Average   ---> RETURN VALUE

            var res6 = students.Count(); // 5
            var res8 = students.Count(S => S.FirstName == "Ali");// 2

            var res7 = students.Max(s => s.ID);  // return max id not student  5

            var res333 = students.Min(s => s.ID);// 1
            var res88 = students.Sum(s => s.ID);// 15 
            var res77 = students.Average(s => s.ID);// 3

           // Console.WriteLine(res77);



            #endregion




            #region  Set Operators

            //var L1 = Enumerable.Range(0, 100);  // 0 : 99
            //var L2 = Enumerable.Range(50, 100); // 50 : 149

            //var RR = L1.Union(L2); // Renmove Duplicate

            //RR = L1.Concat(L2); // Union All in SQL

            //RR = RR.Distinct();


            //RR = L1.Except(L2);

            //RR = L1.Intersect(L2);

            //foreach (var xx in RR)
            //{
            //    Console.Write($"{xx}, ");
            //}
            //Console.WriteLine("");

            #endregion


            #region Grouping 

            // in SQL ??

            // select  deptid                          10
            // from employee                           20 
            // group by deptid



            //var Res = from s in students
            //          where s.ID > 0
            //          group s by s.FirstName;



            //foreach (var stuGroup in Res)
            //{
            //    Console.WriteLine($" Group Key {stuGroup.Key}");
            //    foreach (var s in stuGroup)
            //    {
            //        Console.WriteLine($".. {s.ID}");
            //    }
            //}

            //Res = students.GroupBy(S => S.FirstName);

            #endregion



            #region Join

            // in SQL ??

            // 4 select *
            // 1 from emp 2 join dept
            // 3 on dept.id = emp.dept.id


            var RES = from s in students
                      join sub in subjects
                      on s.ID equals sub.Code
                      select s.FirstName;

            #endregion


            

        }
    }
}
