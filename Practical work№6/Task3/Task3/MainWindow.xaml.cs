using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Task3
{
    public partial class MainWindow : Window
    {
        Thread[] workers;          // потоки
        Barrier barrier;           // синхронизация шагов
        volatile bool stop = false;

        double angle = 0;          // общий угол колеса
        object angleLock = new object();

        DispatcherTimer stateTimer;

        public MainWindow()
        {
            InitializeComponent();

            stateTimer = new DispatcherTimer();
            stateTimer.Interval = TimeSpan.FromMilliseconds(500);
            stateTimer.Tick += StateTimer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartThreads();
            stateTimer.Start();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            StopThreads();
        }


        //   СТАРТ ПОТОКОВ

        void StartThreads()
        {
            stop = false;

            int n = 3; // три потока
            workers = new Thread[n];

            barrier = new Barrier(n, (b) =>
            {
                // после того, как ВСЕ потоки дошли до барьера — обновляем UI
                double a;
                lock (angleLock) a = angle;

                Dispatcher.Invoke(() =>
                {
                    WhellRotate.Angle = a;
                });
            });

            for (int i = 0; i < n; i++)
            {
                int id = i;

                workers[i] = new Thread(() => Worker(id))
                {
                    IsBackground = true
                };

                // Разные приоритеты
                workers[i].Priority = id switch
                {
                    0 => ThreadPriority.Highest,
                    1 => ThreadPriority.AboveNormal,
                    _ => ThreadPriority.Normal
                };

                workers[i].Start();
            }
        }


        //   ПОТОКОВАЯ ЛОГИКА

        void Worker(int id)
        {
            Random rnd = new Random(id * 1000);

            while (!stop)
            {
                // каждый поток вносит свой вклад в угол
                lock (angleLock)
                {
                    angle += 2 + id;  // поток 0 → +2°, поток 1 → +3°, поток 2 → +4° ...
                    if (angle >= 360) angle -= 360;
                }

                // синхронизация всех потоков
                try
                {
                    barrier.SignalAndWait();
                }
                catch { return; }

                Thread.Sleep(40 + id * 20); // создаём разную скорость потоков
            }
        }

       
        //   ОСТАНОВКА ПОТОКОВ
    
        void StopThreads()
        {
            stop = true;

            if (workers != null)
            {
                foreach (var t in workers)
                    if (t != null && t.IsAlive)
                        t.Join();
            }

            barrier?.Dispose();
        }

        
        //   ПРОСМОТР СОСТОЯНИЙ ПОТОКОВ
        
        void StateTimer_Tick(object sender, EventArgs e)
        {
            Console.Clear();

            for (int i = 0; i < workers.Length; i++)
            {
                var t = workers[i];
                Console.WriteLine(
                    $"Thread {i} | Priority: {t.Priority} | State: {t.ThreadState}"
                );
            }
        }
    }
}
