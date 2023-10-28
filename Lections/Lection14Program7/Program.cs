namespace Lection14Program7;
using System;
using System.Collections.Generic;

interface IComponent
{
    int Operation();
}

class Leaf : IComponent
{
    public int Operation()
    {
        return 1;
    }
}

class Composite : IComponent
{
    private List<IComponent> children = new List<IComponent>();

    public void Add(IComponent component)
    {
        children.Add(component);
    }

    public int Operation()
    {
        Console.WriteLine("Операция компоновщика");
        int i = 0;
        foreach (var child in children)
        {
            i+=child.Operation();
        }

        return i;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Composite composite = new Composite();


        IComponent leaf1 = new Leaf();
        composite.Add(leaf1);

        IComponent leaf2 = new Leaf();
        composite.Add(leaf2);

        IComponent component = composite;


        List<IComponent> l = new List<IComponent> { leaf1, leaf2, composite };

        l.ForEach(x => Console.WriteLine(x.Operation()));
    }
}
