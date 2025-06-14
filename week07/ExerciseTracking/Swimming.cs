public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * 50 / 1000) * 0.62; // Convert meters to miles
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60; // Use accessor
    public override double GetPace() => GetMinutes() / GetDistance(); // Use accessor
}