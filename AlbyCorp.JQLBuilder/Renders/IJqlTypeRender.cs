namespace AlbyCorp.JQLBuilder.Renders;

using Types.Abstract;

internal interface IJqlTypeRender
{
    void Field(string value);

    void String(string value);

    void Bool(bool value);

    void Number(int value);

    void Operator(IJqlType left, string name, IJqlType right);

    void Collection(IReadOnlyList<IJqlType> values);
}