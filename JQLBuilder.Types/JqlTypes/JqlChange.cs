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

    public JqlChange<T> After(DateTimeExpression value) => new([..Operators, new(Constants.After, value)]);

    public JqlChange<T> Before(DateTimeExpression value) => new([..Operators, new(Constants.Before, value)]);
    
    public JqlChange<T> On(DateTimeExpression value) => new([..Operators, new(Constants.On, value)]);

    public JqlChange<T> During(DateTimeExpression from, DateTimeExpression to) => new([..Operators, new(Constants.During, new JqlDateRange<DateTimeExpression>(from, to))]);
    
    public JqlChange<T> From(T value) => new([..Operators, new(Constants.From, value)]);
    public JqlChange<T> From(Func<JqlNoValues, JqlValue> selector) => new([..Operators, new(Constants.From, selector(new()))]);

    
    public JqlChange<T> To(T value) => new([..Operators, new(Constants.To, value)]);
    public JqlChange<T> To(Func<JqlNoValues, JqlValue> selector) => new([..Operators, new(Constants.To, selector(new()))]);
    
    public JqlChange<T> By(UserExpression user) => new([..Operators, new(Constants.By, user)]);

    public JqlChange<T> By(params UserExpression[] users) => By(new JqlCollection<UserExpression>(users));
    
    public JqlChange<T> By(IJqlCollection<UserExpression> users) => new([..Operators, new(Constants.By, users)]);    

    public JqlChange<T> By(Func<JqlNoValues, JqlValue> selector) => new([..Operators, new(Constants.By, selector(new()))]);
}
