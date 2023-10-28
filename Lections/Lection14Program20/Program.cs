namespace Lection14Program20;

using System;
using System.Collections.Generic;

interface IElement
{
    void Accept(IVisitor visitor);
}

class ConcreteElementA : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }

    public void OperationA()
    {
        Console.WriteLine("ConcreteElementA Операция A");
    }
}

class ConcreteElementB : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }

    public void OperationB()
    {
        Console.WriteLine("ConcreteElementB Операция B");
    }
}

interface IVisitor
{
    void VisitConcreteElementA(ConcreteElementA elementA);
    void VisitConcreteElementB(ConcreteElementB elementB);
}

class ConcreteVisitor : IVisitor
{
    public void VisitConcreteElementA(ConcreteElementA elementA)
    {
        Console.WriteLine("Посетитель посещает ConcreteElementA");
        elementA.OperationA();
    }

    public void VisitConcreteElementB(ConcreteElementB elementB)
    {
        Console.WriteLine("Посетитель посещает ConcreteElementB");
        elementB.OperationB();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IElement> elements = new List<IElement>
        {
            new ConcreteElementA(),
            new ConcreteElementB()
        };

        ConcreteVisitor visitor = new ConcreteVisitor();

        foreach (IElement element in elements)
        {
            element.Accept(visitor);
        }
    }
}
