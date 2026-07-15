using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD03
{
    class Employee
    {
        #region RULES
        //any data inside class/ struct  called member
        //member data is called by object name
        //public: member can be accessed inside and outside class scope
        //private[encapsulation]: member can be accessed inside class scope ONLYYYY
        #endregion

        #region Data Fields

        //public int id;
        //public string name;
        //public int age;
        //public decimal salary;

        private int id;
        private string name;
        private int age;
        private decimal salary;


        //compiler will execute this line fst time call class ONLY per app run
        private static int counter = 0;
        #endregion

        #region Setters&getters [public]

        public static int GetCounter()
        {
            return counter;
        }

        //caller e1



        //public void SetId(int param)
        //{

        //    /*caller*/
        //    id = param;
        //}
        public int GetId()
        {
            return /*caller*/id;
           
        }

        public void SetId(/*Employee this,*/ int _id)
        {
            this.id = _id;
        }

        #endregion

        #region Property [setters and getters]

        public static int Counter
        {
            get
            {
                return counter;
            }
        }

        public int Id
        {
            set   //void set(int value)
            {
                id=value;
            }
            get  //int get()
            {
                return id;
            }
        }

        public string Name
        {
            set  //void set(string value)
            {
                name= value;
            }
            get // string get()
            {
                return name;
            }
        }

        public int Age
        {
            set
            {
                if (value >= 18 && value <= 60) 
                {
                    age = value;
                }
                else
                {
                    age = 18;
                }
            }
            get
            {
                return age;
            }
        }

        public decimal Salary
        {
            set  //void set(/*Employee this*/decimal value)
            {
                this.salary = value;
            }
            get
            {
                return this.salary;
            }
        }
        #endregion

        #region Print
        //RECOMMENDED
        public string Print()
        {
            return $"{id}:{name}:{this.age}:{salary}";
           
        }
        //NOT RECOMMENDED
        public void Printv2()
        {
            Console.WriteLine(id);
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(salary);
        }
        #endregion

        #region Initialize object
        public void Initialize()
        {
            id = 1;
            name = "Sara";
            age = 22;
            salary = 1234;
        }
        public void Initialize(int _id,string _name,int _age,decimal _salary)
        {
            id = _id;
            name = _name;
            age = _age; 
            salary = _salary;
        }
        #endregion

        #region Ctor
        ////if there is no explicit ctor
        ////o.s will generate empty default paramterless ctor

        //default ctor
        public Employee()
        {
            counter++;

            id = 1;
            name = "Sara";
            age = 22;
            salary = 1234;
        }
        public Employee(int _id, string _name, int _age, decimal _salary)
        {
            counter++;
            id = _id;
            name = _name;
            age = _age;
            salary = _salary;
        }
        #endregion

        #region Destructor -> not used so that C# is auto memory allocation
        //~Employee()
        //{

        //}
        #endregion

    }
}
