namespace Lection14Program11;
using System;

interface ISubject
{
    void Request();
}

class RealClass : ISubject
{
    public void Request()
    {
        Console.WriteLine("RealClass отрабатывает запрос");
    }
}

class Proxy : ISubject
{
    private RealClass realSubject;

    public Proxy()
    {
        realSubject = new RealClass();
    }

    public void Request()
    {
        Console.WriteLine("Proxy получает запрос");
        realSubject.Request();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Proxy proxy = new Proxy();
        proxy.Request();
    }
}

