using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteinAlgorihtm
{
    public static class Stein
    {
        public static int FindGSDStrein(int u, int v, out long time)
        {

            var sw = Stopwatch.StartNew();
            int k = 0;
            //Шаг 1
            if (u == 0 || v == 0)
            {
                sw.Stop();
                time = sw.ElapsedTicks;
                return u | v;
            }

            //Шаг 2(оба четные)
            for(k = 0; ((u | v) & 1) == 0; ++k)
            {
                u >>= 1;
                v >>= 1;
            }

            //Шаг 3 (если чётное и нечётное)
            while ((u & 1) == 0)
                u >>= 1;

            //Оба нечетные
            do
            {
                while ((v & 1) == 0)
                    v >>= 1;

                
                if (u < v)
                {
                    v -= u;
                }
                else
                {
                    int diff = u - v;
                    u = v;
                    v = diff;
                }

                v >>= 1; 
            } while (v != 0);

            u <<= k;

            sw.Stop();
            time = sw.ElapsedTicks;

            return u;
        }
    }
}
