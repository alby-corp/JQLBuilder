namespace JQLBuilder.Infrastructure;

public record TimeOffset(int Years, int Months, int Weeks, int Days, int Hours, int Minutes)
{
    public static object FromTimeSpan(TimeSpan value)
        => new TimeOffset(0, 0, 0, value.Days, value.Hours, value.Minutes);
}