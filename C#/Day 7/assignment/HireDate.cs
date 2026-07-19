using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class HireDate : IComparable
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate()
        {
            Day = 1;
            Month = 1;
            Year = 2000;
        }

        public HireDate(int _d, int _m, int _y)
        {
            Day = _d;
            Month = _m;
            Year = _y;
        }

        public override string ToString(){return $"{Day}/{Month}/{Year}";}

        public int CompareTo(object? obj)
        {
            HireDate right = obj as HireDate;
            return this.Month.CompareTo(right.Month);
        }
    }
}
