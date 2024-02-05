namespace JQLBuilder.Types;

using Infrastructure;
using Constants;
using JqlTypes;

public class TimeTracking
{
    public DurationField OriginalEstimate { get; } = Field.Custom<DurationField>(Fields.OriginalEstimate);
    public DurationField RemainingEstimate { get; } = Field.Custom<DurationField>(Fields.RemainingEstimate);
    public DurationField TimeSpent { get; } = Field.Custom<DurationField>(Fields.TimeSpent);
    public DurationField TimeOriginalEstimate { get; } = Field.Custom<DurationField>(Fields.TimeOriginalEstimate);
    public DurationField TimeEstimate { get; } = Field.Custom<DurationField>(Fields.TimeEstimate);
    
    public WorkLog WorkLog { get; } = new();
}

public class WorkLog
{
    public TextField Comment { get; } = Field.Custom<TextField>(Fields.WorklogComment);
    public NumberField Ratio { get; } = Field.Custom<NumberField>(Fields.WorkRatio);
    public DateField Date { get; } = Field.Custom<DateField>(Fields.WorklogDate);
}

public class OrderingTimeTracking
{
    public DurationField OriginalEstimate { get; } = Field.Custom<DurationField>(Fields.TimeOriginalEstimate);
    public DurationField RemainingEstimate { get; } = Field.Custom<DurationField>(Fields.TimeEstimate);
    public DurationField TimeSpent { get; } = Field.Custom<DurationField>(Fields.TimeSpent);
    public DurationField TimeOriginalEstimate { get; } = Field.Custom<DurationField>(Fields.TimeOriginalEstimate);
    public DurationField TimeEstimate { get; } = Field.Custom<DurationField>(Fields.TimeEstimate);
    
    public OrderingWorkLog WorkLog { get; } = new();
}

public class OrderingWorkLog
{
    public NumberField Ratio { get; } = Field.Custom<NumberField>(Fields.WorkRatio);
}