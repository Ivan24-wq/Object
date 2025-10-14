using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteinAlgorihtm
{
    public static class EuclidAlgorithm
    {
        public static int FindGCDEuclid(int a, int b, out long time)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            //Засекаем время
            time = 0;
            var sw = System.Diagnostics.Stopwatch.StartNew();

            // Делим до тех пор пока в остатке не получим ноль
            while (b != 0)
            {
                int res = a % b;
                a = b;
                b = res;
            }
            sw.Stop();
            time = sw.ElapsedTicks;
            return a;
        }
    }
}
