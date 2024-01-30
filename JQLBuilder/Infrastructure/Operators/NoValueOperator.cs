namespace JQLBuilder.Infrastructure.Operators;

using Abstract;

public record NoValueOperator(IJqlType Field, string Name, IJqlType Value) : Bool;
