using System.Threading.Channels;

namespace SummerJulG3CSD08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///delegate
            #region Nullable Value Type
            //int x = null;

            ////DB
            /////employee
            /////int   vcnn   int n
            /////id   name   age
            /////1    Ali    null
            /////2    Sara   null
            /////
            /////ORM   C#
            /////class Employee
            /////{
            /////int id
            /////string name
            /////int age
            /////}
            /////
            /////Employee e1=new Employee{Id=1,Name="Ali",Age=null};
            /////


            //Nullable<int> y = null;
            //int? z = null;

            ////Console.WriteLine(y.Value);
            //if (y.HasValue)
            //{
            //    Console.WriteLine(y.Value);
            //}
            //else
            //{
            //    Console.WriteLine("EMPTY");
            //}

            #endregion

            #region Repository
            List<Employee> employees = Repository.GetEmployees();

            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Filtration V1
            //var filteredEmps = Filtration.FilterByDeptId(employees);
            //filteredEmps = Filtration.FilterBySalary(employees);
            //filteredEmps = Filtration.FilterByName(employees);
            //foreach (var item in filteredEmps)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Filtration V2
            //var filteredEmps = Filtration.FilterByAny(employees);
            //foreach (var item in filteredEmps)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Think
            //var filteredEmps =
            //Filtration.FilterByAny(employees, How To filter Technique1);
            //filteredEmps = Filtration.FilterByAny(employees, How To filter Technique2);
            //think of variable carry function

            //THATS CALLED DELEGATE
            #endregion

            #region Delegate
            ///delgate: pointer to function
            ///delegate : datatype[variable] points function
            ///delegate is reference type
            ///delegate is 5th Dt written inside namespace

            ///when declare delegate DT
            ///YOU MUST create that delegate with same signature
            ///of function that points to
            ///

            #endregion

            #region Delegate Example V1
            //MyDelegate del1 = new MyDelegate(Utility.BySalary);
            //MyDelegate de = new MyDelegate(Utility.ByDeptId);

            /////When delegate points function
            /////it acts like a function
            /////
            //var e1 = new Employee
            //{ Id = 1, Name = "Ali", Age = 24, Salary = 1234, DeptId = 10 };
            //Console.WriteLine(Utility.BySalary(e1));
            //Console.WriteLine(del1(e1));

            ////MyDelegate del2 = new MyDelegate(Utility.IsEven);  //WRONG

            //MathDelegate del3 = new MathDelegate(Utility.Add);
            //int x = 3, y = 5;
            //Console.WriteLine(Utility.Add(x, y));
            //Console.WriteLine(del3(x, y));
            #endregion

            #region Delegate Example V2
            //MyDelegate del1 = new MyDelegate(Utility.BySalary);
            //MyDelegate del2 = Utility.BySalary;

            //MyDelegate del3 =  public static bool BySalary(Employee item)
            //{
            //    return item.Salary > 7000;
            //}

            /////Anonymous function :function without name
            ///

            //MyDelegate del3 = delegate (Employee item)
            //{
            //    return item.Salary > 7000;
            //};

            ////

            #endregion

            #region Delegate Example with anonymous function
            //MyDelegate del1 = delegate (Employee abc)
            //{
            //    return abc.DeptId == 10;
            //};
            //var e1 = new Employee
            //{ Id = 1, Name = "Ali", Age = 24, Salary = 1234, DeptId = 10 };
            //////call fn
            //Console.WriteLine(del1(e1));

            //MathDelegate del2 = delegate (int a, int m)
            //{
            //    return a + m;
            //};

            //////call fn
            //Console.WriteLine(del2(11, 22));

            /////Lambda Expression  =>  goes to
            /////anonymous function
            /////(input params)=>{Return body;};
            /////(int x,int y)=>{return x>y;};
            /////(int x,int y)=>{return x+y;};

            //MyDelegate del3 = (Employee abc) =>
            //{
            //    return abc.DeptId == 10;
            //};

            //MyDelegate del4 = (param) => { return param.Salary > 1000; };
            //MyDelegate del5 = ayHaga => ayHaga.Salary > 5000;

            //MathDelegate del6 = (x, y) => x + y;
            #endregion

            #region Generic Delegate
            //MyDelegate5<Employee, bool> del1 = www => www.DeptId == 10;
            #endregion

            #region Filtration V3
            //MyDelegate del1 = e => e.DeptId == 20;
            //del1 = e => e.Name.ToLower().Contains("s");


            //var filteredEmps = Filtration.FilterByDelegate(employees, del1);


            //filteredEmps = Filtration.FilterByDelegate(employees, e => e.Age > 27);

            //foreach (Employee item in filteredEmps)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Built-In Delegates
            #region Predicate takes 1 generic param and returns bool
            //Predicate<int> p1 = x => x % 2 == 0;
            //int num = 22;
            //Console.WriteLine(p1(num));

            //Predicate<Employee> p2 = q => q.Age > 22;

            //Employee e1 = new();
            //Console.WriteLine(p2(e1));

            #endregion

            #region Action takes from 0 up to 16 generic params and returns void
            //Action a1 = () => Console.WriteLine("Hello .NET");
            //a1();

            //Action<int, int, int> a2 = (x, y, z) => Console.WriteLine($"{x + y + z}");
            //a2(2, 3, 4);
            #endregion

            #region Func takes from 0 up to 16 generic params and returns Generic DT
            //Func<string> f1 = () => "Hello .NET";
            //Console.WriteLine(f1());

            //Func<int, int, int> f2 = (e, r) => e + r;
            //Console.WriteLine(f2(11, 22));

            ////Func<int,int,void> f3=   Action<int,int> a1

            //Func<int, int, bool> f3 = (w, e) => w > e;
            //Console.WriteLine(f3(22,10));

            //Func<Employee, bool> f4 = eee => eee.DeptId == 30;
            #endregion
            #endregion

            #region List of Numbers
            //List<int> nums = new List<int>();
            //List<int> nums = Enumerable.Range(1, 100).ToList();
            //for (int i = 1; i <= 100; i++)
            //{
            //    nums.Add(i);
            //}

            //List<int> evenNums = new List<int>();
            //foreach (int item in nums)
            //{
            //    if (item % 2 == 0)
            //    {
            //        evenNums.Add(item);
            //    }
            //}

            //var evenNums = nums.FindAll(item => item % 2 == 0);
            //var evenNums =
            //    from item in nums
            //    where item % 2 == 0
            //    select item;

            //var evenNums = nums.Where(www => www % 2 == 0);

            //////nums.RemoveAll(www => www % 2 == 0);
            //foreach (var item in evenNums)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Lab Assignment 
            ///list of emloyees
            ///class filtarion
            ///try delegate with filterByDelegate (collection,delegate)
            ///
            ///try built in delegates with some examples
            #endregion
        }
    }
}
