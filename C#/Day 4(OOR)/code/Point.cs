using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD04
{
    class Point
    {
        int x;
        int y;

        public int X {  get { return x; } set { x = value;}}
        public int Y { get { return y; } set { y = value; }}

        //l1  start call point() to allocate object
        //l1  end call point() to allocate object
        public Point()
        {
            x = y = 0;
            Console.WriteLine("point def ctor");
        }

        public Point(int _x,int _y)
        {
            x = _x;
            y = _y;
            Console.WriteLine("point 2p ctor");
        }
    }
}
