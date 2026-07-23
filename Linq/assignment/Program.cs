using System.Linq;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            Console.WriteLine("Query1: Display numbers without any repeated Data and sorted");
            var q1 = numbers.Distinct().OrderBy(n => n);
            Console.WriteLine(string.Join(", ", q1));


            Console.WriteLine("\nQuery2: using Query1 result and show each number and its multiplication");
            var q2 = q1.Select(n => $"{n} * {n} = {n * n}");
            foreach (var item in q2)
                Console.WriteLine(item);





            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            Console.WriteLine("\nQuery1 (Query Expression): Select names with length equal 3");
            var t2_q1 = from n in names
                           where n.Length == 3
                           select n;
            Console.WriteLine(string.Join(", ", t2_q1));

            Console.WriteLine("\nQuery1 (Method Expression): Select names with length equal 3");
            var t2_q1_2 = names.Where(n => n.Length == 3);
            Console.WriteLine(string.Join(", ", t2_q1_2));


            Console.WriteLine("\nQuery2 (Query Expression): Select names that contain 'a' then sort them by length");
            var t2_q2_Q = from n in names
                           where n.ToLower().Contains("a")
                           orderby n.Length
                           select n;
            Console.WriteLine(string.Join(", ", t2_q2_Q));

            Console.WriteLine("\nQuery2 (Method Expression): Select names that contain 'a' then sort them by length");
            var t2_q2_M = names.Where(n => n.ToLower().Contains("a")).OrderBy(n => n.Length);
            Console.WriteLine(string.Join(", ", t2_q2_M));

            Console.WriteLine("\nQuery3: Display the first 2 names");
            var q3 = names.Take(2);
            Console.WriteLine(string.Join(", ", q3));






            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    ID=1,
                    FirstName="Ali",
                    LastName="Mohammed",
                    Subjects=new Subject[]{ new Subject(){ Code=22, Name="EF"}, new Subject(){ Code=33, Name="UML"}}
                },
                new Student()
                {
                    ID=2,
                    FirstName="Mona",
                    LastName="Gala",
                    Subjects=new Subject[]{ new Subject(){ Code=22, Name="EF"}, new Subject(){ Code=34, Name="XML"}}
                },
                new Student()
                {
                    ID=3,
                    FirstName="Yara",
                    LastName="Yousf",
                    Subjects=new Subject[]{ new Subject(){ Code=25, Name="JS"}, new Subject(){ Code=99, Name="C#"}}
                },
                new Student()
                {
                    ID=1,
                    FirstName="Ali",
                    LastName="Ali",
                    Subjects=new Subject[]{ new Subject(){ Code=33, Name="UML"}}
                }
            };

            Console.WriteLine("\nQuery1: Display Full name and number of subjects for each student");
            var res1 = students.Select(s => new { FullName = s.GetFullName(), NoOfSubject = s.Subjects.Length });
            foreach (var item in res1)
                Console.WriteLine(item);

            Console.WriteLine("\nQuery2: Order by FirstName Descending then by LastName Ascending");
            Console.WriteLine("Display only first names and last names");
            var res2 = students.OrderByDescending(s => s.FirstName)
                               .ThenBy(s => s.LastName)
                               .Select(s => s.GetFullName());
            foreach (var item in res2)
                Console.WriteLine(item);

            Console.WriteLine("\nQuery3: Display each student and student's subject (SelectMany)");
            var res3 = students.SelectMany(s => s.Subjects, (s, sub) => new { FullName = s.GetFullName(), Subject = sub.Name });
            foreach (var item in res3)
                Console.WriteLine($"<StudentName = {item.FullName}, SubjectName = {item.Subject} >");

        }
    }
}
