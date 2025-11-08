using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Task1;

public struct Complexx
{
    //Поля структуры
    public double Real { get; } //действиетельная часть
    public double Imag { get; } //мнимая часть

    //Конструктор
    public Complexx(double real, double imag)
    {
        Real = real;
        Imag = imag;
    }

    //Частные случаии(например 1 + 0i)
    public static Complexx One => new Complexx(1, 0);
    public static Complexx Zero => new Complexx(0, 0);
    public static Complexx ImagZero => new Complexx(0, 1); // 0+1i
    public static Complexx MinusOne => new Complexx(-1, 0);
    public static Complexx ImagMinusOne => new Complexx(0, -1);

    // ----------------Свойства-------------------------

    //Сложение
    public static Complexx operator +(Complexx a, Complexx b)
    {
        return new Complexx(a.Real + b.Real, a.Imag + b.Imag);
    }

    //Вычитание
    public static Complexx operator -(Complexx a, Complexx b)
    {
        return new Complexx(a.Real - b.Real, a.Imag - b.Imag);
    }

    //Умножение
    public static Complexx operator *(Complexx a, Complexx b)
    {
        return new Complexx(a.Real * b.Real - a.Imag * b.Imag,
        a.Imag * b.Real + a.Real * b.Imag);
    }

    //деление
    public static Complexx operator /(Complexx a, Complexx b)
    {
        double denominator = b.Real * b.Real + b.Imag * b.Imag;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Нельзя делить на ноль!");
        }
        return new Complexx((a.Real * b.Real + a.Imag * b.Imag) / denominator,
        (a.Imag * b.Real - a.Real * b.Imag) / denominator);
    }


    //Модуль комлексного числа
    public double Module => Math.Sqrt(Real * Real + Imag * Imag);

    //преобразование в экспотенциальную форму
    public (double r, double fi) ToExpotential()
    {
        double r = Math.Sqrt(Real * Real + Imag * Imag);
        double fi = Math.Atan2(Imag, Real);
        return (r, fi);
    }

    //обратное преобразование
    public static Complexx FromExpotential(double r, double fi)
    {
        double real = r * Math.Cos(fi);
        double imag = r * Math.Sin(fi);
        return new Complexx(real, imag);
    }

    //Перегрузка оператора ==
    public static bool operator ==(Complexx a, Complexx b)
    {
        return Math.Abs(a.Real - b.Real) < 1e-10 &&
        Math.Abs(a.Imag - b.Imag) < 1e-10;
    }

    //Перегрузка !=
    public static bool operator !=(Complexx a, Complexx b) => !(a == b);

    //Пререопределение Equals
    public override bool Equals(object? obj)
    {
        if (obj is Complexx c)
        {
            return this == c;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Real, Imag);
    }

    //Перегрузка ToString
    public override string ToString()
    {
        if (Imag == 0)
            return $"{Real:F1}";
        if (Real == 0)
            return $"{Imag:F1}i";
        if (Imag > 0)
            return $"{Real:F1} + {Imag:F1}i";
        return $"{Real:F1} - {Imag:F1}i";
    }
}