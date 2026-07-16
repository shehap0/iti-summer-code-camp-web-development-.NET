using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD05
{
    class Square:Geoshape
    {
        public Square()
        {
            
        }
        public Square(double _dim):base(_dim,_dim)
        {
            //dim1=dim2=_dim;
        }
        public override double CArea()
        {
            return dim1 * dim2;
        }
    }
    /////////////////////
    class SquareV2:Rectangle
    {
        public SquareV2()
        {
            
        }
        public SquareV2(double _dim):base (_dim,_dim) 
        {
            
        }

        //No need to CArea 
    }


    /////
    //sealed class X : Rectangle
    //{

    //}
    //class Y :X
    //{

    //}

    ///struct cannot inherit and cannot be inherited
    //struct Z
    //{

    //}
    /////
}
