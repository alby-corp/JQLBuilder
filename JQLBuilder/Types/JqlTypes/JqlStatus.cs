namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class StatusField : JqlValue, IJqlField<JqlStatus>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(StatusField left, JqlStatus right) => left.Equal(right);
    public static Bool operator !=(StatusField left, JqlStatus right) => left.NotEqual(right);
    public static Bool operator ==(JqlStatus left, StatusField right) => right.Equal(left);
    public static Bool operator !=(JqlStatus left, StatusField right) => right.NotEqual(left);
}

public class JqlStatus : JqlValue, IJqlMembership<JqlStatus>, IJqlHistorical<JqlStatus>
{
    public static implicit operator JqlStatus(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlStatus(int value) => new() { Value = new Field($"{value}") };
}