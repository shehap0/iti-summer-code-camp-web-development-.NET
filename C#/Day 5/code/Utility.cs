using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD05
{
    class Utility
    {
        //failure in open closed principle
        public static double SumOfAreasV1(Rectangle r,Square s,Triangle t)
        {
            double sum = 0;
            sum += r.CArea();
            sum += s.CArea();
            sum += t.CArea();
            return sum;
        }

        //succeed in open closed principle
        public static double SumOfAreasV2(Geoshape[] _shapes)
        {
            double sum = 0;
            for (int i = 0; i < _shapes.Length; i++)
            {
                sum += _shapes[i].CArea();
            }
            return sum;
        }
    }
}
