namespace JQLBuilder.Types.Custom;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class DateTimeField : JqlValue, IJqlField<DateTimeExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    internal override object? Value { get; init; }

    public static Bool operator ==(DateTimeField left, DateTimeExpression right) => left.Equal(right);

    public static Bool operator !=(DateTimeField left, DateTimeExpression right) => left.NotEqual(right);

    public static Bool operator >(DateTimeField left, DateTimeExpression right) => left.LessThan(right);

    public static Bool operator >=(DateTimeField left, DateTimeExpression right) => left.LessThanOrEqual(right);

    public static Bool operator <(DateTimeField left, DateTimeExpression right) => left.GreaterThan(right);

    public static Bool operator <=(DateTimeField left, DateTimeExpression right) => left.GreaterThanOrEqual(right);

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
    
    static DateTime Init(string value)
    {
        var result = DateTime.TryParse(value, out var datetime);

        if (!result) throw new ArgumentException("Invalid date format");

        return datetime;
    }
}