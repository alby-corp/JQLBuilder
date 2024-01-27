namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;

public class ProjectFunctions
{
    public IJqlCollection<JqlProject> LeadByUser() => Function.Custom<JqlCollection<JqlProject>>(Functions.ProjectsLeadByUser, []);
    public IJqlCollection<JqlProject> LeadByUser(JqlArguments.Text user) => Function.Custom<JqlCollection<JqlProject>>(Functions.ProjectsLeadByUser, [user]);
    public IJqlCollection<JqlProject> WhereUserHasPermission(JqlArguments.Text user) => Function.Custom<JqlCollection<JqlProject>>(Functions.WhereUserHasPermission, [user]);
    public IJqlCollection<JqlProject> WhereUserHasRole(JqlArguments.Text user) => Function.Custom<JqlCollection<JqlProject>>(Functions.WhereUserHasRole, [user]);
}