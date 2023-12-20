namespace AlbyCorp.JQLBuilder.Types.Enum;

public enum Priority
{
    Powerful = 1 << 16,
    Relation = 1 << 2,
    Equality = 1 << 1,
    LogicalAnd = 1 << 0,
    LogicalOr = 0
}