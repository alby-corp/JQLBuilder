namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Category: CategoryField
{
    public Category() => Value = new Field(Fields.Category);
}