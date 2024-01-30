namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using DateOnly = System.DateOnly;

#pragma warning disable CS0660, CS0661
public class DateField : JqlValue, IJqlField<JqlDate>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DateField left, JqlDate right) => left.Equal(right);
    public static Bool operator !=(DateField left, JqlDate right) => left.NotEqual(right);
    public static Bool operator >(DateField left, JqlDate right) => left.GreaterThan(right);
    public static Bool operator >=(DateField left, JqlDate right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(DateField left, JqlDate right) => left.LessThan(right);
    public static Bool operator <=(DateField left, JqlDate right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlDate left, DateField right) => right.Equal(left);
    public static Bool operator !=(JqlDate left, DateField right) => right.NotEqual(left);
    public static Bool operator >(JqlDate left, DateField right) => right.LessThan(left);
    public static Bool operator >=(JqlDate left, DateField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlDate left, DateField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlDate left, DateField right) => right.GreaterThanOrEqual(left);
}

public class JqlDate : JqlDateTime, IJqlMembership<JqlDate>
{
    public static implicit operator JqlDate(string value) => new() { Value = ParseDate(value) };
    public static implicit operator JqlDate(DateOnly value) => new() { Value = value };
}