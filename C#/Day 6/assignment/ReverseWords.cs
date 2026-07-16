namespace Assignment
{
    class ReverseWords
    {
        public static void Solve()
        {
            Console.Write("enter a sentence: ");
            string input = Console.ReadLine()!;

            string[] words = input.Split(' ');
            Array.Reverse(words);
            string result = string.Join(' ', words);

            Console.WriteLine(result);
        }
    }
}
