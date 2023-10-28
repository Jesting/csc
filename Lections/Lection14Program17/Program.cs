namespace Lection14Program17;

using System;

class Context
{
    private IState state;

    public Context(IState initialState)
    {
        state = initialState;
    }

    public void SetState(IState newState)
    {
        state = newState;
    }

    public void Request()
    {
        state.Handle(this);
    }
}

interface IState
{
    void Handle(Context context);
}

class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Обрабатываем запрос в состоянии A");
        context.SetState(new ConcreteStateB());
    }
}

class ConcreteStateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("Обрабатываем запрос в состоянии B");
        context.SetState(new ConcreteStateA());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context(new ConcreteStateA());

        context.Request(); 
        context.Request(); 
        context.Request(); 
    }
}
