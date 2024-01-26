namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using JQLBuilder.Infrastructure.Abstract;
using JQLBuilder.Infrastructure.Constants;
using Infrastructure.Operators;
using Constants = Constants.Operators;

internal class JqlChange<T> : JqlValue where T : IJqlType
{
    public JqlChange(IReadOnlyList<ChangeOperator> operators)
    {
        Value = operators;
        Operators = operators;
    }

    IReadOnlyList<ChangeOperator> Operators { get; }

    public JqlChange<T> After(JqlDateTime value) => new([..Operators, new(Constants.After, value)]);
    public JqlChange<T> Before(JqlDateTime value) => new([..Operators, new(Constants.Before, value)]);
    public JqlChange<T> On(JqlDateTime value) => new([..Operators, new(Constants.On, value)]);
    public JqlChange<T> During(JqlDateTime from, JqlDateTime to) => new([..Operators, new(Constants.During, new JqlDateRange<JqlDateTime>(from, to))]);
    public JqlChange<T> From(T value) => new([..Operators, new(Constants.From, value)]);
    public JqlChange<T> From(Func<JqlNoValues, JqlValue> selector) => new([..Operators, new(Constants.From, selector(new()))]);
    public JqlChange<T> To(T value) => new([..Operators, new(Constants.To, value)]);
    public JqlChange<T> To(Func<JqlNoValues, JqlValue> selector) => new([..Operators, new(Constants.To, selector(new()))]);
    public JqlChange<T> By(JqlUser jqlUser) => new([..Operators, new(Constants.By, jqlUser)]);
    public JqlChange<T> By(params JqlUser[] users) => By(new JqlCollection<JqlUser>(users));
    public JqlChange<T> By(IJqlCollection<JqlUser> users) => new([..Operators, new(Constants.By, users)]);    
    public JqlChange<T> By(Func<JqlNoValues, JqlValue> selector) => new([..Operators, new(Constants.By, selector(new()))]);
}
