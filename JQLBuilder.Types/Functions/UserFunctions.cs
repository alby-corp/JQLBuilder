namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;
using Functions = Constants.Functions;

public class UserFunctions
{
    public IJqlCollection<HistoricalUserExpression> MemberOf(TextArgument user) => Function.Custom<JqlCollection<HistoricalUserExpression>>(Functions.MembersOf, [user]);
    public HistoricalUserExpression CurrentUser() => Function.Custom<HistoricalUserExpression>(Functions.CurrentUser, []);
}