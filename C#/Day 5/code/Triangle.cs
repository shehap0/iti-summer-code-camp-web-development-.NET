using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD05
{
    class Triangle : Geoshape
    {
        public Triangle()
        {

        }
        public Triangle(double _base, double _height)
        {
            dim1 = _base;
            dim2 = _height;
        }

        public override double CArea()
        {
            return 0.5 * dim1 * dim2;
        }
    }
}
