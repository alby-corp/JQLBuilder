namespace JQLBuilder.Types.Custom;

using Abstract;
using Support;
using Primitive;

#pragma warning disable CS0660, CS0661
public class Date: JqlValue, IJqlMembership<Date>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    internal override object? Value { get; init; }
    
    public static implicit operator Date(string value) => new() { Value = Init(value) };
    public static implicit operator Date(DateTime value) => new() { Value = value };

    public static Bool operator ==(Date left, Date right) => left.Equal(right);
    public static Bool operator !=(Date left, Date right) => left.NotEqual(right);

    public static Bool operator >(Date left, Date right) => left.GreaterThan(right);
    public static Bool operator >=(Date left, Date right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(Date left, Date right) => left.LessThan(right);
    public static Bool operator <=(Date left, Date right) => left.LessThanOrEqual(right);

    static DateTime Init(string value)
    {
        var result = DateTime.TryParse(value, out var datetime);
        
        if(!result) throw new ArgumentException("Invalid date format");

        return datetime ;
    }
}