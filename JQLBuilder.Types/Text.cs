namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Text
{
    public TextField this[string field] => Field.Custom<TextField>(field);
    public TextField this[int field] => Field.Custom<TextField>(Fields.Custom(field));

    public TextField Summary { get; } = Field.Custom<TextField>("summary");
}