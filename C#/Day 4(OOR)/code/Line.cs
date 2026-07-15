using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD04
{
    //tightly coupled [Composition]
    class Line
    {
        private Point start = new Point(); 
        private Point end = new Point();

        public Point Start {  get { return start; } set { start = value; } }
        public Point End { get { return end; } set { end = value; } }

        public Line()
        {
            //l1 start x|0| y|0|  end x|0| y|0|
          //  start.x = 0;  //inaccessible
            //useless
            start.X = 0;
            start.Y = 0;
            end.X = 0;
            end.Y = 0;
            Console.WriteLine("line def ctor");
        }

        public Line(int x1,int y1,int x2,int y2)
        {
            //l2 start x|0|y|0|  end x|0|y|0|
            start.X=x1;
            start.Y=y1;
            end.X=x2;
            end.Y=y2;
            //l2 start x|1|y|2|  end x|3|y|4|
            Console.WriteLine("Line 4p ctor");
        }

        public string Print()
        {
            return $"Line start ({start.X},{start.Y})  end ({end.X},{end.Y})";
        }

    }
}
