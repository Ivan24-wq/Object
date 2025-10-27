using System.Diagnostics;  
using Task1;

class Program
{
    static void Main()
    {
        var sw = new Task1.Switch();
        Console.WriteLine("Реактор запущен!");

        //Отключение генератора
        try
        {
            Console.WriteLine("Отключение генератора");
            var res = sw.DisconnectPowerGenerator();
            Console.WriteLine($"Результат: {res}");
        }
        catch (PowerGeneratorCommsException ex)
        {
            Console.WriteLine($"Исключение на шаге1: {ex.Message}");
        }


        // Проверка системы охлаждения
        try
        {
            Console.WriteLine("Проверка основной системы охлаждения");
            var status = sw.VerifyPrimaryCoolantSystem();
            Console.WriteLine($"Статус системы охлажения: {status}");
        }
        catch (CoolantPressureReadException ex)
        {
            Console.WriteLine($"Исключение на шаге 2 (давление): {ex.Message}");
        }
        catch (CoolantTemperatureReadException ex)
        {
            Console.WriteLine($"Исключение температура: {ex.Message}");
        }


        //Проверка резервной системы охлаждения
        try
        {
            Console.WriteLine("Проверка резервной системы охлаждения!");
            var tstatus = sw.VerifyBackupCoolantSystem();
            Console.WriteLine($"Статус резервной системы охлаждения: {tstatus}");
        }
        catch (CoolantPressureReadException ex)
        {
            Console.WriteLine($"Давление: {ex.Message}");
        }
        catch (CoolantTemperatureReadException ex)
        {
            Console.WriteLine($"Температура: {ex.Message}");
        }

        //Проверка темпераутры ядра
        try
        {
            Console.WriteLine("Проверка температуры ядра!");
            var temperature = sw.GetCoreTemperature();
            Console.WriteLine($"Температура ядра: {temperature}");
        }
        catch (CoreTemperatureReadException ex)
        {
            Console.WriteLine($"Исключение для температуры ядра: {ex.Message}");
        }

        //Остановка реактора путём введения стержней в активную зону
        try
        {
            Console.WriteLine("Остановка реактора путём введения стержней в активную зону");
            var res = sw.InsertRodCluster();
            Console.WriteLine($"Реактор: {res}");
        }
        catch(RodClusterReleaseException ex)
        {
            Console.WriteLine($"Исключение для реактора: {ex.Message}");
        }
    }
}
