public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        if (schedule == Schedule.Last)
        {
            var date = new DateTime(_year, _month, DateTime.DaysInMonth(_year, _month));
            while (date.DayOfWeek != dayOfWeek)
                date = date.AddDays(-1);
            return date;
        }

        int startDay = schedule switch
        {
            Schedule.Teenth => 13,
            Schedule.First => 1,
            Schedule.Second => 8,
            Schedule.Third => 15,
            Schedule.Fourth => 22,
            _ => throw new ArgumentOutOfRangeException(nameof(schedule))
        };

        var current = new DateTime(_year, _month, startDay);
        while (current.DayOfWeek != dayOfWeek)
            current = current.AddDays(1);

        return current;
    }
}