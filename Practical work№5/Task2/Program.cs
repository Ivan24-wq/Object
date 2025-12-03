using MeasuringDevice;
using System;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        // Создаем устройство с heartbeat = 1000мс
        MeasureMassDevice device = new MeasureMassDevice(Units.Metric, 1000);

        // Подписка на событие новых измерений
        device.NewMeasugementTaken += Device_NewMeasurementTaken;

        // Подписка на HeartBeat
        device.HeartBeat += (sender, args) =>
        {
            Console.WriteLine($"[HEARTBEAT] {args.TimeStamp:HH:mm:ss.fff}");
        };

        device.StartCollecting();

        Console.WriteLine("Сбор данных запущен. Нажмите Enter для остановки...");
        Console.ReadLine();

        // Остановка и освобождение ресурсов
        device.Dispose();

        Console.WriteLine("\nТестирование MeasureMassDevice...");

        IMeasuringDevice massDev = new MeasureMassDevice(Units.Metric, 1000);
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

        Console.WriteLine("\nDone.");
    }

    // Обработчик новых измерений
    static void Device_NewMeasurementTaken(object? sender, EventArgs e)
    {
        if (sender is MeasureDataDevice device)
        {
            int last = device.GetRawData().LastOrDefault();
            Console.WriteLine($"\nНовое измерение: {last}");
        }
    }
}
