namespace SummerJulG3CSD04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region OOR
            //Object Oriented Relations
            //Relation between classes

            //1-Composition [Tightly Coupled]
            //class Contains All Of Another class

            //2-Aggregation [loosely coupled]
            //class may contains another class later

            //3-Association [Very Loosely coupled]
            //peer to peer each class may not depend on
            //another one 

            //4- inheritance
            ////////////////////////////////////////////////////////
            //A-Association [Very Loosely coupled]
            ///1- Peer-To-Peer
            //teacher    subject
            ///2- Temporarily relation
            ///3- represent in code
            //Pointer of class inside another class
            //C# Reference of class inside another class
            ///class Teacher
            //{
            //id,name,age
            //Subject sub;
            //ctor(){sub=null;}
            //};
            //class Subject{} 
            //4- 1-1  1-M M-M  1-0
            //5- No Dependency


            //B-Aggregation [loosely coupled]
            ///1- Whole vs. part
            ///      Student       Department
            ///2- temp. Relation
            ///3- Resresent in code
            /// Pointer of class inside another class
            //C# Reference of class inside another class
            ///class Student
            //{
            //id,name,age
            //Department  Dept;
            //ctor(){dept=null;}
            //};
            ///4- 1-1   1-M M-M 1-0
            ///5- No Dependency


            //C- Composition [Tightly Coupled] has a
            ///1- complete ownership
            ///2- Permenant relationship
            //Room    wall
            ///3- object of class inside another class
            ///class Room
            //{
            //Wall  w1=new();
            //Wall  w2=new();
            //Wall  w3=new();
            //Wall  w4=new();

            //};
            ///main  room r[10] ||||||||
            //room r1,r2,r3
            ///4- 1-1 1-m 
            ///5- Complete Dependency



            ///SOLID principles
            ///loosely coupled
            #endregion

            #region Composition example

            //Line l1 = new Line(); // l1 start x|| y||    end x|| y||
            ////o/p
            ////point def ctor start
            ////point def ctor end
            ////line def ctor


            //Line l2 = new Line(1, 2, 3, 4);
            //Console.WriteLine(l2.Print());
            ////o/p
            ////point def ctor start
            ////point def ctor end
            ////line 4p ctor


            // Rectangle r1 = new Rectangle();
            ////o/p
            ////point def ctor ul
            ////point def ctor lr
            ////rect def ctor


            //Rectangle r2 = new Rectangle(1, 2, 3, 4);


            #endregion

            #region Aggregation /association MOST USED  

            //Point pnt1 = new Point(3, 4);
            //Point pnt2 = new Point(5, 6);
            //Point pnt3 = new Point(7, 8);


            //Triangle t1 = new Triangle(); // ti 
            ////o/p
            ////tri def ctor


            /////build relationship
            //t1.P1 = pnt1;
            //t1.P2 = pnt2;
            //t1.P3 = pnt3;

            ////remove relationship
            //t1.P1 = null;
            //t1.P2 = null;
            //t1.P3 = null;




            //Triangle t2 = new Triangle(pnt1, pnt2, pnt3);

            ////remove relationship
            //t2.P1 = null;
            //t2.P2 = null;
            //t2.P3 = null;

            #endregion

            #region Inheritance is a
            ///inheritance: extend properties and methods from Dt to another one
            ///Inheritancce: Properties and method inside dt gained from another one
            ///

            ///TypeA
            /////x
            /////y
            /////FunOne()
            /////FunTwo()

            ///TypeB
            /////y
            /////z
            /////FunTwo()
            /////FunThree()
            ///


            ///Base
            ///y
            ///FunTwo()

            ///TypeA Inherits Base
            /////x
            /////FunOne()

            ///TypeB Inherits Base
            /////z
            /////FunThree()
            ///
            ///Child Inherits everything from parent 
            #endregion

            #region Inheritance example v01
            //Parent p1 = new Parent(3, 4); //8B  

            //Child c1 = new Child(); //12B  //x|| y|| z||
            ////o/p
            ////parent def ctor
            ////child def ctor


            //Child c2 = new Child(1, 2, 3);
            ////o/p
            ////parent def ctor
            ////child 3p ctor
            #endregion

            #region protected [inheritance]
            //private member is inherited 
            //but cannot be accessed

            ///protected [smart private]
            ///member can be accessed
            ///inside class 
            ///and accessed inside chain of inheritance
            ///ONLY
            ///
            //Parent p1 = new Parent();//????? 8b
            //p1.x = 22;
            #endregion

            #region Overriding [inheritance]
            /////function has same name,same parameters
            /////but body is different in child DT
            /////
            Child c2 = new Child(1, 2, 3);
            //Console.WriteLine(c2.Sum()); //???
            #endregion
        }
    }
}
