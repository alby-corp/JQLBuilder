namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Parent : ParentField
{
    public Parent() => Value = new Field(Fields.Parent);
}