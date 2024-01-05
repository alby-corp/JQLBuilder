namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using Infrastructure.Constants;
using JqlTypes;

public class Version
{
    public VersionFunctions Functions { get; } = new();

    public VersionField Fix { get; } = Field.Custom<VersionField>(JqlKeywords.FixVersion);
    public VersionField Affected { get; } = Field.Custom<VersionField>(JqlKeywords.AffectedVersion);
}

public class OrderingVersion
{
    public VersionField Fix { get; } = Field.Custom<VersionField>(JqlKeywords.FixVersion);
    public VersionField Affected { get; } = Field.Custom<VersionField>(JqlKeywords.AffectedVersion);
}