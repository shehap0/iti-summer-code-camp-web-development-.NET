using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD07
{
    interface IMyInterface
    {
        string Name { get; set; }
        int Age { set; get; }
        void Register();
        void Login();
        void Logout();
    }

    interface IMyInterface2 
    {
        void Commission();
        void Deduction();
    }

    class ParentDept { }

    class Department : ParentDept, IMyInterface, IMyInterface2
    {
        public string Name { get ; set ; }
        public int Age { get ; set; }

        public void Commission()
        {
            throw new NotImplementedException();
        }

        public void Deduction()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
