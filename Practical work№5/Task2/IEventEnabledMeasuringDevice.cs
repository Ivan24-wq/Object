namespace MeasuringDevice;

public interface IEventEnabledMeasuringDevice1
{
    event EventHandler NewMeasugementTaken;
    event HeartBeatEventHandler HeartBeat;
}
