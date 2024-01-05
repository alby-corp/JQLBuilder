namespace JQLBuilder.Types;

using Infrastructure;
using JqlTypes;

public class Text
{
    public TextField this[string field] => Field.Custom<TextField>(field);
    public TextField this[int field] => Field.Custom<TextField>($"cf[{field}]");
}