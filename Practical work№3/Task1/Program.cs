using System.Diagnostics;  // можно оставить
using Task1;

class Program
{
    static void Main()
    {
        var sw = new Task1.Switch();  // ⚡ вот так точно работает
        Console.WriteLine("Реактор запущен!");
    }
}
