namespace AlbyCorp.JQLBuilder.Types;

// TODO: Sposta in un posto decente le extensions methods

using Enums;

public static class JqlType
{
    public record Field(string Value) : IJqlType;

    public class Collection<T>(object values) : JqlValue(values), IJqlType.ICollection<T> where T : IJqlType;

    public class Operator(IJqlType left, string name, IJqlType right, Priority priority) : Bool
    {
        public Priority Priority { get; } = priority;
        public IJqlType Left { get; } = left;
        public string Name { get; } = name;
        public IJqlType Right { get; } = right;
    }
    
    public static Operator Equals(IJqlType left, IJqlType right) => new Operator(left, "=", right, Priority.Equality);
    public static Operator NotEquals(IJqlType left, IJqlType right) => new Operator(left, "!=", right, Priority.Equality);
    
    public static Operator GreaterThan(IJqlType left, IJqlType right) => new Operator(left, ">", right, Priority.Relation);
    public static Operator GreaterThanOrEqual(IJqlType left, IJqlType right) => new Operator(left, ">=", right, Priority.Relation);
    
    public static Operator LessThan(IJqlType left, IJqlType right) => new Operator(left, "<", right, Priority.Relation);
    public static Operator LessThanOrEqual(IJqlType left, IJqlType right) => new Operator(left, "<=", right, Priority.Relation);
    
    public static Operator And(IJqlType left, IJqlType right) => new Operator(left, "and", right, Priority.LogicalAnd);
    public static Operator Or(IJqlType left, IJqlType right) => new Operator(left, "or", right, Priority.LogicalOr);
    
    public static Bool In<T>(this T value, IJqlType.ICollection<T> collection) where T : IJqlType.IEquatable<T> =>
        new Operator(value, "in", collection, Priority.Powerful);

    public static Bool In<T>(this T value, params T[] collection) where T : class, IJqlType.IEquatable<T> =>
        new Operator(value, "in", new Collection<T>(collection), Priority.Powerful);

    public static Bool NotIn<T>(this T value, IJqlType.ICollection<T> collection) where T : IJqlType.IEquatable<T> =>
        new Operator(value, "not in", collection, Priority.Powerful);

    public static Bool NotIn<T>(this T value, params T[] collection) where T : class, IJqlType.IEquatable<T> =>
        new Operator(value, "not in", new Collection<T>(collection), Priority.Powerful);
}