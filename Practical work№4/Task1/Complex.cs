using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Task1;

public struct Complex
{
    //Поля структуры
    public double Real { get; } //действиетельная часть
    public double Imag { get; } //мнимая часть

    //Конструктор
    public Complex(double real, double imag)
    {
        Real = real;
        Imag = imag;
    }

    //Частные случаии(например 1 + 0i)
    public static Complex One => new Complex(1, 0);
    public static Complex Zero => new Complex(0, 0);
    public static Complex ImagZero => new Complex(0, 1); // 0+1i
    public static Complex MinusOne => new Complex(-1, 0);
    public static Complex ImagMinusOne => new Complex(0, -1);

    // ----------------Свойства-------------------------

    //Сложение
    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Imag, a.Imag + b.Imag);
    }

    //Вычитание
    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Imag, a.Imag - b.Imag);
    }

    //Умножение
    public static Complex operator *(Complex a, Complex b)
    {
        return new Complex(a.Real * b.Real - a.Imag - b.Imag,
        a.Imag * b.Real + a.Real * b.Imag);
    }

    //деление
    public static Complex operator /(Complex a, Complex b)
    {
        double denominator = b.Real * b.Real + b.Imag * b.Imag;
        if (denominator == 0)
        {
            throw new DivideByZeroException("Нельзя делить на ноль!");
        }
        return new Complex((a.Real * b.Real + a.Imag * b.Imag) / denominator,
        (a.Imag * b.Real - a.Real * b.Imag) / denominator);
    }


    //Модуль комлексного числа
    public double Module => Math.Sqrt(Real * Real + Imag * Imag);

    //преобразование в экспотенциальную форму
    public (double r, double fi) ToExpotential()
    {
        double r = Math.Sqrt(Real * Real + Imag * IMag);
        double fi = Math.Atan2(Imag, Real);
        return (r, fi);
    }

    //обратное преобразование
    public static Complex FromExpotential(double r, double fi)
    {
        double real = r * Math.Cos(fi);
        double imag = r * Math.Sin(fi);
        return new Complex(real, imag);
    }

    //Перегрузка оператора ==
    public static bool operator ==(Complex a, Complex b)
    {
        return Math.Abs(a.Real - b.Real) < 1e-10 &&
        Math.Abs(a.Imag - b.Imag) < 1e-10;
    }

    //Перегрузка !=
    public static bool operator !=(Complex a, Complex b) => (a == b);

    //Пререопределение Equals
    public override bool Equals(object? obj)
    {
        if (obj is Complex c)
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
            return $"{Real}";
        if (Real == 0)
            return $"{Imag}";
        if (Imag > 0)
            return $"{Real} + {Imag}";
        return $"{Real}"
    }
}