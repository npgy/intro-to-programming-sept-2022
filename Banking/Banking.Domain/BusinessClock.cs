namespace Banking.Domain;
public class BusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _clock;

    public BusinessClock(ISystemTime clock)
    {
        _clock = clock;
    }

    public bool DuringBusinessHours()
    {
        return _clock.GetCurrent().Hour >= 9 && _clock.GetCurrent().Hour <= 17;
    }
}


public interface ISystemTime
{
    DateTime GetCurrent();
}

public class SystemTime : ISystemTime
{
    public DateTime GetCurrent()
    {
        return DateTime.Now;
    }
}
