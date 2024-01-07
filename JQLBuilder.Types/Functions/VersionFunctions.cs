namespace JQLBuilder.Types.Functions;

using Contains;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class VersionFunctions
{
    public VersionExpression LatestReleased => Field.Custom<VersionExpression>(Functions.LatestReleased);
    public VersionExpression LatestUnreleased => Field.Custom<VersionExpression>(Functions.LatestUnreleased);
    public IJqlCollection<VersionExpression> Released => Field.Custom<JqlCollection<VersionExpression>>(Functions.Released);
    public IJqlCollection<VersionExpression> Unreleased => Field.Custom<JqlCollection<VersionExpression>>(Functions.Unreleased);
}