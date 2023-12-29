namespace JQLBuilder.BuildIn;

using Types;
using Types.Abstract;
using Types.Primitive;

public class Versions
{
    public Base.BuildIn LatestReleased() => Field.Custom<Base.BuildIn>("latestReleasedVersion()");
    public Base.BuildIn LatestUnreleased() => Field.Custom<Base.BuildIn>("latestUnreleasedVersion()");
    public IJqlCollection<Base> Released() => Field.Custom<JqlCollection<Base.BuildIn>>("releasedVersions()");
    public IJqlCollection<Base> Unreleased() => Field.Custom<JqlCollection<Base.BuildIn>>("unreleasedVersions()");
}