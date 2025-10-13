using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SteinAlgorihtm
{
    class Prime
    {
        private static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; ++i)
                if (n % i == 0) return false;
            return true;
        }

        //Представим число через двойной сдвиг
        private static string Shift(int number)
        {
            return number switch
            {
                11 => "(2 << 3) + (2 << 1) + (2>>1)",
                7 => "(2 << 2) + (2 << 1) - (2 >> 1)",
                5 => "(2 << 2) + (2 >> 1)",
                3 => "2 + (2 >> 1)",
                2 => "2",
                _ => "Нет представленного типа"
            };
        }

        public static string ShowShift(int n)
        {
            int prime = n - 1;
            while (prime > 1  && !IsPrime(prime))
                prime--;
            string res = $"Наибольшее простое: {n}:{prime}\n" +
                         $"Представленное через 2 сдвига: {Shift(prime)}";
            return res;
        }
    }
}
