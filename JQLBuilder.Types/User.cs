namespace JQLBuilder.Types;

using Constants;
using Infrastructure;
using JqlTypes;

public class User
{
    public UserField Creator { get; } = Field.Custom<UserField>(Fields.Creator);
    public UserField Voter { get; } = Field.Custom<UserField>(Fields.Voter);
    public UserField Watcher { get; } = Field.Custom<UserField>(Fields.Watcher);
}

public class OrderingUser
{
    public UserField Creator { get; } = Field.Custom<UserField>(Fields.Creator);
    public UserField Voter { get; } = Field.Custom<UserField>(Fields.Voter);
    public UserField Watcher { get; } = Field.Custom<UserField>(Fields.Watcher);
}