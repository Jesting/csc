namespace Lection14Program6;

using System;

class LegacyLibrary
{
    public void SpecificRequest()
    {
        Console.WriteLine("Я стар. Но все еще нужен!");
    }
}

interface ITarget
{
    void Request();
}

class Adapter : ITarget
{
    private LegacyLibrary legacyLibrary;

    public Adapter(LegacyLibrary legacyLibrary)
    {
        this.legacyLibrary = legacyLibrary;
    }

    public void Request()
    {
        legacyLibrary.SpecificRequest();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LegacyLibrary legacyLibrary = new LegacyLibrary();

        ITarget target = new Adapter(legacyLibrary);

        target.Request(); 
    }
}