using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MeasuringDevice
{
    public abstract class MeasureDataDevice : IEventEnabledMeasuringDevice, IDisposable
    {
        protected Units unitsToUse;
        protected int[]? dataCaptured;
        protected int mostRecentMeasure;
        protected DeviceController? controller;
        protected DeviceType measurementType;

        protected int heartBeatIntervalTime;
        //Событие
        public event EventHandler? NewMeasugementTaken;
        public event HeartBeatEventHandler? HeartBeat;
        private BackgroundWorker? heartBeatTimer;

        //Свойство HeartBeatInterval
        public int HeartBeatInterval
        {
            get => heartBeatIntervalTime;
            private set => heartBeatIntervalTime = value;
        }

        //Приматный член
        private  BackgroundWorker? dataCollector;
        //Уничтожение объекта
        private bool disposed = false;

        //Метод проверки подписчиков
        protected virtual void OnNewMeasurementTaken()
        {
            NewMeasugementTaken?.Invoke(this, EventArgs.Empty);
        }

        //реализация интерфейса IDisposable
        public void Dispose()
        {
            disposed = true;
            if(controller != null)
            {
                controller.StopDevice();
                controller = null;
            }

            dataCollector?.Dispose();

            if(heartBeatTimer != null)
            {
                heartBeatTimer.Dispose();
                heartBeatTimer = null;
            }
        }

        //Метод OnHeartBeat
        protected virtual void OnHeartBeat()
        {
            HeartBeat?.Invoke(this, new HeartBeatEventArs());
        }

        //Метод StartHeartBeat
        public void StartHeartBeat()
        {
            heartBeatTimer = new BackgroundWorker();
            heartBeatTimer.WorkerSupportsCancellation = true;
            heartBeatTimer.WorkerReportsProgress = true;

            // DoWork — поток таймера HeartBeat
            heartBeatTimer.DoWork += (o, args) =>
            {
                while (true)
                {
                    Thread.Sleep(HeartBeatInterval);
                    if(disposed)
                        break;
                    heartBeatTimer.ReportProgress(0);
                }
            };

            //ReportProgress
            heartBeatTimer.ProgressChanged += (o, args) =>
            {
                OnHeartBeat();
            };

            heartBeatTimer.RunWorkerAsync();
        }

        public MeasureDataDevice(Units units)
        {
            unitsToUse = units;
            mostRecentMeasure = 0;
            dataCaptured = null;
            controller = null;
            dataCollector = null;
        }

        public abstract decimal MetricValue();
        public abstract decimal ImperialValue();

        public void StartCollecting()
        {
            controller = DeviceController.StartDevice(measurementType);
            GetMeasurements();
            StartHeartBeat();
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
            return dataCaptured?? Array.Empty<int>();
        }

        private void GetMeasurements()
        {
            
            //Создан объект
            dataCollector = new BackgroundWorker();
            // Отмена подписки
            dataCollector.WorkerSupportsCancellation = true;

            //Отчетыо прогрессе
            dataCollector.WorkerReportsProgress = true;

            //Подписка на событие
            dataCollector.DoWork += dataCollector_DoWork!;
            dataCollector.ProgressChanged += dataCollector_ProgressChanged!;
            //Запуск сборщика данных
            dataCollector.RunWorkerAsync();         
        }

        //Метод dataCollector_DoWork
        private void dataCollector_DoWork(object sender, DoWorkEventArgs e)
        {
            dataCaptured = new int[10];
            int i = 0;
            Random rnd = new Random();

            while (!dataCollector!.CancellationPending)
            {
                Thread.Sleep(rnd.Next(500, 2000));

                int newValue = controller?.TakeMeasurement() ?? 0;
                dataCaptured![i] = newValue;
                mostRecentMeasure = newValue;

                //Проверка на уничтожение
                if (disposed)
                {
                    break;
                }
                
                i = (i + 1) % dataCaptured.Length;

                dataCollector.ReportProgress(0); //Получили сигнал
            }
        }

        //Метод dataCollector_ProgressChanged
        private void dataCollector_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnNewMeasurementTaken();
        }
    }
}
