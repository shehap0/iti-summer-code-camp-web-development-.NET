// MinMaxTask();
// SortTask();
// TwoDArrayTask();
CalculatorTask();
    static void MinMaxTask()
    {
        Console.WriteLine("---------- 1) min & max of 10 numbers ----------");
        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Enter number #{i + 1}");
            arr[i] = int.Parse(Console.ReadLine());
        }
        int min = arr[0];
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < min)
                min = arr[i];
            if (arr[i] > max)
                max = arr[i];
        }
        Console.WriteLine($"Min value = {min}");
        Console.WriteLine($"Max value = {max}");
        Console.WriteLine();
    }




    static void SortTask()
    {
        Console.WriteLine("---------- 2) sort 10 numbers ascending ----------");
        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"Enter number #{i + 1}");
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int pass = 0; pass < arr.Length - 1; pass++)
        {
            for (int j = 0; j < arr.Length - 1 - pass; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Sorted array ascending:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]}\t");
        }
        Console.WriteLine();
        Console.WriteLine();
    }




    static void TwoDArrayTask()
    {
        Console.WriteLine("---------- 4) 2D array 3x4 ----------");
        int[,] arr = new int[3, 4];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine($"enter # at index {i},{j}");
                arr[i, j] = int.Parse(Console.ReadLine());
            }
        }
        Console.WriteLine("The array is:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{arr[i, j]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }




    static void CalculatorTask()
    {
        Console.WriteLine("---------- 6) simple calculator ----------");
        char again;
        do
        {
            Console.WriteLine("enter #1");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("enter #2");
            double num2 = double.Parse(Console.ReadLine());
            Console.WriteLine("enter operator");
            char op = char.Parse(Console.ReadLine());
            switch (op)
            {
                case '+':
                    Console.WriteLine($"{num1}+{num2}={num1 + num2}");
                    break;
                case '-':
                    Console.WriteLine($"{num1}-{num2}={num1 - num2}");
                    break;
                case '*':
                    Console.WriteLine($"{num1}*{num2}={num1 * num2}");
                    break;
                case '/':
                    if (num2 == 0)
                        Console.WriteLine("can't divide by zero");
                    else
                        Console.WriteLine($"{num1}/{num2}={num1 / num2}");
                    break;
                default:
                    Console.WriteLine("invalid operator");
                    break;
            }
            Console.WriteLine("continue y or n?");
            again = char.Parse(Console.ReadLine());
        } while(again=='y'|| again == 'Y');
    }