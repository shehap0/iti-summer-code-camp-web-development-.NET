namespace Assignment
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] Subjects { get; set; }

        public Student(int id, string firstName, string lastName, Subject[] subjects)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Subjects = subjects;
        }

        public Student()
        {
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public override string ToString()
        {
            string subjectsInfo = Subjects != null ? string.Join(", ", Subjects.Select(s => $"{s.Name}: {s.Code}")) : "No subjects";
            return $"ID: {ID}, Name: {GetFullName()}, Subjects: [{subjectsInfo}]";
        }
    }
}
