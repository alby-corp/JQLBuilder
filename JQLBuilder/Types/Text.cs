namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Text : TextField
{
    public Text() => Value = new Field(Fields.Text);
    public TextField this[string field] => Field.Custom<TextField>(field);
    public TextField this[int field] => Field.Custom<TextField>(Fields.Custom(field));

    public TextField Summary { get; } = Field.Custom<TextField>(Fields.Summary);
    public TextField Description { get; } = Field.Custom<TextField>(Fields.Description);
    public TextField Comment { get; } = Field.Custom<TextField>(Fields.Comment);
    public TextField Environment { get; } = Field.Custom<TextField>(Fields.Environment);
}