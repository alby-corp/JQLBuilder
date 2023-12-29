namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Project : JqlValue, IJqlNullable, IJqlMembership<Project>
#pragma warning restore CS0660, CS0661
{
    public static implicit operator Project(string value) => new() { Value = value };
    public static implicit operator Project(int value) => new() { Value = value };

    public static Bool operator ==(Project left, Project right) => left.Equal(right);
    public static Bool operator !=(Project left, Project right) => left.NotEqual(right);
}