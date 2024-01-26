namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;
using DateOnly = System.DateOnly;
using DateTime = System.DateTime;

#pragma warning disable CS0660, CS0661
public class DateTimeField : JqlValue, IJqlField<JqlDateTime>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DateTimeField left, JqlDateTime right) => left.Equal(right);

    public static Bool operator !=(DateTimeField left, JqlDateTime right) => left.NotEqual(right);
    public static Bool operator >(DateTimeField left, JqlDateTime right) => left.GreaterThan(right);
    public static Bool operator >=(DateTimeField left, JqlDateTime right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(DateTimeField left, JqlDateTime right) => left.LessThan(right);
    public static Bool operator <=(DateTimeField left, JqlDateTime right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlDateTime left, DateTimeField right) => right.Equal(left);
    public static Bool operator !=(JqlDateTime left, DateTimeField right) => right.NotEqual(left);
    public static Bool operator >(JqlDateTime left, DateTimeField right) => right.LessThan(left);
    public static Bool operator >=(JqlDateTime left, DateTimeField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlDateTime left, DateTimeField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlDateTime left, DateTimeField right) => right.GreaterThanOrEqual(left);
}

public class JqlDateTime : JqlValue, IJqlMembership<JqlDateTime>
{
    public static implicit operator JqlDateTime(string value) => new() { Value = ParseDateTime(value) };

    public static implicit operator JqlDateTime(DateTime value) => new() { Value = value };
}