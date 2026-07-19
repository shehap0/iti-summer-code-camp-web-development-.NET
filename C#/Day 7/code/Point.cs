using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD07
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Point()
        {
            X = Y = 0;
        }


        public override string ToString()
        {
            return $"({X},{Y})";
        }


        //p1.Equals(p2)    this  caller p1      , p2   right
        public override bool Equals(object? obj)
        {
            Point right = obj as Point;

            if (right == null) { return false; }

            if (object.ReferenceEquals(this, right) == true) { return true; }

            return this.X == right.X && this.Y == right.Y;
        }

    }
}
