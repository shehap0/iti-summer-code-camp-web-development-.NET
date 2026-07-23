namespace Assignment
{
    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public Subject(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public Subject()
        {
        }
        
        public override string ToString()
        {
            return $"{Name} (Code: {Code})";
        }
    }
}
