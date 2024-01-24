namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlTypes;

public class ComponentFunctions
{
    public IJqlCollection<ComponentExpression> LeadByUser(TextArgument? user = default) => user is null
        ? Function.Custom<JqlCollection<ComponentExpression>>(Functions.ComponentsLeadByUser, [])
        : Function.Custom<JqlCollection<ComponentExpression>>(Functions.ComponentsLeadByUser, [user]);
}