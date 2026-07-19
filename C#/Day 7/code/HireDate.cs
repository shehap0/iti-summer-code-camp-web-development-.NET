using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD07
{
    class HireDate :IComparable
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate()
        {
            Day = 1;
            Month = 5;
            Year = 2001;
        }
        public HireDate(int _d,int _m,int _y)
        {
            Day = _d;
            Month = _m;
            Year = _y;
        }
        public override string ToString() 
        {
            return $"{Day}/{Month}/{Year}";
        }

        public int CompareTo(object? obj)
        {
            HireDate right = obj as HireDate;

            return this.Year.CompareTo(right.Year);
        }
    }
}
