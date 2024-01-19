namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;
using Functions = Constants.Functions;

public class UserFunctions
{
    public IJqlCollection<ProjectExpression> MemberOf(TextArgument user) => Function.Custom<JqlCollection<ProjectExpression>>(Functions.MembersOf, [user]);
    public IJqlCollection<ProjectExpression> CurrentUser() => Function.Custom<JqlCollection<ProjectExpression>>(Functions.CurrentLogin, []);
}