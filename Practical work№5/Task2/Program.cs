using MeasuringDevice;
using System;

class Program
{
    static void Main()
    {
        MeasureMassDevice device = new MeasureMassDevice(Units.Metric);
        // Подписка на событие
        EventHandler newMeasurementTaken = new EventHandler(Device_NewMeasurementTaken);
        device.NewMeasugementTaken += newMeasurementTaken;

        // Запуск сбора данных
        device.StartCollecting();

        Console.WriteLine("Сбор данных запущен. Нажмите Enter для остановки...");
        Console.ReadLine();

        // Остановка и освобождение ресурсов
        device.Dispose();

        Console.WriteLine("Testing MeasureMassDevice...");

        IMeasuringDevice massDev = new MeasureMassDevice(Units.Metric);

        massDev.StartCollecting();
        Console.WriteLine("Collecting data for 5 seconds...");
        Thread.Sleep(5000);

        Console.WriteLine("Metric mass: " + massDev.MetricValue());
        Console.WriteLine("Imperial mass: " + massDev.ImperialValue());

        Console.WriteLine("Raw data:");
        foreach (var v in massDev.GetRawData())
            Console.Write(v + " ");

        Console.WriteLine("\nStopping...");
        massDev.StopCollecting();


        Console.WriteLine("\n\nTesting MeasureLengthDevice...");

        IMeasuringDevice lenDev = new MeasureLengthDevice(Units.Imperial);
        lenDev.StartCollecting();
        Thread.Sleep(5000);

        Console.WriteLine("Metric length: " + lenDev.MetricValue());
        Console.WriteLine("Imperial length: " + lenDev.ImperialValue());

        Console.WriteLine("Raw data:");
        foreach (var v in lenDev.GetRawData())
            Console.Write(v + " ");

        lenDev.StopCollecting();

        Console.WriteLine("\n\nDone.");

        //Обработчик события новых измерений
        static void Device_NewMeasurementTaken(object? sender, EventArgs e)
        {
            if(sender is MeasureDataDevice device)
            {
                //Получение последних изменений
                int lastest = device.GetRawData().Last();
                if(lastest != 0)
                    Console.WriteLine($"\nНовое измерение: {lastest}");
            }
        }
    }
}
