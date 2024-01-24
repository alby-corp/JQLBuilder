namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class ProjectFunctions
{
    public IJqlCollection<ProjectExpression> LeadByUser(TextArgument? user = default) => user is null 
        ? Function.Custom<JqlCollection<ProjectExpression>>(Functions.ProjectsLeadByUser, [])
        : Function.Custom<JqlCollection<ProjectExpression>>(Functions.ProjectsLeadByUser, [user]);
    
    public IJqlCollection<ProjectExpression> WhereUserHasPermission(TextArgument user) => Function.Custom<JqlCollection<ProjectExpression>>(Functions.WhereUserHasPermission, [user]);
    public IJqlCollection<ProjectExpression> WhereUserHasRole(TextArgument user) => Function.Custom<JqlCollection<ProjectExpression>>(Functions.WhereUserHasRole, [user]);
}
