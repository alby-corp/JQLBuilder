namespace JQLBuilder.Infrastructure.Operators;

using Abstract;
using Enum;

public class UnaryOperator(string name, IJqlType value, Direction direction) : Bool
{
    public string Name { get; } = name;
    public IJqlType Value { get; } = value;
    public Direction Direction { get; } = direction;
}