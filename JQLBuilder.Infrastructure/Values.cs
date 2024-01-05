namespace JQLBuilder.Infrastructure;

using System.Text.RegularExpressions;
using Abstract;

public class JqlValue : IJqlType
{
    internal object Value { get; init; } = null!;
}

public class JqlDate : JqlValue
{
    static readonly Dictionary<char, TimeSpan> DurationMap = new()
    {
        { 'w', TimeSpan.FromDays(7) },
        { 'd', TimeSpan.FromDays(1) },
        { 'h', TimeSpan.FromHours(1) },
        { 'm', TimeSpan.FromMinutes(1) }
    };

    protected static DateTime Init(string value)
    {
        var isDateTime = DateTime.TryParse(value, out var datetime);

        if (isDateTime) return datetime;

        var isTimeSpan = ParseJqlDuration(value);

        if (isTimeSpan.HasValue) return DateTime.Now.Add(isTimeSpan.Value);

        throw new ArgumentException("Invalid date format");
    }

    static TimeSpan? ParseJqlDuration(string duration)
    {
        var split = duration.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var totalDuration = TimeSpan.Zero;

        foreach (var s in split)
        {
            var match = Regex.Match(s, @"^(\d+)([wdhm]?)$");

            if (!match.Success) return default;

            var value = int.Parse(match.Groups[1].Value);

            var unitValue = match.Groups[2].Value;
            var unit = unitValue.Length == 0 ? 'm' : unitValue[0];

            if (DurationMap.TryGetValue(unit, out var value1)) totalDuration += value1 * value;
        }

        return totalDuration;
    }

    public class Only : JqlDate;

    public class Time : JqlDate;
}