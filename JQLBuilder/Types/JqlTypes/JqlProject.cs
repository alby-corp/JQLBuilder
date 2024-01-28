namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class ProjectField : JqlValue, IJqlField<JqlProject>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ProjectField left, JqlProject right) => left.Equal(right);
    public static Bool operator !=(ProjectField left, JqlProject right) => left.NotEqual(right);
    public static Bool operator ==(JqlProject left, ProjectField right) => right.Equal(left);
    public static Bool operator !=(JqlProject left, ProjectField right) => right.NotEqual(left);
}

public class JqlProject : JqlValue, IJqlMembership<JqlProject>
{
    public static implicit operator JqlProject(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlProject(int value) => new() { Value = value };
}