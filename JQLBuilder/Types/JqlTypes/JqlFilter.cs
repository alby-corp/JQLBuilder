namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Operators;

#pragma warning disable CS0660, CS0661
public class FilterField : JqlValue, IJqlField<JqlFilter>
#pragma warning restore CS0660, CS0661
{
    public static Bool operator ==(FilterField left, JqlFilter right) => left.Equal(right);
    public static Bool operator !=(FilterField left, JqlFilter right) => left.NotEqual(right);
    public static Bool operator ==(JqlFilter left, FilterField right) => right.Equal(left);
    public static Bool operator !=(JqlFilter left, FilterField right) => right.NotEqual(left);
}

public class JqlFilter : JqlValue, IJqlMembership<JqlFilter>
{
    public static implicit operator JqlFilter(string value) => new() { Value = new Field(value) };
    public static implicit operator JqlFilter(int value) => new() { Value = value };
}