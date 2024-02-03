namespace JQLBuilder.Types;

using Infrastructure;
using Constants;
using JqlTypes;

public class OrderingTimeTracking
{
    public WorkLog WorkLog { get; } = new();
}


public class TimeTracking
{
    public WorkLog WorkLog { get; } = new();
}

public class WorkLog
{
    public TextField Comment { get; } = Field.Custom<TextField>(Fields.WorklogComment);
    public NumberField Ratio { get; } = Field.Custom<NumberField>(Fields.WorkRatio);
    public DateTimeField Date { get; } = Field.Custom<DateTimeField>(Fields.WorkRatio);
}

public class OrderingWorkLog
{
    public NumberField Ratio { get; } = Field.Custom<NumberField>(Fields.WorkRatio);
}