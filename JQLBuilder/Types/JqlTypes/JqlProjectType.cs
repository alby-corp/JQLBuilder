namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class ProjectTypeField : JqlValue, IJqlField<JqlProjectType>
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(ProjectTypeField left, JqlProjectType right) => left.Equal(right);
    public static Bool operator !=(ProjectTypeField left, JqlProjectType right) => left.NotEqual(right);
    public static Bool operator ==(JqlProjectType left,  ProjectTypeField right) => right.Equal(left);
    public static Bool operator !=(JqlProjectType left, ProjectTypeField right) => right.NotEqual(left);
}

public class JqlProjectType : JqlValue, IJqlMembership<JqlProjectType>
{
    public static implicit operator JqlProjectType(string value) => new() { Value = value };
}