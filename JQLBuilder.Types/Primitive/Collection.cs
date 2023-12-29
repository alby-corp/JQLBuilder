namespace JQLBuilder.Types.Primitive;

using Abstract;

public class JqlCollection<T> : JqlValue, IJqlCollection<T> where T : IJqlType
{
    public static implicit operator JqlCollection<T>(JqlCollection<Base.BuildIn> collection) => new() { Value = collection.Value };
}