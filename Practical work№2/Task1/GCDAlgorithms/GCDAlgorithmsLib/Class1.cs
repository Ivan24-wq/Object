using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDAlgorithmsLib
{
    public static class EuclidAlgorithm
    {
        public static int FindGCDEuclid(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // Делим до тех пор пока в остатке не получим ноль
            while (b != 0)
            {
                int res = a % b;
                a = b;
                b = res;
            }
            return a;
        }
    }
}
