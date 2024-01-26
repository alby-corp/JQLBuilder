namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;
using Functions = Constants.Functions;

public class UserFunctions
{
    public IJqlCollection<JqlHistoricalJqlUser> MemberOf(JqlArguments.Text user) => Function.Custom<JqlCollection<JqlHistoricalJqlUser>>(Functions.MembersOf, [user]);
    public JqlHistoricalJqlUser CurrentUser() => Function.Custom<JqlHistoricalJqlUser>(Functions.CurrentUser, []);
}