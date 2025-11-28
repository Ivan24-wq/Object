namespace MeasuringDevice
{
    public class MeasureMassDevice : MeasureDataDevice
    {
        public MeasureMassDevice(Units units) : base(units)
        {
            measurementType = DeviceType.MASS;
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
