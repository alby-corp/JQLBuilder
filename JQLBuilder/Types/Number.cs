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
    public NumberField Votes { get; } = Field.Custom<NumberField>(Fields.Votes);
    public NumberField Watchers { get; } = Field.Custom<NumberField>(Fields.Watchers);
    public NumberField HierarchicalLevel { get; } = Field.Custom<NumberField>(Fields.HierarchicalLevel);
}