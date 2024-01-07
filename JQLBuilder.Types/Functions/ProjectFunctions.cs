namespace JQLBuilder.Types.Functions;

using Contains;
using Infrastructure;
using JqlTypes;

public class ProjectFunctions
{
    public ProjectExpression LeadByUser(string user) => Field.Custom<ProjectExpression>(Functions.LeadByUser(user));
    public ProjectExpression WhereUserHasPermission(string user) => Field.Custom<ProjectExpression>(Functions.WhereUserHasPermission(user));
    public ProjectExpression WhereUserHasRole(string user) => Field.Custom<ProjectExpression>(Functions.WhereUserHasRole(user));
}