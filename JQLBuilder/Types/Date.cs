namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class Date
{
    public DateField DueDate { get; } = Field.Custom<DateField>(Fields.DueDate);
    public DateField Due { get; } = Field.Custom<DateField>(Fields.Due);
    public DateTimeField Created { get; } = Field.Custom<DateTimeField>(Fields.Created);
    public DateTimeField CreatedDate { get; } = Field.Custom<DateTimeField>(Fields.CreatedDate);
    public DateTimeField Updated { get; } = Field.Custom<DateTimeField>(Fields.Updated);
    public DateTimeField UpdatedDate { get; } = Field.Custom<DateTimeField>(Fields.UpdatedDate);
    public DateTimeField Resolved { get; } = Field.Custom<DateTimeField>(Fields.Resolved);
    public DateTimeField ResolutionDate { get; } = Field.Custom<DateTimeField>(Fields.ResolutionDate);
    public DateTimeField LastViewed { get; } = Field.Custom<DateTimeField>(Fields.LastViewed);

    public DateTime Time { get; } = new();
    public DateOnly Only { get; } = new();


    public class DateOnly
    {
        public new DateField this[string field] => Field.Custom<DateField>(field);
        public new DateField this[int field] => Field.Custom<DateField>(Fields.Custom(field));
    }

    public class DateTime
    {
        public new DateTimeField this[string field] => Field.Custom<DateTimeField>(field);
        public new DateTimeField this[int field] => Field.Custom<DateTimeField>(Fields.Custom(field));
    }
}