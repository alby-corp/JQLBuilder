namespace JQLBuilder.BuildIn;

using Types;
using Types.Abstract;
using Types.Primitive;
using Version = Types.Version;

public abstract class BuildInVersion
{
    public class Equality : BuildInVersion
    {
        public Version Released() => Field.Custom<Version>("latestReleasedVersion()");
        public Version Unreleased() => Field.Custom<Version>("latestUnreleasedVersion()");
    }
    
    public class Membership : BuildInVersion
    {
        public IJqlCollection<Version> Released() => Field.Custom<JqlCollection<Version>>("releasedVersions()");
        public IJqlCollection<Version> Unreleased() => Field.Custom<JqlCollection<Version>>("unreleasedVersions()");
    }
}