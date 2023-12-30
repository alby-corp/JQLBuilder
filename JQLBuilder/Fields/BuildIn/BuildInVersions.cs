namespace JQLBuilder.BuildIn;

using Types;
using Types.Abstract;
using Types.Primitive;

public class BuildInVersions
{
    public VersionExpression LatestReleased() => Field.Custom<VersionExpression>("latestReleasedVersion()");
    public VersionExpression LatestUnreleased() => Field.Custom<VersionExpression>("latestUnreleasedVersion()");
    public IJqlCollection<VersionExpression> Released() => Field.Custom<JqlCollection<VersionExpression>>("releasedVersions()");
    public IJqlCollection<VersionExpression> Unreleased() => Field.Custom<JqlCollection<VersionExpression>>("unreleasedVersions()");
}