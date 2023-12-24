namespace JQLBuilder.Types;

using System.ComponentModel;
using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Version(object value) : IJqlValue, IJqlMembership<Version>, IJqlNullable
#pragma warning restore CS0660, CS0661
{
    static MembershipFunctions StaticMembershipFunctions => new();
    static EqualityFunctions StaticEqualityFunctions => new();
    object IJqlValue.Value { get; init; } = value;
    
    public static implicit operator Version(string value) => new(value);
    public static implicit operator Version(int value) => new(value);

    public static Bool operator ==(Version left, Version right) => left.Equal(right);
    public static Bool operator !=(Version left, Version right) => left.NotEqual(right);
    public static Bool operator ==(Version left, Func<EqualityFunctions, Version> selector) => left.Equal(selector(StaticEqualityFunctions));
    public static Bool operator !=(Version left, Func<EqualityFunctions, Version> selector) => left.NotEqual(selector(StaticEqualityFunctions));

    public static Bool operator >(Version left, Version right) => left.GreaterThan(right);
    public static Bool operator >=(Version left, Version right) => left.GreaterThanOrEqual(right);

    public static Bool operator <(Version left, Version right) => left.LessThan(right);
    public static Bool operator <=(Version left, Version right) => left.LessThanOrEqual(right);
    
    public Bool In(Func<MembershipFunctions, IJqlCollection<Version>> functions) => this.In(functions(StaticMembershipFunctions));
    public Bool NotIn(Func<MembershipFunctions, IJqlCollection<Version>> functions) => this.NotIn(functions(StaticMembershipFunctions));
    
    public class EqualityFunctions
    {
        public Version Released() => new(new Field("latestReleasedVersion()"));
        public Version Unreleased() => new(new Field("earliestUnreleasedVersion()"));
    }
    
    public class MembershipFunctions
    {
        public IJqlCollection<Project> Released() => new JqlCollection<Project>(new Field("releasedVersions()"));
        public IJqlCollection<Project> Unreleased() => new JqlCollection<Project>(new Field("unreleasedVersions()"));
    }
}