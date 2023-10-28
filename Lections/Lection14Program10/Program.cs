namespace Lection14Program10;
using System;
using System.Collections.Generic;

interface IFlyweight
{
    void Operation(string extrinsicState);
}

class ConcreteFlyweight : IFlyweight
{
    private string intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    public void Operation(string extrinsicState)
    {
        Console.WriteLine($"Приспособленец: Внутреннее состояние = {intrinsicState}, внешнее состояние = {extrinsicState}");
    }
}

class FlyweightFactory
{
    private Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string key)
    {
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new ConcreteFlyweight(key);
        }
        return flyweights[key];
    }
}

class Program
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();

        IFlyweight flyweight1 = factory.GetFlyweight("SharedStateA");
        IFlyweight flyweight2 = factory.GetFlyweight("SharedStateB");
        IFlyweight flyweight3 = factory.GetFlyweight("SharedStateA");

        flyweight1.Operation("Внешнее состояние 1");
        flyweight2.Operation("Внешнее состояние 2");
        flyweight3.Operation("Внешнее состояние 3");
    }
}
