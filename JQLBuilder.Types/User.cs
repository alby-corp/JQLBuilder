namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class User
{
    public UserField this[string field] => Field.Custom<UserField>(field);
    public UserField this[int field] => Field.Custom<UserField>(Fields.Custom(field));

    public HistoricalUser Historical { get; } = new();
    
    public class HistoricalUser
    {
        public new HistoricalUserField this[string field] => Field.Custom<HistoricalUserField>(field);
        public new HistoricalUserField this[int field] => Field.Custom<HistoricalUserField>(Fields.Custom(field));
    }
    
    public UserField Creator { get; } = Field.Custom<UserField>(Fields.Creator);
    public UserField Voter { get; } = Field.Custom<UserField>(Fields.Voter);
    public UserField Watcher { get; } = Field.Custom<UserField>(Fields.Watcher);
    public HistoricalUserField Assignee { get; } = Field.Custom<HistoricalUserField>(Fields.Assignee);
    public HistoricalUserField Reporter { get; } = Field.Custom<HistoricalUserField>(Fields.Reporter);
}

public class OrderingUser
{
    public UserField Creator { get; } = Field.Custom<UserField>(Fields.Creator);
    public UserField Watcher { get; } = Field.Custom<UserField>(Fields.Watcher);
    
    public HistoricalUserField Assignee { get; } = Field.Custom<HistoricalUserField>(Fields.Assignee);
    
    public HistoricalUserField Reporter { get; } = Field.Custom<HistoricalUserField>(Fields.Reporter);
}