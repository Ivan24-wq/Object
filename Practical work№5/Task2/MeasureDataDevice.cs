using System;
using System.Threading;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IMeasuringDevice
    {
        protected Units unitsToUse;
        protected int[] dataCaptured;
        protected int mostRecentMeasure;
        protected DeviceController controller;
        protected DeviceType measurementType;

        public MeasureDataDevice(Units units)
        {
            unitsToUse = units;
        }

        public abstract decimal MetricValue();
        public abstract decimal ImperialValue();

        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
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
            return dataCaptured;
        }

        protected void GetMeasurements()
        {
            dataCaptured = new int[10];

            ThreadPool.QueueUserWorkItem(_ =>
            {
                int i = 0;
                Random rand = new Random();

                while (true){
                    if (controller == null)
                        return;   // поток завершён

                    Thread.Sleep(rand.Next(500, 2000));

                    int newValue = controller?.TakeMeasurement() ?? 0;
                    dataCaptured[i] = newValue;
                    mostRecentMeasure = newValue;
                    i = (i + 1) % 10;
                }               

            });
        }
    }
}
