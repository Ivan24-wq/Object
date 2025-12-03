namespace MeasuringDevice
{
    public class MeasureMassDevice : MeasureDataDevice, IMeasuringDevice, IEventEnabledMeasuringDevice
    {
        public MeasureMassDevice(Units units, int heartBeatInterval) : base(units)
        {
            measurementType = DeviceType.MASS;
            this.heartBeatIntervalTime = heartBeatInterval;
        }

        //второй конструктор
        public MeasureMassDevice(Units deviceUnits, string logFileName)
            : this(deviceUnits, 1000) // вызываем главный, heartbeat = 1000 мс
        {
            
        }

        public override decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : mostRecentMeasure * 0.4536m; // lbs → kg
        }

        public override decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : mostRecentMeasure * 2.2046m; // kg → lbs
        }
    }
}
