namespace AlbyCorp.JQLBuilder.Types.Primitive;

using Abstract;
using Enum;

public class BinaryOperator(IJqlType left, string name, IJqlType right, Priority priority) : Bool
{
    public IJqlType Left { get; } = left;
    public string Name { get; } = name;
    public IJqlType Right { get; } = right;

    public Priority Priority { get; } = priority;
}