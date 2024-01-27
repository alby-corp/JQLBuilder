namespace JQLBuilder.Infrastructure;

using System.Collections;
using Abstract;

public sealed class JqlCollection<T> : JqlValue, IJqlCollection<T>, IEnumerable<T> where T : IJqlType
{
    public JqlCollection(IReadOnlyList<T> items) => Value = new List<T>(items);

    public JqlCollection() => Value = new List<T>();

    public IEnumerator<T> GetEnumerator() => ((List<T>)Value).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(T item) => ((List<T>)Value).Add(item);
}