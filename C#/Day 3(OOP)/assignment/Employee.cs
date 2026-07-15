using System;

class Employee
{
    private int id;
    private string name;
    private int age;
    private int salary;
    private static int counter = 0;

    public int Id { get { return id; } set { id = value; } }
    public string Name { get { return name; } set { name = value; } }
    public int Age { get { return age; } set { age = value; } }
    public int Salary { get { return salary; } set { salary = value; } }
    public static int Counter { get { return counter; } }

    public Employee()
    {
        counter++;
    }

    public Employee(int id, string name, int age, int salary)
    {
        this.id = id;
        this.name = name;
        this.age = age;
        this.salary = salary;
        counter++;
    }

    public string print()
    {
        string s = "id: " + id + " name: " + name + " age: " + age + " salary: " + salary;
        return s;
    }
}