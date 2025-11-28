namespace MeasuringDevice;

public class DeviceController
{
    private Random rnd = new Random();

    // эмуляция запуска
    public static DeviceController StartDevice(DeviceType type)
    {
        return new DeviceController();
    }

    //Эмуляция останвки
    public void StopDevice()
    {
        
    }

    //Проведение измерений
    public int TakeMeasurement()
    {
        return rnd.Next(0, 100);
    }
}