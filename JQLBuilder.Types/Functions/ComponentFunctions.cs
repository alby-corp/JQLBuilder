namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;

public class ComponentFunctions
{
    public IJqlCollection<ComponentExpression> LeadByUser() => Function.Custom<JqlCollection<ComponentExpression>>(Functions.ComponentsLeadByUser, []);
    public IJqlCollection<ComponentExpression> LeadByUser(JqlArguments.Text user) => Function.Custom<JqlCollection<ComponentExpression>>(Functions.ComponentsLeadByUser, [user]);
}