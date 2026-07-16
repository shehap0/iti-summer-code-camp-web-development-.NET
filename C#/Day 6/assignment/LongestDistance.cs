namespace Assignment
{
    class LongestDistance
    {
        public static void Solve()
        {
            Console.Write("enter size of array N: ");
            int n = int.Parse(Console.ReadLine()!);

            int[] arr = new int[n];
            Console.WriteLine("enter array values:");
            for (int i = 0; i < n; i++) arr[i] = int.Parse(Console.ReadLine()!);
            
            int maxDistance = 0;
            for (int i = 0; i<n; i++)
            {
                for (int j = n-1; j > i; j--)
                {
                    if (arr[i] == arr[j])
                    {
                        int distance = j-i-1;
                        if (distance>maxDistance) maxDistance = distance;
                        break;
                    }
                }
            }

            Console.WriteLine($"longest distance between two equal cells is: {maxDistance}");
        }
    }
}
