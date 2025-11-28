namespace MeasuringDevice;

public interface IMeasuringDevice
{
    void StartCollecting();
    void StopCollecting();
    int[] GetRawData();
    decimal MetricValue();
    decimal ImperialValue();
}