using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD06
{
    class Student
    {
        #region Traditional way to create Data and its property
        string name;
        int id;
 
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }



       
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        #endregion

        #region New Way [Automatic property]
        public int Age { set; get; }
        //compiler 
        ///int age;
        ///public int Age{set{age=value;} get{return age;}}
        ///

        ///WRONG
        ///string address;
        ///public string Address { set; get; }


        decimal salary;
        public decimal Salary
        {
            set
            {
                if (value >= 8000 && value < 10000)
                { salary = value; }
                else
                {
                    salary = 8000;
                }

            }
            get
            {
                return salary;
            }
        }
        #endregion


    }
}
