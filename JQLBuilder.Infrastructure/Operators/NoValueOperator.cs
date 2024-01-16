namespace JQLBuilder.Infrastructure.Operators;

using Abstract;

public class NoValueOperator(IJqlType field, string name, IJqlType value) : Bool
{
    public IJqlType Field { get; } = field;
    public string Name { get; } = name;
    public IJqlType Value { get; } = value;
}