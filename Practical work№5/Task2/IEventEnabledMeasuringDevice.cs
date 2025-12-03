namespace MeasuringDevice;

public interface IEventEnabledMeasuringDevice
{
    event EventHandler NewMeasugementTaken;
    event HeartBeatEventHandler HeartBeat;
}
