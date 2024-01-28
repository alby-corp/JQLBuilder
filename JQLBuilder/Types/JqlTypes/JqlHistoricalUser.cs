namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class HistoricalUserField : JqlValue, IJqlField<JqlHistoricalJqlUser>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(HistoricalUserField left, JqlHistoricalJqlUser right) => left.Equal(right);
    public static Bool operator !=(HistoricalUserField left, JqlHistoricalJqlUser right) => left.NotEqual(right);
    public static Bool operator ==(JqlHistoricalJqlUser left, HistoricalUserField right) => right.Equal(left);
    public static Bool operator !=(JqlHistoricalJqlUser left, HistoricalUserField right) => right.NotEqual(left);
}

public class JqlHistoricalJqlUser : JqlUser, IJqlHistorical<JqlHistoricalJqlUser>
{
    public static implicit operator JqlHistoricalJqlUser(string value) => new() { Value = value };
    public static implicit operator JqlHistoricalJqlUser(int value) => new() { Value = value };
}