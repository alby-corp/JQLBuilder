namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;
using Functions = Constants.Functions;

public class UserFunctions
{
    public IJqlCollection<UserExpression> MemberOf(TextArgument user) => Function.Custom<JqlCollection<UserExpression>>(Functions.MembersOf, [user]);
    public UserExpression CurrentUser() => Function.Custom<UserExpression>(Functions.CurrentUser, []);
}