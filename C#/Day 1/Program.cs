namespace C_Day1
{
    internal class Program
    {
        static void Main(string[] args)
      
        {


            #region write and read to console

            //Console.WriteLine("Hello");




            //int age = 5;


            //Console.WriteLine(age);

            //Console.WriteLine($"your age is  {age}");

            //Console.WriteLine("plz enter your name : ");

            //Console.ReadLine();

            //string name = Console.ReadLine();

            //Console.WriteLine($"your name is  {name}");

            //Console.WriteLine("plz enter your age : ");

            ////age = Console.ReadLine(); ?? string

            //age = int.Parse(Console.ReadLine());

            //Console.WriteLine($"your age is  {age}");

            #endregion

            #region  Operators

            /// Binary arithmatic Operators ( +, -, *, /,% )

            //int x = 3, y = 4, z;

            //z = x / y;


            //Console.WriteLine($"X = {x}"); // 3
            //Console.WriteLine($"Y = {y}"); // 4
            //Console.WriteLine($"Z = {z}"); // 0

            /// Unary Operators ( ++, --)

            //int X = 3, Y = 5;



            //int a = ++X; ///  X=4  , A = 4 
            ////Console.WriteLine($"a = {a}");
            //a = X++;// A= 4, X= 5
            //Console.WriteLine($"a = {a}"); //

            //Console.WriteLine($"X = {X}"); // 4
            //Console.WriteLine($"Y = {Y}"); //5


            ///Compound Operator +=, -=, *=, /=, %=

            int x = 3, y = 2, z = 5;

            /*x += y*/; // X = X + Y

            /// Comparison Operators >, <, >=, <=, ==,!=  return type [Boolean]

            //Console.WriteLine(y < x);

            ///Logical Operators &&, ||

            Console.WriteLine(z > x && x > y); // false
                                         
            Console.WriteLine(z < x || x > y++); // true
            Console.WriteLine(y);



            #endregion


        }
    }
}
