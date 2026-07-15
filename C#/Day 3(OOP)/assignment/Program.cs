using System;

class Program
{
    static void Main(string[] args)
    {
        Employee e1 = new Employee();
        Console.Write("enter id: ");
        e1.Id = int.Parse(Console.ReadLine());
        Console.Write("enter name: ");
        e1.Name = Console.ReadLine();
        Console.Write("enter age: ");
        e1.Age = int.Parse(Console.ReadLine());
        Console.Write("enter salary: ");
        e1.Salary = int.Parse(Console.ReadLine());
        Console.WriteLine(e1.print());

        Employee[] employees = new Employee[3];

        for (int i = 0; i < employees.Length; i++)
        {
            employees[i] = new Employee();
            Console.Write("enter id: ");
            employees[i].Id = int.Parse(Console.ReadLine());
            Console.Write("enter name: ");
            employees[i].Name = Console.ReadLine();
            Console.Write("enter age: ");
            employees[i].Age = int.Parse(Console.ReadLine());
            Console.Write("enter salary: ");
            employees[i].Salary = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < employees.Length; i++)
        {
            Console.WriteLine(employees[i].print());
        }

        Console.WriteLine("total employees: " + Employee.Counter);
    }
}