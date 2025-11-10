using System.Numerics;
using System.Reflection;

namespace Task2;

public struct Vectorx
{
    //Поля
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    //Конструктор
    public Vectorx(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    //----------Свойства трехмерного ветора

    //Сложение
    public static Vectorx operator +(Vectorx a, Vectorx b)
    {
        return new Vectorx(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    // Вычитание
    public static Vectorx operator -(Vectorx a, Vectorx b)
    {
        return new Vectorx(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    //Умножение(на скаляр)
    public static Vectorx operator *(Vectorx a, double scalar)
    {
        return new Vectorx(a.X * scalar, a.Y * scalar, a.Z * scalar);
    }

    //Скалярное произведение
    public static double Scal(Vectorx a, Vectorx b)
    {
        return new Vectorx(a.X * b.X + a.Y * b.Y + a.Z * b.Z);
    }

    //Деление на скаляр
    public static Vectorx operator /(Vectorx a, double scalar)
    {
        return new Vectorx(a.X / scalar, a.Y / scalar, a.Z / scalar);
    }

    // Векторное произведение
    public static Vectorx Vec(Vectorx a, Vectorx b)
    {
        return new Vectorx(b.Y * b.Z - a.Z - b.Z,
                            a.Z * b.X - a.X * b.Z,
                            a.X * b.Y - a.Y * b.X);
    }

    //Модуль вектора
    public double Module => Math.Abs(X * X + Y * Y + Z * Z);

    //Нормализация вектора
    public Vectorx Normalixe()
    {
        double mod = Module;
        return mod == 0 ? new Vectorx(0, 0, 0) : new Vectorx(X / mod, Y / mod, Z / mod);
    }
}
