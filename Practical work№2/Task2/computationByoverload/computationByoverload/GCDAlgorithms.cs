using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computationByoverload
{
    class EuclidAlgorithm
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
        //Перегрузка метода
        public static int FindGCDEuclid(int a, int b, int c)
        {
            int d = FindGCDEuclid(a, b);
            int e = FindGCDEuclid(d, c); //НОД последнего и терьего
            return e;
        }

        //4 числа
        public static int FindGCDEuclid(int a, int b, int c, int d)
        {
            int f = FindGCDEuclid(a, b, c);
            //Аналогично находим НОД ответа и третьего
            int res = FindGCDEuclid(f, c);
            return res;
        }

        //5 числа
        public static int FindGCDEuclid(int a, int b, int c, int d, int e)
        {
            int g = FindGCDEuclid(a, b, c, d);
            int res = FindGCDEuclid(g, e);
            return res;
        }
    }
}
