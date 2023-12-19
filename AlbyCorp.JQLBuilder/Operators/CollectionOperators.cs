namespace AlbyCorp.JQLBuilder.Operators;

using Types;
using Types.Abstract;

public static class CollectionOperators
{
    public static Bool In<T>(this T value, IJqlType.ICollection<T> collection) where T : IJqlType.IEquatable<T> =>
        new JqlType.Operator(value, "in", collection);

    public static Bool In<T>(this T value, params T[] collection) where T : class, IJqlType.IEquatable<T> =>
        new JqlType.Operator(value, "in", new JqlType.Collection<T>(collection));

    public static Bool NotIn<T>(this T value, IJqlType.ICollection<T> collection) where T : IJqlType.IEquatable<T> =>
        new JqlType.Operator(value, "not in", collection);

    public static Bool NotIn<T>(this T value, params T[] collection) where T : class, IJqlType.IEquatable<T> =>
        new JqlType.Operator(value, "not in", new JqlType.Collection<T>(collection));
}