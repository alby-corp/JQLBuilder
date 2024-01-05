namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class VersionFunctions
{
    public VersionExpression LatestReleased() => Field.Custom<VersionExpression>("latestReleasedVersion()");
    public VersionExpression LatestUnreleased() => Field.Custom<VersionExpression>("latestUnreleasedVersion()");
    public IJqlCollection<VersionExpression> Released() => Field.Custom<JqlCollection<VersionExpression>>("releasedVersions()");
    public IJqlCollection<VersionExpression> Unreleased() => Field.Custom<JqlCollection<VersionExpression>>("unreleasedVersions()");
}