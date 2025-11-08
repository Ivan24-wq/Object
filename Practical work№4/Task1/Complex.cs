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

    
}