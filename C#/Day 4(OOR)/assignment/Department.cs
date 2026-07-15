using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Department
    {
        private string deptName;
        private Professor mgr;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        public Professor Mgr
        {
            get { return mgr; }
            set { mgr = value; }
        }

        public Department(string _deptName, Professor _mgr)
        {
            deptName = _deptName;
            mgr = _mgr;
        }

        public string PrintInfo()
        {
            return $"Department: {deptName}, Managed by: {mgr.Name}";
        }
    }
}
