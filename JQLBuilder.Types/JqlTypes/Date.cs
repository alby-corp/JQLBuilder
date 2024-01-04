namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class DateField : JqlValue, IJqlField<DateExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DateField left, DateExpression right) => left.Equal(right);

    public static Bool operator !=(DateField left, DateExpression right) => left.NotEqual(right);

    public static Bool operator >(DateField left, DateExpression right) => left.GreaterThan(right);

    public static Bool operator >=(DateField left, DateExpression right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(DateField left, DateExpression right) => left.LessThan(right);

    public static Bool operator <=(DateField left, DateExpression right) => left.LessThanOrEqual(right);

    public static Bool operator ==(DateExpression left, DateField right) => right.Equal(left);

    public static Bool operator !=(DateExpression left, DateField right) => right.NotEqual(left);

    public static Bool operator >(DateExpression left, DateField right) => right.GreaterThan(left);

    public static Bool operator >=(DateExpression left, DateField right) => right.GreaterThanOrEqual(left);

    public static Bool operator <(DateExpression left, DateField right) => right.LessThan(left);

    public static Bool operator <=(DateExpression left, DateField right) => right.LessThanOrEqual(left);
}

public class DateExpression : JqlDate.Only, IJqlMembership<DateExpression>
{
    public static implicit operator DateExpression(string value) => new() { Value = Init(value) };

    public static implicit operator DateExpression(DateTime value) => new() { Value = value };

    static DateTime Init(string value)
    {
        var result = DateTime.TryParse(value, out var datetime);

        if (!result) throw new ArgumentException("Invalid date format");

        return datetime;
    }
}