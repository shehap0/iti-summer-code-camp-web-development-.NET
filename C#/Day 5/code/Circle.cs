using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD05
{
    class Circle:Geoshape
    {
        public Circle()
        {
            
        }
        public Circle(double _radius):base(_radius,_radius)
        {
            
        }
        public override double CArea() 
        {
            return 3.14 * dim1 * dim2;
            return 22f / 7 * dim1 * dim2; //WRONG
            return dim1 * dim2 * (22/7);
            return dim1 * dim2 * Math.PI;
        }
    }
}
