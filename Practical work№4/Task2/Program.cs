using System.Numerics;
namespace Task2;
class Program
{
    static void Main()
    {
        //масса студента 
        double m = 70;
        double v = 7;
        //широта города
        double Deg = 45;
        //угловая скорость Земли
        double omega = 7.292115e-5;

        //Перевод в радианы
        double fi = Math.PI * Deg / 180;

        //Бежит на юг
        Vectorx vVec = new Vectorx(0, -v, 0);
        //Угловая скорость(векторное направление)
        Vectorx omegaVec = new Vectorx(0, omega * Math.Cos(fi), omega * Math.Sin(fi));
        //Сила Криолиса
        Vectorx Fc = -2 * m * Vectorx.Vec(omegaVec, vVec);

        Console.WriteLine($"Сила криолиса: {Fc}");
        Console.WriteLine($"Модуль силы Криолиса: {Fc.Module:F4}");
    }
}