namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class VersionFunctions
{
    public JqlVersion LatestReleased => Function.Custom<JqlVersion>(Functions.LatestReleased, []);
    public JqlVersion LatestUnreleased => Function.Custom<JqlVersion>(Functions.LatestUnreleased, []);
    public IJqlCollection<JqlVersion> Released => Function.Custom<JqlCollection<JqlVersion>>(Functions.Released, []);
    public IJqlCollection<JqlVersion> Unreleased => Function.Custom<JqlCollection<JqlVersion>>(Functions.Unreleased, []);
}
