using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD05
{
    class Base
    {
        protected int x;
        protected int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public Base()
        {
            x = y = 0;
        }
        public Base(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public virtual void Show()
        {
            Console.WriteLine("I'm base");
        }
    }
    /////////
    class Derived : Base
    {
        protected int z;
        public int Z { get { return z; } set { z = value; } }

        public Derived()
        {
            x = y = x = 0;
        }

        public Derived(int _x, int _y, int _z)//:base(_x,_y)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public override void Show()
        {
            Console.WriteLine("I'm Derived");
        }
    }
    //////////////////
    class Derived2 : Derived
    {
        protected int a;
        public int A { get { return a; } set { a = value; } }
        public Derived2()
        {
            x = y = z = a = 0;
        }

        public override void Show()
        {
            Console.WriteLine("I'm Derived 2");
        }
    }

}
