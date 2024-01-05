namespace JQLBuilder.Types;

using Functions;
using Infrastructure;
using JqlTypes;

public class Version
{
    public VersionFunctions Functions { get; } = new();

    public VersionField Fix { get; } = Field.Custom<VersionField>("fixVersion");
    public VersionField Affected { get; } = Field.Custom<VersionField>("affectedVersion");
}

public class OrderingVersion
{
    public VersionField Fix { get; } = Field.Custom<VersionField>("fixVersion");
    public VersionField Affected { get; } = Field.Custom<VersionField>("affectedVersion");
}