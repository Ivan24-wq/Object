using System;
using System.Threading;
using DeviceController;

namespace MeasuringDevice
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;            // Выбранная система измерений
        private int[] dataCaptured;          // Кольцевой буфер
        private int mostRecentMeasure;       // Последнее измерение

        private DeviceController.DeviceController controller; // Эмулируемое устройство

        private const DeviceType measurementType = DeviceType.LENGTH;

        // Конструктор
        public MeasureLengthDevice(Units units)
        {
            unitsToUse = units;
        }

        // Запуск сбора данных
        public void StartCollecting()
        {
            controller = DeviceController.DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }

        // Остановка сбора
        public void StopCollecting()
        {
            if (controller != null)
            {
                controller.StopDevice();  // Важно: латинская 'c'
                controller = null;
            }
        }

        // Массив сырых данных
        public int[] GetRawData()
        {
            return dataCaptured;
        }

        // Значение в метрической системе
        public decimal MetricValue()
        {
            if (unitsToUse == Units.Metric)
                return mostRecentMeasure;
            else
                return mostRecentMeasure * 25.4m;
        }

        // Значение в имперской системе
        public decimal ImperialValue()
        {
            if (unitsToUse == Units.Imperial)
                return mostRecentMeasure;
            else
                return mostRecentMeasure * 0.03937m;
        }

        // Фоновый сбор измерений
        private void GetMeasurements()
        {
            dataCaptured = new int[10];
            ThreadPool.QueueUserWorkItem((_) =>
            {
                int x = 0;
                Random timer = new Random();

                while (controller != null)
                {
                    Thread.Sleep(timer.Next(1000, 5000));

                    dataCaptured[x] = controller.TakeMeasurement();
                    mostRecentMeasure = dataCaptured[x];

                    x++;
                    if (x == 10)
                        x = 0;
                }
            });
        }
    }
}
