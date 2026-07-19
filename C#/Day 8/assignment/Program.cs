namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = Repository.GetStudents();
            StudentDelegate del1 = s=>s.DepartmentName== "game dev";
            StudentDelegate del2 = s=>s.Age > 25;
            StudentDelegate del3 = s=>s.Gender == "Female";

            Student[] filtered1 =Filtration.FilterByAny(students, del1).ToArray();
            Console.WriteLine("students in game dev department:");
            foreach (Student item in filtered1)
            {
                Console.WriteLine(item);
            }

            Student[]filtered2 = Filtration.FilterByAny(students, del2).ToArray();
            Console.WriteLine("\nstudents older than 25:");
            foreach (Student item in filtered2)
            {
                Console.WriteLine(item);
            }

            Student[] filtered3 = Filtration.FilterByAny(students, del3).ToArray();
            Console.WriteLine("\nfemale students:");
            foreach (Student item in filtered3)
            {
                Console.WriteLine(item);
            }




            Predicate<int> p1 = x => x%2 == 0;
            Console.WriteLine($"\nis 10 even? {p1(10)}");

            Action<string> a1 = msg => Console.WriteLine($"Action says: {msg}");
            a1("hello game dev");

            Func<int, int, int> f1 = (x, y) => x + y;
            Console.WriteLine($"func sum: {f1(11, 22)}");

            Func<Student, bool> f2 = s => s.Age > 25;
            Console.WriteLine($"is Ali older than 25? {f2(students[0])}");
        }
    }
}
