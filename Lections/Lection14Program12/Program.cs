namespace Lection14Program12;

using System;

abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(int request);
}

class ConcreteHandlerA : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 0 && request < 10)
        {
            Console.WriteLine($"Запроос {request} обработан  ConcreteHandlerA");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandlerB : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine($"Запроос {request} обработан  ConcreteHandlerB");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class ConcreteHandlerC : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20 && request < 30)
        {
            Console.WriteLine($"Запроос {request} обработан  ConcreteHandlerC");
        }
        else if (successor != null)
        {
            successor.HandleRequest(request);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Handler handlerA = new ConcreteHandlerA();
        Handler handlerB = new ConcreteHandlerB();
        Handler handlerC = new ConcreteHandlerC();

        handlerA.SetSuccessor(handlerB);
        handlerB.SetSuccessor(handlerC);

        int[] requests = { 5, 15, 25 , 99};

        foreach (int request in requests)
        {
            handlerA.HandleRequest(request);
        }
    }
}
