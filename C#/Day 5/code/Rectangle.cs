using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD05
{
    class Rectangle:Geoshape
    {
        //fields?

        public Rectangle()
        {
            //useless
            //dim1 = dim2 = 0;
            Console.WriteLine("Rect def ctor");
        }
        public Rectangle(double _d1,double _d2):base(_d1,_d2) 
        {
            //after ctor chaining -> useless
            //dim1= _d1;
            //dim2= _d2;
            Console.WriteLine("rect 2p ctor");
        }

        //public  double CArea()
        // {
        //     return dim1 * dim2;
        // } 



        public override double CArea()
        {
            return dim1 * dim2;
        }
    }
}
