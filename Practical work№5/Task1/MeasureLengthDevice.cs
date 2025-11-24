using System;
using System.Threading;

namespace MeasuringDevice
{
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;            
        private int[] dataCaptured;          
        private int mostRecentMeasure;       

        private DeviceController.DeviceController controller;

        private const DeviceController.DeviceType measurementType =
            DeviceController.DeviceType.LENGTH;

        public MeasureLengthDevice(Units units)
        {
            unitsToUse = units;
        }

        public void StartCollecting()
        {
            controller = DeviceController.DeviceController.StartDevice(measurementType);
            GetMeasurements();
        }

        public void StopCollecting()
        {
            if (controller != null)
            {
                controller.StopDevice();
                controller = null;
            }
        }

        public int[] GetRawData()
        {
            // ЧТОБЫ UI не падал
            return dataCaptured ?? Array.Empty<int>();
        }

        public decimal MetricValue()
        {
            if (unitsToUse == Units.Metric)
                return mostRecentMeasure;
            else
                return mostRecentMeasure * 25.4m;
        }

        public decimal ImperialValue()
        {
            if (unitsToUse == Units.Imperial)
                return mostRecentMeasure;
            else
                return mostRecentMeasure * 0.03937m;
        }

        private void GetMeasurements()
        {
            dataCaptured = new int[10];

            ThreadPool.QueueUserWorkItem(_ =>
            {
                int x = 0;
                Random timer = new Random();

                while (controller != null)
                {
                    Thread.Sleep(timer.Next(1000, 5000));

                    if (controller == null) break;

                    dataCaptured[x] = controller.TakeMeasurement();
                    mostRecentMeasure = dataCaptured[x];

                    x++;
                    if (x >= 10)
                        x = 0;
                }
            });
        }
    }
}
