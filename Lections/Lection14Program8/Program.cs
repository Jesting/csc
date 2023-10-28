namespace Lection14Program8;

using System;

interface IComponent
{
    void Operation();
}

class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Метод компонента вызван");
    }
}

abstract class Decorator : IComponent
{
    protected IComponent component;

    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public virtual void Operation()
    {
        component.Operation();
    }
}

class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("Метод декоратора A вызван");
    }
}

class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component)
    {
    }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("Метод декоратора B вызван");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IComponent component = new ConcreteComponent();
        IComponent decoratorA = new ConcreteDecoratorA(component);
        IComponent decoratorB = new ConcreteDecoratorB(decoratorA);

        decoratorB.Operation();
    }
}

