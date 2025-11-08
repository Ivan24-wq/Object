namespace Task1;
class Program
{
    static void Main()
    {
        var a = new Complexx(2, 1);
        var b = new Complexx(3, -1);

        //Мат опреции
        var add = a + b;
        var minus = a - b;
        var multiply = a * b;
        var div = a / b;
        var mod = a.Module;


        //Вывод
        Console.WriteLine($"\nСложение чисел: (2+i)*(3-i): {add}");
        Console.WriteLine($"\nВычитание: (2+i)*(3-i): {minus}");
        Console.WriteLine($"\nУмножение: (2+i)*(3-i): {multiply}");
        Console.WriteLine($"\nДеление: (2+i)*(3-i): {div}");
        Console.WriteLine($"\nМодуль числа: (2+i): {mod:F3}");
    }
}