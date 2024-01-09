namespace JQLBuilder.Types.Functions;

using Contains;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class ProjectFunctions
{
    public IJqlCollection<ProjectExpression> LeadByUser(string user) => Field.Custom<JqlCollection<ProjectExpression>>(Functions.LeadByUser(user));
    public IJqlCollection<ProjectExpression> WhereUserHasPermission(string user) => Field.Custom<JqlCollection<ProjectExpression>>(Functions.WhereUserHasPermission(user));
    public IJqlCollection<ProjectExpression> WhereUserHasRole(string user) => Field.Custom<JqlCollection<ProjectExpression>>(Functions.WhereUserHasRole(user));
}