using System.Diagnostics.CodeAnalysis;
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
    public static Vectorx operator *(double scalar, Vectorx a)
    {
        return a * scalar;
    }

    //Скалярное произведение
    public static double Scal(Vectorx a, Vectorx b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    //Деление на скаляр
    public static Vectorx operator /(Vectorx a, double scalar)
    {
        return new Vectorx(a.X / scalar, a.Y / scalar, a.Z / scalar);
    }

    // Векторное произведение
    public static Vectorx Vec(Vectorx a, Vectorx b)
    {
        return new Vectorx(a.Y * b.Z - a.Z * b.Y,
                            a.Z * b.X - a.X * b.Z,
                            a.X * b.Y - a.Y * b.X);
    }

    //Модуль вектора
    public double Module => Math.Sqrt(X * X + Y * Y + Z * Z);

    //Нормализация вектора
    public Vectorx Normalize()
    {
        double mod = Module;
        return mod == 0 ? new Vectorx(0, 0, 0) : new Vectorx(X / mod, Y / mod, Z / mod);
    }

    //Перегрузка оператора ==
    public static bool operator ==(Vectorx a, Vectorx b)
    {
        return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }
    public static bool operator !=(Vectorx a, Vectorx b)
    {
        return !(a == b);
    }

    //Преобразование Equals
    public override bool Equals(object? obj)
    {
        if (obj is Vectorx other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    // Перегрузка ToString
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }
}
