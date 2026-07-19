using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD07
{
   class FTP 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private FTP()
        {
            Id = 1;
            Name = "XEROX";
        }

        private FTP(int _id,string _name)
        {
            Id = _id;
            Name = _name;
        }


       static  FTP obj;

        public static  FTP CreateObject()
        {
            if(obj is null)
            {
                obj = new FTP();
                return obj;
            }
            else
            {
                return obj;
            }
        }

    }
}
