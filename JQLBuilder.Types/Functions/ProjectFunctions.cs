namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;

public class ProjectFunctions
{
    public ProjectExpression LeadByUser(string user) => Field.Custom<ProjectExpression>(JqlKeywords.LeadByUser(user));
    public ProjectExpression WhereUserHasPermission(string user) => Field.Custom<ProjectExpression>(JqlKeywords.WhereUserHasPermission(user));
    public ProjectExpression WhereUserHasRole(string user) => Field.Custom<ProjectExpression>(JqlKeywords.WhereUserHasRole(user));
}