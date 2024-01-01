namespace JQLBuilder.Fields.BuildIn;

using Types;
using Types.Primitive;

public class BuildInProjects
{
    public ProjectExpression LeadByUser() => Field.Custom<ProjectExpression>($"projectsLeadByUser()");
    public ProjectExpression WhereUserHasPermission(string user) => Field.Custom<ProjectExpression>($"""projectsWhereUserHasPermission("{user}")""");
    public ProjectExpression WhereUserHasRole(string user) => Field.Custom<ProjectExpression>($"""projectsWhereUserHasRole("{user}")""");
}