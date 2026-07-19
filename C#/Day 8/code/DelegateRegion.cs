using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD08
{
    ///public delegate  RetType  DelegateName (inputParam);
    public delegate bool MyDelegate(Employee item);

    public delegate int MathDelegate(int left, int right);

    



    public delegate bool MyDelegate2(int item);
    public delegate bool MyDelegate3(string item);

    public delegate bool MyDelegate4<T>(T item);

    public delegate U MyDelegate5<in T, out U>(T item);
}
