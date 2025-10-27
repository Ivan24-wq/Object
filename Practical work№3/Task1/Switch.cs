namespace Task1;

public enum CoolantSystemStatus { OK, Check, Fail }

public enum SuccessFailureResult { Success, Fail }

public class Switch
{
    private Random rand = new Random();

    // Отключение от внешней системы генерации электроэнергии
    public SuccessFailureResult DisconnectPowerGenerator()
    {
        SuccessFailureResult r = SuccessFailureResult.Fail;

        if (rand.Next(1, 10) > 2)
            r = SuccessFailureResult.Success;

        if (rand.Next(1, 20) > 18)
            throw new PowerGeneratorCommsException("Сбой сети при доступе к системе мониторинга генератора");

        return r;
    }

    // Проверка основной системы охлаждения
    public CoolantSystemStatus VerifyPrimaryCoolantSystem()
    {
        CoolantSystemStatus c = CoolantSystemStatus.Fail;
        int r = rand.Next(1, 10);

        if (r > 5)
        {
            c = CoolantSystemStatus.OK;
        }
        else if (r > 2)
        {
            c = CoolantSystemStatus.Check;
        }

        if (rand.Next(1, 20) > 18)
            throw new CoolantTemperatureReadException("Ошибка при чтении температуры основной системы охлаждения");

        if (rand.Next(1, 20) > 18)
            throw new CoolantPressureReadException("Ошибка при чтении давления основной системы охлаждения");

        return c;
    }

    // Проверка резервной системы охлаждения
    public CoolantSystemStatus VerifyBackupCoolantSystem()
    {
        CoolantSystemStatus c = CoolantSystemStatus.Fail;
        int r = rand.Next(1, 10);

        if (r > 5)
        {
            c = CoolantSystemStatus.OK;
        }
        else if (r > 2)
        {
            c = CoolantSystemStatus.Check;
        }

        if (rand.Next(1, 20) > 19)
            throw new CoolantTemperatureReadException("Ошибка при чтении температуры резервной системы охлаждения");

        if (rand.Next(1, 20) > 19)
            throw new CoolantPressureReadException("Ошибка при чтении давления резервной системы охлаждения");

        return c;
    }

    // Получение температуры реакторного ядра
    public double GetCoreTemperature()
    {
        if (rand.Next(1, 20) > 18)
            throw new CoreTemperatureReadException("Ошибка при чтении температуры реакторного ядра");

        return rand.NextDouble() * 1000;
    }

    // Вставка стержней для остановки реакции
    public SuccessFailureResult InsertRodCluster()
    {
        SuccessFailureResult r = SuccessFailureResult.Fail;

        if (rand.Next(1, 100) > 5)
            r = SuccessFailureResult.Success;

        if (rand.Next(1, 10) > 8)
            throw new RodClusterReleaseException("Сбой сенсора: невозможно подтвердить выпуск стержней");

        return r;
    }

    // Получение уровня радиации реакторного ядра
    public double GetRadiationLevel()
    {
        if (rand.Next(1, 20) > 18)
            throw new CoreRadiationLevelReadException("Ошибка при чтении уровня радиации реакторного ядра");

        return rand.NextDouble() * 500;
    }

    // Отправка сообщения о завершении останова реактора
    public void SignalShutdownComplete()
    {
        if (rand.Next(1, 20) > 18)
            throw new SignallingException("Сбой сети при подключении к системе оповещения");
    }
}

// ---------------- Исключения ----------------

public class PowerGeneratorCommsException : Exception
{
    public PowerGeneratorCommsException(string message) : base(message) { }
}

public class CoolantSystemException : Exception
{
    public CoolantSystemException(string message) : base(message) { }
}

public class CoolantTemperatureReadException : CoolantSystemException
{
    public CoolantTemperatureReadException(string message) : base(message) { }
}

public class CoolantPressureReadException : CoolantSystemException
{
    public CoolantPressureReadException(string message) : base(message) { }
}

public class CoreTemperatureReadException : Exception
{
    public CoreTemperatureReadException(string message) : base(message) { }
}

public class CoreRadiationLevelReadException : Exception
{
    public CoreRadiationLevelReadException(string message) : base(message) { }
}

public class RodClusterReleaseException : Exception
{
    public RodClusterReleaseException(string message) : base(message) { }
}

public class SignallingException : Exception
{
    public SignallingException(string message) : base(message) { }
}