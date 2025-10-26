namespace Task1;

public class Switch
{
    public enum CoolantSystemStatus { OK, Check, Fail }
    public enum SuccessFailureResult { Success, Fail }

    public class Switch
    {
        private Random rand = new Random();

        public SuccessFailureResult DisconnectPowerGenerator()
        {
            SuccessFailureResult r = SuccessFailureResult.Fail;
            if (rand.Next(1, 10) > 2) r = SuccessFailureResult.Success;
            if (rand.Next(1, 20) > 18) throw new
PowerGeneratorCommsException("Network failure accessing Power Generator monitoringsystem");
            return r;
        }
    }
}
