namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class SprintField : JqlValue, IJqlField<JqlSprint>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(SprintField left, JqlSprint right) => left.Equal(right);
    public static Bool operator !=(SprintField left, JqlSprint right) => left.NotEqual(right);
    public static Bool operator ==(JqlSprint left, SprintField right) => right.Equal(left);
    public static Bool operator !=(JqlSprint left, SprintField right) => right.NotEqual(left);
}

public class JqlSprint : JqlValue, IJqlMembership<JqlSprint>, IJqlHistorical<JqlSprint>
{
    public static implicit operator JqlSprint(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlSprint(int value) => new() { Value = value };
}