namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;
using Functions = Constants.Functions;

public class UserFunctions
{
    public IJqlCollection<HistoricalUserExpression> MemberOf(JqlArguments.Text user) => Function.Custom<JqlCollection<HistoricalUserExpression>>(Functions.MembersOf, [user]);
    public HistoricalUserExpression CurrentUser() => Function.Custom<HistoricalUserExpression>(Functions.CurrentUser, []);
}