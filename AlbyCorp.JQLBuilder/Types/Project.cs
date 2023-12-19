namespace AlbyCorp.JQLBuilder.Types;

using Abstract;

public class Project(object value) : JqlValue(value), IJqlType.IEquatable<Project>
{
    static ProjectFunctions Functions => new ProjectFunctions();

    public static Bool operator ==(Project left, Project right) => JqlType.Equals(left, right);
    public static Bool operator !=(Project left, Project right) => JqlType.NotEquals(left, right);
    public static implicit operator Project(string value) => new Project(value);
    public static implicit operator Project(int value) => new Project(value);

    public Bool In(Func<ProjectFunctions, IJqlType.ICollection<Project>> functions) =>
        new JqlType.Operator(this, "in", functions(Functions));

    public Bool NotIn(Func<ProjectFunctions, IJqlType.ICollection<Project>> functions) =>
        new JqlType.Operator(this, "not in", functions(Functions));

    public class ProjectFunctions
    {
        public IJqlType.ICollection<Project> LeadByUser(string value) =>
            new JqlType.Collection<Project>(new JqlType.Field($"""projectsLeadByUser("{value}")"""));

        public IJqlType.ICollection<Project> WhereUserHasPermission(string value) =>
            new JqlType.Collection<Project>(
                new JqlType.Field($"""projectsWhereUserHasPermission("{value}")"""));

        public IJqlType.ICollection<Project> WhereUserHasRole(string value) =>
            new JqlType.Collection<Project>(new JqlType.Field($"""projectsWhereUserHasRole("{value}")"""));
    }
}