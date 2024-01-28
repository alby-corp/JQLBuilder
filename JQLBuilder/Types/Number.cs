namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Number
{
    // internal const string Votes = "votes";
    // internal const string Watchers = "watchers";
    // internal const string HierarchicalLevel = "hierarchicalLevel";
    
    public NumberField this[string field] => Field.Custom<NumberField>(field);
    public NumberField this[int field] => Field.Custom<NumberField>(Fields.Custom(field));
}