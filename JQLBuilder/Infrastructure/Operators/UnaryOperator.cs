namespace JQLBuilder.Infrastructure.Operators;

using Abstract;
using Enum;

public record class UnaryOperator(string Name, IJqlType Value, Direction Direction) : Bool;
