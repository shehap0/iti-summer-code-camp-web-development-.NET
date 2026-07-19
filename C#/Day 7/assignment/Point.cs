using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
            X = Y = 0;
        }

        public Point(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public override string ToString() {return $"({X},{Y})";}

        public override bool Equals(object? obj)
        {
            Point right = obj as Point;

            if (right == null) { return false; }
            if (object.ReferenceEquals(this, right) == true) { return true; }

            return this.X == right.X && this.Y == right.Y;
        }
    }
}
