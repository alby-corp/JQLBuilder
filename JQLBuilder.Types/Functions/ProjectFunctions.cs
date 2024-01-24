namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;

public class ProjectFunctions
{
    public IJqlCollection<ProjectExpression> LeadByUser() => Function.Custom<JqlCollection<ProjectExpression>>(Functions.ProjectsLeadByUser, []);
    public IJqlCollection<ProjectExpression> LeadByUser(JqlArguments.Text user) => Function.Custom<JqlCollection<ProjectExpression>>(Functions.ProjectsLeadByUser, [user]);
    public IJqlCollection<ProjectExpression> WhereUserHasPermission(JqlArguments.Text user) => Function.Custom<JqlCollection<ProjectExpression>>(Functions.WhereUserHasPermission, [user]);
    public IJqlCollection<ProjectExpression> WhereUserHasRole(JqlArguments.Text user) => Function.Custom<JqlCollection<ProjectExpression>>(Functions.WhereUserHasRole, [user]);
}
