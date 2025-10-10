using System;


namespace GCDAlgorithms
{
    //Реализация нахождения НОД
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
