using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }

        public Department()
        {
            DeptId = 0;
            DeptName = "Unknown";
        }

        public Department(int _deptId, string _deptName)
        {
            DeptId = _deptId;
            DeptName = _deptName;
        }

        public override string ToString()
        {
            return $"{DeptId}:{DeptName}";
        }
    }
}
