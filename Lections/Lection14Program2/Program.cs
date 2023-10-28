using System;
namespace Lection14Program2;


class Prototype:ICloneable 
{
    public string Name { get; set; }
    public List<String> MoreNames { get; set; } = new List<string>();

    public Prototype(string name)
    {
        Name = name;
    }

    public Prototype Clone1()
    {
        var p = new Prototype(Name);

        p.MoreNames = MoreNames;


        return p;
    }

    public void Print()
    {

        Console.WriteLine("Name=" + Name);
        Console.WriteLine("Names:");
        MoreNames.ForEach(Console.WriteLine);

    }

    public object Clone()
    {
        return this.Clone1();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Prototype original = new Prototype("Оригинальный объект") { MoreNames = {"Еще одно имя"} };

        Prototype? clone = (Prototype)original.Clone();


        clone?.Print();
    }
}

