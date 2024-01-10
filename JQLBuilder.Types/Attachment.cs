namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Attachment : AttachmentField
{
    public Attachment() => Value = new Field(Fields.Attachment);
}