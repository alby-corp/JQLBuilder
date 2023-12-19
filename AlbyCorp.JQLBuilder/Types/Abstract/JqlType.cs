namespace AlbyCorp.JQLBuilder.Types.Abstract;

using Types;

internal static class JqlType
{
    public record Field(string Value) : IJqlType;

    public class Collection<T>(object values) : JqlValue(values), IJqlType.ICollection<T> where T : IJqlType;

    public class Operator(IJqlType left, string name, IJqlType right) : Bool(default)
    {
        public IJqlType Left { get; } = left;
        public string Name { get; } = name;
        public IJqlType Right { get; } = right;
    }
    
    public static Operator Equals(IJqlType left, IJqlType right) => new Operator(left, "=", right);
    public static Operator NotEquals(IJqlType left, IJqlType right) => new Operator(left, "!=", right);
    
    public static Operator GreaterThan(IJqlType left, IJqlType right) => new Operator(left, ">", right);
    public static Operator GreaterThanOrEqual(IJqlType left, IJqlType right) => new Operator(left, ">=", right);
    
    public static Operator LessThan(IJqlType left, IJqlType right) => new Operator(left, "<", right);
    public static Operator LessThanOrEqual(IJqlType left, IJqlType right) => new Operator(left, "<=", right);
    
    public static Operator And(IJqlType left, IJqlType right) => new Operator(left, "and", right);
    public static Operator Or(IJqlType left, IJqlType right) => new Operator(left, "or", right);
}