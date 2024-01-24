namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class SprintFunctions
{
    public IJqlCollection<SprintExpression> Open() => Function.Custom<JqlCollection<SprintExpression>>(Functions.OpenSprints, []);
    public IJqlCollection<SprintExpression> Closed() => Function.Custom<JqlCollection<SprintExpression>>(Functions.ClosedSprints, []);
}