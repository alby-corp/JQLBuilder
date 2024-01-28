namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using DateOnly = System.DateOnly;

#pragma warning disable CS0660, CS0661
public class DateField : JqlValue, IJqlField<JqlJqlDate>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DateField left, JqlJqlDate right) => left.Equal(right);
    public static Bool operator !=(DateField left, JqlJqlDate right) => left.NotEqual(right);
    public static Bool operator >(DateField left, JqlJqlDate right) => left.GreaterThan(right);
    public static Bool operator >=(DateField left, JqlJqlDate right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(DateField left, JqlJqlDate right) => left.LessThan(right);
    public static Bool operator <=(DateField left, JqlJqlDate right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlJqlDate left, DateField right) => right.Equal(left);
    public static Bool operator !=(JqlJqlDate left, DateField right) => right.NotEqual(left);
    public static Bool operator >(JqlJqlDate left, DateField right) => right.LessThan(left);
    public static Bool operator >=(JqlJqlDate left, DateField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlJqlDate left, DateField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlJqlDate left, DateField right) => right.GreaterThanOrEqual(left);
}

public class JqlJqlDate : JqlDateTime, IJqlMembership<JqlJqlDate>
{
    public static implicit operator JqlJqlDate(string value) => new() { Value = ParseDate(value) };
    public static implicit operator JqlJqlDate(DateOnly value) => new() { Value = value };
}