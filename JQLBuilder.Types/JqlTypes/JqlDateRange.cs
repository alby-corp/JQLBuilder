namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using Infrastructure.Abstract;

public class JqlDateRange<T> : JqlValue where T : JqlDateTime
{
    public JqlDateRange(T from, T to) => Value = Tuple.Create<IJqlType, IJqlType>(from, to);
}
