namespace SummerJulG3CSD05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Inheritance V2
            //Rectangle r1 = new Rectangle(3, 4); // r1 dim1 = 3 dim2 = 4

            //Square s1 = new Square(10);
            ////o/p
            ////geo ctor
            ////square ctor

            //SquareV2 s2 = new SquareV2(10);
            ////o/p
            ////geo ctor
            ////rect ctor
            ////sqv2 ctor

            #endregion

            #region early/static binding [compile Time]

            //Base b1 = new Base();


            //b1.Show(); //i'm base
            /////compiler will retrieve copy of show that
            /////balongs to reference type

            //Derived d1 = new Derived(1, 2, 3);
            //d1.Show(); //i'm Derived
            /////compiler will retrieve copy of show that
            /////balongs to reference type

            //Derived2 d2 = new Derived2();
            //d2.Show(); //i'm derived 2
            /////compiler will retrieve copy of show that
            /////balongs to reference type
            /////

            ///////////////////////////////////////////////////////

            //Base b1 = new Derived(1, 2, 3);

            /////الأب يحتوي جميع ابناؤه
            /////car is a viechle
            /////bus is a viechle 
            //b1.Show(); //i'm base
            ///////compiler will retrieve copy of show that
            ///////balongs to reference type
            /////
            //Derived d1 = new Derived2();
            //d1.Show(); //i'm derived

            //Base b2 = new Derived2();
            //b2.Show(); //i'm base
            /////compiler will retrieve copy of show that
            /////balongs to reference type
            /////

            /////NOT MAKE SENSE
            /////

            /////Early Binding [static binding]:
            /////when reference from parent References object from 
            /////its child and call overridden method,
            /////compiler will early retrieve copy of refernce type
            /////not copy of object

            #endregion

            #region late/dynamic binding  [Run time]
            /////when reference from parent References object from 
            /////its child and call overridden method,
            /////compiler will later retrieve copy of Object 
            /////not copy of Reference

            ////1-function to be overridden in base class must be
            ///////public and virtual
            ////2-overridden method in child class must enclude [override]
            ////3-make reference from parent references object from its childs

            //Base b1 = new Derived(1, 2, 3);
            //b1.Show(); //i'm derived

            //Derived d1 = new Derived2();
            //d1.Show(); //i'm derived 2

            //Base b2 = new Derived2();
            //b2.Show(); //i'm derived 2
            #endregion

            #region Example for Late Binding 
            //Rectangle r1 = new Rectangle(3, 4); 
            //Rectangle r2 = new Rectangle(3, 4);           
            //Rectangle r3 = new Rectangle(3, 4);
            //Square s1 = new Square(10);
            //Triangle t1 = new Triangle(3, 4);
            //Circle c1 = new Circle(7);


            ////Console.WriteLine(Utility.SumOfAreasV1(r1, s1, t1));

            ////Geoshape g1 = new Rectangle(3, 4);
            ////Console.WriteLine(g1.CArea()); //12

            //Geoshape[] shapes = { r1, s1, t1, c1 };

            //Console.WriteLine(Utility.SumOfAreasV2(shapes));

            #endregion

            #region abstract class
            ///abstract class : calss we cannot create object from it
            //Geoshape g1 = new Geoshape();
            #endregion

            #region Abstract method
            ///virtual method header only with keyword abstract 
            ///must be overridden
            #endregion

            #region Sealed class
            //class can inherit but cannot be iherited
            #endregion

            #region Lab Assignments 
            ////class geoshape 
            ///rect
            ///sq
            ///sqv2
            ///tri
            ///cir
            ///
            ///////SumOfAreas(s,s,t,r)
            ///////SumOfAreas(shapes[])
            ///
            ///try static vs dynamic binding
            #endregion

           
        }
    }
}
