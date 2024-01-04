namespace JQLBuilder.Types.Primitive;

using System.Collections;
using Abstract;

public sealed class JqlCollection<T> : JqlValue, IJqlCollection<T>, IEnumerable<T> where T : IJqlType
{
    public JqlCollection() => Value = new List<T>();

    public void Add(T item) => ((List<T>)Value).Add(item);
    
    public IEnumerator<T> GetEnumerator() => ((List<T>)Value).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}