using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerJulG3CSD03
{
    class Utility
    {
        public void Swap(int left,int right)
        {
            int tmp;
            tmp = left;
            left = right;
            right=tmp;
        }

        public void SwapR(ref int left,ref int right)
        {
            int tmp;
            tmp = left;
            left = right;
            right = tmp;
        }

        public void MultipleArrayByTen(ref  int[] param)
        {
            for (int i = 0; i < param.Length; i++) 
            {
                param[i] *= 10;
            }
        }
    }
}
