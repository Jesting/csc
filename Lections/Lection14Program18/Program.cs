namespace Lection14Program18;

using System;

interface IStrategy
{
    void Execute();
}

class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Выполняем статегию A");
    }
}

class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Выполняем статегию B");
    }
}

class ConcreteStrategyC : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Выполняем статегию C");
    }
}


class Context
{
    private IStrategy strategy;

    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        strategy.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new ConcreteStrategyA());

        context.ExecuteStrategy();

        context.SetStrategy(new ConcreteStrategyB());
        context.ExecuteStrategy(); 

        context.SetStrategy(new ConcreteStrategyC());
        context.ExecuteStrategy(); 
    }
}

