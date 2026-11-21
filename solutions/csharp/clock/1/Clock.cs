public class Clock : IEquatable<Clock>
{
    private const int MinutesPerDay = 24 * 60;

    private readonly int _totalMinutes;

    public Clock(int hours, int minutes)
    {
        // long, щоб уникнути переповнення при великих значеннях
        long total = (long)hours * 60 + minutes;
        _totalMinutes = Normalize(total);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, _totalMinutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(0, _totalMinutes - minutesToSubtract);
    }

    public bool Equals(Clock other)
    {
        return other is not null && _totalMinutes == other._totalMinutes;
    }

    public override bool Equals(object obj) => Equals(obj as Clock);

    public override int GetHashCode() => _totalMinutes.GetHashCode();

    public override string ToString()
    {
        return $"{_totalMinutes / 60:D2}:{_totalMinutes % 60:D2}";
    }

    private static int Normalize(long totalMinutes)
    {
        long result = totalMinutes % MinutesPerDay;
        if (result < 0)
            result += MinutesPerDay;
        return (int)result;
    }
}