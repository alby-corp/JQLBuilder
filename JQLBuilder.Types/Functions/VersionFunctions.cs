namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class VersionFunctions
{
    public VersionExpression LatestReleased => Function.Custom<VersionExpression>(Functions.LatestReleased, []);
    public VersionExpression LatestUnreleased => Function.Custom<VersionExpression>(Functions.LatestUnreleased, []);
    public IJqlCollection<VersionExpression> Released => Function.Custom<JqlCollection<VersionExpression>>(Functions.Released, []);
    public IJqlCollection<VersionExpression> Unreleased => Function.Custom<JqlCollection<VersionExpression>>(Functions.Unreleased, []);
}
