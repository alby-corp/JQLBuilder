namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;
using Support;

#pragma warning disable CS0660, CS0661
public class UserField : JqlValue, IJqlField<JqlUser>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(UserField left, JqlUser right) => left.Equal(right);
    public static Bool operator !=(UserField left, JqlUser right) => left.NotEqual(right);
    public static Bool operator ==(JqlUser left, UserField right) => right.Equal(left);
    public static Bool operator !=(JqlUser left, UserField right) => right.NotEqual(left);
}

public class JqlUser : JqlValue, IJqlMembership<JqlUser>
{
    public static implicit operator JqlUser(string value) => new() { Value = value };
    public static implicit operator JqlUser(int value) => new() { Value = value };
}