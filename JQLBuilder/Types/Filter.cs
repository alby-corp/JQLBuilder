namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Filter : FilterField
{
    public Filter() => Value = new Field(Fields.Filter);
    
    public FilterField SearchRequest { get; } = Field.Custom<FilterField>(Fields.SearchRequest);
    public FilterField Request { get; } = Field.Custom<FilterField>(Fields.Request);
    public FilterField SavedFilter { get; } = Field.Custom<FilterField>(Fields.SavedFilter);
}