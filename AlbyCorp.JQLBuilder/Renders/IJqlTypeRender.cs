namespace AlbyCorp.JQLBuilder.Renders;

using Enums;
using Types;

internal interface IJqlTypeRender
{
    void Field(string value);

    void String(string value);

    void Bool(bool value);

    void Number(int value);

    void Operator(IJqlType left, string name, IJqlType right, Priority priority);

    void Collection(IReadOnlyList<IJqlType> values);
}