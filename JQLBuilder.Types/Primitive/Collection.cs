namespace JQLBuilder.Types.Primitive;

using Abstract;

public class JqlCollection<T> : JqlValue, IJqlCollection<T> where T : IJqlType;

public static class CollectionExtensions
{
    public static IJqlCollection<T> ToJqlCollection<T>(this IEnumerable<T> collection) where T : IJqlType
        => new JqlCollection<T> { Value = collection };
}