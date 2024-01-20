namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class User
{
    public UserField Creator { get; } = Field.Custom<UserField>(Fields.Creator);
    public UserField Voter { get; } = Field.Custom<UserField>(Fields.Voter);
    public UserField Watcher { get; } = Field.Custom<UserField>(Fields.Watchers);
    public HistoricalUserField Assignee { get; } = Field.Custom<HistoricalUserField>(Fields.Assignee);
    public HistoricalUserField Reporter { get; } = Field.Custom<HistoricalUserField>(Fields.Reporter);
}

public class OrderingUser
{
    public UserField Creator { get; } = Field.Custom<UserField>(Fields.Creator);
    public UserField Watchers { get; } = Field.Custom<UserField>(Fields.Watchers);
    
    public HistoricalUserField Assignee { get; } = Field.Custom<HistoricalUserField>(Fields.Assignee);
    
    public HistoricalUserField Reporter { get; } = Field.Custom<HistoricalUserField>(Fields.Reporter);
}