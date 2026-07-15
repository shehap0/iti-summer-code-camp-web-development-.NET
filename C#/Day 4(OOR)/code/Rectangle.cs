using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD04
{
    //Composition
    class Rectangle
    {
        private Point ul;
        private Point lr;

        public Point UL { get { return ul; } set { ul = value; } }
        public Point LR { get { return lr; } set{ lr = value; } }

        //still composition
        public Rectangle()
        {
            ul = new Point();
            lr = new Point();
            Console.WriteLine("rect def ctor");
        }

        public Rectangle(int x1,int y1,int x2,int y2)
        {
            ul = new Point();
            lr = new Point();
            ul.X = x1;
            ul.Y = y1;
            lr.X = x2;
            lr.Y = y2;
            Console.WriteLine("rect 4p ctor");
        }
    }
}
