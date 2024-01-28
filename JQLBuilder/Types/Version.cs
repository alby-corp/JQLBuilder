namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Version
{
    public VersionField Fix { get; } = Field.Custom<VersionField>(Fields.FixVersion);
    public VersionField Affected { get; } = Field.Custom<VersionField>(Fields.AffectedVersion);
}

public class OrderingVersion
{
    public VersionField Fix { get; } = Field.Custom<VersionField>(Fields.FixVersion);
    public VersionField Affected { get; } = Field.Custom<VersionField>(Fields.AffectedVersion);
}