namespace JQLBuilder.Types;

using Constants;
using Functions;
using Infrastructure;
using JqlTypes;

public class Version
{
    public VersionFunctions Functions { get; } = new();

    public VersionField Fix { get; } = Field.Custom<VersionField>(Fields.FixVersion);
    public VersionField Affected { get; } = Field.Custom<VersionField>(Fields.AffectedVersion);
}

public class OrderingVersion
{
    public VersionField Fix { get; } = Field.Custom<VersionField>(Fields.FixVersion);
    public VersionField Affected { get; } = Field.Custom<VersionField>(Fields.AffectedVersion);
}