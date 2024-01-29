namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class EpicLinkField : JqlValue, IJqlField<JqlEpicLink>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(EpicLinkField left, JqlEpicLink right) => left.Equal(right);
    public static Bool operator !=(EpicLinkField left, JqlEpicLink right) => left.NotEqual(right);
    public static Bool operator ==(JqlEpicLink left, EpicLinkField right) => right.Equal(left);
    public static Bool operator !=(JqlEpicLink left, EpicLinkField right) => right.NotEqual(left);
}

public class JqlEpicLink : JqlValue, IJqlMembership<JqlEpicLink>
{
    public static implicit operator JqlEpicLink(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlEpicLink(int value) => new() { Value = value };
}