namespace JQLBuilder.Types.Functions;

using Infrastructure;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using JqlTypes;

public class VersionFunctions
{
    public VersionExpression LatestReleased => Field.Custom<VersionExpression>(JqlKeywords.LatestReleased);
    public VersionExpression LatestUnreleased => Field.Custom<VersionExpression>(JqlKeywords.LatestUnreleased);
    public IJqlCollection<VersionExpression> Released => Field.Custom<JqlCollection<VersionExpression>>(JqlKeywords.Released);
    public IJqlCollection<VersionExpression> Unreleased => Field.Custom<JqlCollection<VersionExpression>>(JqlKeywords.Unreleased);
}