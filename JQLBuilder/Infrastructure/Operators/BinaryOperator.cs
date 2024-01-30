namespace JQLBuilder.Infrastructure.Operators;

using Abstract;
using Enum;

public record BinaryOperator(IJqlType Left, string Name, IJqlType Right, Priority Priority) : Bool;
