namespace Lection14Program14;

using System;

abstract class Expression
{
    public abstract bool Interpret(string context);
}

class TerminalExpression : Expression
{
    private string data;

    public TerminalExpression(string data)
    {
        this.data = data;
    }

    public override bool Interpret(string context)
    {
        return context.Contains(data);
    }
}

class AndExpression : Expression
{
    private Expression expr1;
    private Expression expr2;

    public AndExpression(Expression expr1, Expression expr2)
    {
        this.expr1 = expr1;
        this.expr2 = expr2;
    }

    public override bool Interpret(string context)
    {
        return expr1.Interpret(context) && expr2.Interpret(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Expression person = new TerminalExpression("Миша");
        
        Expression married = new TerminalExpression("женат");
        Expression isMarried = new AndExpression(person, married);
        
        Console.WriteLine("Миша женат?: " + isMarried.Interpret("Миша женат!"));
        Console.WriteLine("Миша женат?: " + isMarried.Interpret("Миша разведен?"));

    }
}
