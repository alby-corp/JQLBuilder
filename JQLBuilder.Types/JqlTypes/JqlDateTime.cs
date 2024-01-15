namespace JQLBuilder.Types.JqlTypes;

using System.Text.RegularExpressions;
using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;
using DateOnly = System.DateOnly;
using DateTime = System.DateTime;

#pragma warning disable CS0660, CS0661
public class DateTimeField : JqlValue, IJqlField<DateTimeExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DateTimeField left, DateTimeExpression right) => left.Equal(right);

    public static Bool operator !=(DateTimeField left, DateTimeExpression right) => left.NotEqual(right);

    public static Bool operator >(DateTimeField left, DateTimeExpression right) => left.GreaterThan(right);

    public static Bool operator >=(DateTimeField left, DateTimeExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(DateTimeField left, DateTimeExpression right) => left.LessThan(right);

    public static Bool operator <=(DateTimeField left, DateTimeExpression right) => left.LessThanOrEqual(right);

    public static Bool operator ==(DateTimeExpression left, DateTimeField right) => right.Equal(left);

    public static Bool operator !=(DateTimeExpression left, DateTimeField right) => right.NotEqual(left);

    public static Bool operator >(DateTimeExpression left, DateTimeField right) => right.GreaterThan(left);

    public static Bool operator >=(DateTimeExpression left, DateTimeField right) => right.GreaterThanOrEqual(left);

    public static Bool operator <(DateTimeExpression left, DateTimeField right) => right.LessThan(left);

    public static Bool operator <=(DateTimeExpression left, DateTimeField right) => right.LessThanOrEqual(left);
}

public class DateTimeExpression : JqlValue, IJqlMembership<DateTimeExpression>
{
    public static implicit operator DateTimeExpression(string value) => new() { Value = Init(value) };

    public static implicit operator DateTimeExpression(DateTime value) => new() { Value = value };

    public static implicit operator DateTimeExpression(TimeSpan value) => new() { Value = DateTime.Now.Add(value) };
    
    static readonly Dictionary<char, TimeSpan> DurationMap = new()
    {
        { 'w', TimeSpan.FromDays(7) },
        { 'd', TimeSpan.FromDays(1) },
        { 'h', TimeSpan.FromHours(1) },
        { 'm', TimeSpan.FromMinutes(1) }
    };

    protected static object Init(string value)
    {
        var isDateTime = DateTime.TryParse(value, out var datetime);

        if (isDateTime)
        {
            return datetime.Date == datetime ? DateOnly.FromDateTime(datetime) : datetime;
        }

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
}
