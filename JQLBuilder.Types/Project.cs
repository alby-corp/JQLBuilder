namespace JQLBuilder.Types;

using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Project(object value) : IJqlValue, IJqlNullable, IJqlMembership<Project>
#pragma warning restore CS0660, CS0661
{
    static ProjectFunctions Functions => new();
    object IJqlValue.Value { get; init; } = value;

    public static implicit operator Project(string value) => new(value);
    public static implicit operator Project(int value) => new(value);

    public static Bool operator ==(Project left, Project right) => left.Equal(right);
    public static Bool operator !=(Project left, Project right) => left.NotEqual(right);

    public Bool In(Func<ProjectFunctions, IJqlCollection<Project>> functions) => this.In(functions(Functions));
    public Bool NotIn(Func<ProjectFunctions, IJqlCollection<Project>> functions) => this.NotIn(functions(Functions));

    public class ProjectFunctions
    {
        public IJqlCollection<Project> LeadByUser(string value) =>
            new JqlCollection<Project>(new Field($"""projectsLeadByUser("{value}")"""));

        public IJqlCollection<Project> WhereUserHasPermission(string value) =>
            new JqlCollection<Project>(new Field($"""projectsWhereUserHasPermission("{value}")"""));

        public IJqlCollection<Project> WhereUserHasRole(string value) =>
            new JqlCollection<Project>(new Field($"""projectsWhereUserHasRole("{value}")"""));
    }
}