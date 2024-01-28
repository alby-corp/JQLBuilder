namespace JQLBuilder.Types.Functions;

using Constants;
using Infrastructure;
using Infrastructure.Abstract;
using JqlArguments;
using JqlTypes;

public class ComponentFunctions
{
    public IJqlCollection<JqlComponent> LeadByUser() => Function.Custom<JqlCollection<JqlComponent>>(Functions.ComponentsLeadByUser, []);
    public IJqlCollection<JqlComponent> LeadByUser(JqlArguments.Text user) => Function.Custom<JqlCollection<JqlComponent>>(Functions.ComponentsLeadByUser, [user]);
}