namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class SprintFunctions
{
    public IJqlCollection<JqlSprint> Open() => Function.Custom<JqlCollection<JqlSprint>>(Functions.OpenSprints, []);
    public IJqlCollection<JqlSprint> Closed() => Function.Custom<JqlCollection<JqlSprint>>(Functions.ClosedSprints, []);
}