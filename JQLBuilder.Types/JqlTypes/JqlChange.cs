namespace JQLBuilder.Types.JqlTypes;

using Infrastructure;
using JQLBuilder.Infrastructure.Abstract;
using JQLBuilder.Infrastructure.Constants;
using Infrastructure.Operators;

class JqlChange<T> : JqlValue
    where T : IJqlType
{
    public JqlChange(IReadOnlyList<ChangeOperator> operators)
    {
        Value = operators;
        Operators = operators;
    }

    IReadOnlyList<ChangeOperator> Operators { get; }

    public JqlChange<T> After(DateTimeExpression value) =>
        new([..Operators, new ChangeOperator(Keywords.After, value)]);

    public JqlChange<T> Before(DateTimeExpression value) =>
        new([..Operators, new ChangeOperator(Keywords.Before, value)]);
    
    public JqlChange<T> On(DateTimeExpression value) =>
        new([..Operators, new ChangeOperator(Keywords.On, value)]);

    public JqlChange<T> During(DateTimeExpression from, DateTimeExpression to) =>
        new([..Operators, new ChangeOperator(Keywords.During, new JqlDateRange<DateTimeExpression>(from, to))]);
    
    public JqlChange<T> From(T value) =>
        new([..Operators, new ChangeOperator(Keywords.From, value)]);
    
    public JqlChange<T> To(T value) =>
        new([..Operators, new ChangeOperator(Keywords.To, value)]);
    
    public JqlChange<T> By(UserExpression user) =>
        new([..Operators, new ChangeOperator(Keywords.By, user)]);

    public JqlChange<T> By(params UserExpression[] users) =>
        By(new JqlCollection<UserExpression>(users));
    
    public JqlChange<T> By(IJqlCollection<UserExpression> users) =>
        new([..Operators, new ChangeOperator(Keywords.By, users)]);    
    
}
