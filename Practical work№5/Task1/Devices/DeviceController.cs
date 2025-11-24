namespace DeviceController
{
    public class DeviceController
    {
        private Random random = new Random();

        public static DeviceController StartDevice(DeviceType type)
        {
            return new DeviceController();
        }

        public int TakeMeasurement()
        {
            return random.Next(1, 100); // Эмуляция измерения
        }

        public void StopDevice()
        {
        }
    }
}
