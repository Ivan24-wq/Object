namespace MeasuringDevice
{
    public class MeasureLengthDevice : MeasureDataDevice
    {
        public MeasureLengthDevice(Units units) : base(units)
        {
            measurementType = DeviceType.LENGTH;
        }

        public override decimal MetricValue()
        {
            return unitsToUse == Units.Metric
                ? mostRecentMeasure
                : mostRecentMeasure * 0.3048m; 
        }

        public override decimal ImperialValue()
        {
            return unitsToUse == Units.Imperial
                ? mostRecentMeasure
                : mostRecentMeasure * 3.28084m; 
        }
    }
}
