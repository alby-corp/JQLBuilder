namespace JQLBuilder.Types.JqlTypes;

using Abstract;
using Infrastructure;
using Infrastructure.Abstract;

public class UserField : JqlValue, IJqlField<UserExpression>, IJqlNullable;

public class UserExpression : JqlValue, IJqlMembership<UserExpression>
{
    public static implicit operator UserExpression(int value) => new() { Value = value };
    public static implicit operator UserExpression(string value) => new() { Value = value };
}
