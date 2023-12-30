namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class ProjectField : JqlValue, IJqlField<ProjectExpression>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ProjectField left, ProjectExpression right) => left.Equal(right);
    public static Bool operator !=(ProjectField left, ProjectExpression right) => left.NotEqual(right);

    public static Bool operator ==(ProjectExpression left, ProjectField right) => right.Equal(left);
    public static Bool operator !=(ProjectExpression left, ProjectField right) => right.NotEqual(left);
}

public class ProjectExpression : JqlValue, IJqlMembership<ProjectExpression>
{
    public static implicit operator ProjectExpression(string value) => new() { Value = value };
    public static implicit operator ProjectExpression(int value) => new() { Value = value };
}