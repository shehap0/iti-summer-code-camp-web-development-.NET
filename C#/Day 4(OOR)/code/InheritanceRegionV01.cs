using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD04
{
    //class Parent
    //{
    //    private int x;
    //    private int y;
    //    public int X { get { return x; } set { x = value; } }
    //    public int Y { get { return y; } set { y = value; } }
    //    //c1 call PAren() to initalize inherited members
    //    public Parent()
    //    {
    //        x = y = 0;
    //        Console.WriteLine("parent def ctor");
    //    }
    //    public Parent(int _x, int _y)
    //    {
    //        x = _x;
    //        y = _y;
    //        Console.WriteLine("parent 2p ctor");
    //    }
    //    public int SumXY()
    //    {
    //        return x + y;
    //    }
    //}

    //////child inherts everything from parent
    //class Child : Parent
    //{
    //    //x,y,X,Y,SumXY
    //    int z;


    //    public int Z { get { return z; } set { z = value; } }

    //    public Child()
    //    {
    //        ///c1  x|0| y|0| z|?|
    //        z = 0;
    //        ///c1  x|0| y|0| z|0|
    //        //x = y = 0;  //inaccessible
    //        ////useless
    //        X = 0;
    //        Y = 0;
    //        Console.WriteLine("child def ctor");
    //    }

    //    //public Child(int _x, int _y, int _z)
    //    //{
    //    //    ///c2 x|0| y|0| z|?|
    //    //    z = _z;
    //    //    ///c2 x|0| y|0| z|3|
    //    //    X = _x;
    //    //    //c2 x|1| y|0| z|3|
    //    //    Y = _y;
    //    //    ///c2 x|1| y|2| z|3|
    //    //    Console.WriteLine("Child 3p ctor");
    //    //}

    //    //ctor chaining 1- increase performance 2- reduce code written
    //    public Child(int _x, int _y, int _z) : base(_x, _y)
    //    {
    //        ///c2 x|1| y|2| z|?|
    //        z = _z;
    //        ///c2 x|1| y|2| z|3|
    //        //after ctor chaining ->useless
    //        //X = _x;
    //        //Y = _y;
    //        ///c2 x|1| y|2| z|3|
    //        Console.WriteLine("Child 3p ctor");
    //    }

    //    public int SumXYZ()
    //    {
    //        return z + X + Y;
    //        return z + SumXY();
    //    }

    //}

}
