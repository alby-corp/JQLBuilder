namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class DurationField : JqlValue, IJqlField<JqlDuration>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(DurationField left, JqlDuration right) => left.Equal(right);
    public static Bool operator !=(DurationField left, JqlDuration right) => left.NotEqual(right);
    public static Bool operator >(DurationField left, JqlDuration right) => left.GreaterThan(right);
    public static Bool operator >=(DurationField left, JqlDuration right) => left.GreaterThanOrEqual(right);
    public static Bool operator <(DurationField left, JqlDuration right) => left.LessThan(right);
    public static Bool operator <=(DurationField left, JqlDuration right) => left.LessThanOrEqual(right);
    public static Bool operator ==(JqlDuration left, DurationField right) => right.Equal(left);
    public static Bool operator !=(JqlDuration left, DurationField right) => right.NotEqual(left);
    public static Bool operator >(JqlDuration left, DurationField right) => right.LessThan(left);
    public static Bool operator >=(JqlDuration left, DurationField right) => right.LessThanOrEqual(left);
    public static Bool operator <(JqlDuration left, DurationField right) => right.GreaterThan(left);
    public static Bool operator <=(JqlDuration left, DurationField right) => right.GreaterThanOrEqual(left);
}

public class JqlDuration : JqlDateTime, IJqlMembership<JqlDuration>
{
    public static implicit operator JqlDuration(string value) => new() { Value = ParsePositiveDuration(value) };
    public static implicit operator JqlDuration(TimeSpan value) => new() { Value = ParsePositiveDuration($"{value.TotalMinutes}") };
}