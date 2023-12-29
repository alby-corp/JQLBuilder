namespace JQLBuilder.BuildIn;

using Types.Abstract;
using Types.Primitive;
using Version = Types.Version;

public class BuildInVersion
{
    public Version LatestReleased() => Field.Custom<Version>("latestReleasedVersion()");
    public Version LatestUnreleased() => Field.Custom<Version>("latestUnreleasedVersion()");
    public IJqlCollection<Version> Released() => Field.Custom<JqlCollection<Version>>("releasedVersions()");
    public IJqlCollection<Version> Unreleased() => Field.Custom<JqlCollection<Version>>("unreleasedVersions()");
}