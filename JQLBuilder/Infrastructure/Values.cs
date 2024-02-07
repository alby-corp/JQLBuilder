namespace JQLBuilder.Infrastructure;

using System.Globalization;
using System.Text.RegularExpressions;
using Abstract;

public class JqlValue : IJqlType
{
    internal object Value { get; init; } = null!;

    internal static object ParseDateTime(string value)
        => TryParseDateTime(value) ??
           throw new ArgumentException($"Date time value '{value}' is invalid. The accepted formats are: \"yyyy-MM-dd\", \"yyyy/MM/dd\", \"yyyy-MM-dd HH:mm\", \"yyyy/MM/dd HH:mm\" or a relative date format '(+/-)n(wdhm)', eg. '1w -2d 3h +4m'");

    internal static object ParseDate(string value)
        => TryParseDateOnly(value) ??
           throw new ArgumentException($"Date value '{value}' is invalid. The accepted formats are: \"yyyy-MM-dd\", \"yyyy/MM/dd\" or a relative date format '(+/-)n(wdhm)', eg. '1w -2d 3h +4m'");

    internal static object ParseRelativeDate(string value)
        => TryParseRelativeDate(value) ??
           throw new ArgumentException($"Relative date value '{value}' is invalid. The accepted format is '(+/-)n(wdhm)', eg. '1w -2d 3h +4m'");

    internal static object ParseDuration(string value)
        => TryParseDuration(value) ??
           throw new ArgumentException($"Duration value '{value}' is invalid. The accepted format is '(+/-)n(yMwdhm)', eg. '-1M'");

    internal static object ParsePositiveDuration(string value)
    {
        const string errorMessage = "Duration value '{0}' is invalid. The accepted format is 'n(wdhm)', eg. '1h 30m'";
    
        if (value.IndexOfAny(['+', '-']) >= 0) throw new ArgumentException(string.Format(errorMessage, value));
    
        return TryParseRelativeDate(value) ?? throw new ArgumentException(string.Format(errorMessage, value));
    }

    static object? TryParseDateTime(string value)
    {
        if (TryParseDateOnly(value) is { } dateTime)
            return dateTime;

        string[] formats = ["yyyy-MM-dd HH:mm", "yyyy/MM/dd HH:mm"];
        if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var result)) return result;

        return null;
    }

    static object? TryParseDateOnly(string value)
    {
        if (TryParseRelativeDate(value) is { } dateTime)
            return dateTime;

        string[] formats = ["yyyy-MM-dd", "yyyy/MM/dd"];
        if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var datetime)) return DateOnly.FromDateTime(datetime);

        return null;
    }

    static object? TryParseRelativeDate(string value) => TryParseTimeOffset(value, ['w', 'd', 'h', 'm'], null);
    static object? TryParseDuration(string value) => TryParseTimeOffset(value, ['y', 'M', 'w', 'd', 'h', 'm'], 1);

    static TimeOffset? TryParseTimeOffset(string value, HashSet<char> allowedIntervals, int? maxIntervals)
    {
        var split = value.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        if (split.Length == 0 || split.Length > maxIntervals)
            return null;

        var years = 0;
        var months = 0;
        var weeks = 0;
        var days = 0;
        var hours = 0;
        var minutes = 0;

        foreach (var s in split)
        {
            var match = Regex.Match(s, @"^([+-]?\d+)([yMwdhm]?)$");

            if (!match.Success)
                return null;

            var amount = int.Parse(match.Groups[1].Value);
            var interval = match.Groups[2].Value is [var first] ? first : 'm';

            if (!allowedIntervals.Contains(interval))
                return null;

            switch (interval)
            {
                case 'y':
                    years += amount;
                    break;
                case 'M':
                    months += amount;
                    break;
                case 'w':
                    weeks += amount;
                    break;
                case 'd':
                    days += amount;
                    break;
                case 'h':
                    hours += amount;
                    break;
                case 'm':
                    minutes += amount;
                    break;
            }
        }

        return new(years, months, weeks, days, hours, minutes);
    }
}

public record Issue(string Key);