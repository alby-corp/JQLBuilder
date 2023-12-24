namespace JQLBuilder.Types;

using System.Data;
using Abstract;
using Primitive;
using Support;

#pragma warning disable CS0660, CS0661
public class Approval(object value) : IJqlValue
#pragma warning restore CS0660, CS0661
{
    static EqualityFunctions StaticEqualityFunctions => new();

    object IJqlValue.Value { get; init; } = value;

    public static implicit operator Approval(string value) => new(value);

    public static Bool operator ==(Approval left, Func<EqualityFunctions, Approval> selector) =>
        left.Equal(selector(StaticEqualityFunctions));

    public static Bool operator !=(Approval _, Func<EqualityFunctions, Approval> __) =>
        throw new InvalidExpressionException("!= is not supported for Approvals");

    public static Bool operator ==(Approval left, Approval right) => left.Equal(right);

    public static Bool operator !=(Approval _, Approval __) =>
        throw new InvalidExpressionException("!= is not supported for Approvals");

    public class EqualityFunctions
    {
        public Approval Approved() => new(new Field("approved()"));
        public Approval Approver(string value) => new(new Field($"""approver("{value}")"""));

        public Approval MyApproval() => new(new Field("myApproval()"));
        public Approval MyPending() => new(new Field("myPending()"));
        public Approval MyPendingApproval() => new(new Field("myPendingApproval()"));

        public Approval Pending() => new(new Field("pending()"));
        public Approval PendingBy(string value) => new(new Field($"""pendingBy("{value}")"""));
    }
}