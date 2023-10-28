namespace Lection14Program16;
using System;

class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

class Originator
{
    private string state;

    public string State
    {
        get { return state; }
        set
        {
            state = value;
            Console.WriteLine($"Состояние установлено: {state}");
        }
    }

    public Memento CreateMemento()
    {
        return new Memento(state);
    }

    public void RestoreMemento(Memento memento)
    {
        State = memento.State;
    }
}

class Caretaker
{
    public Memento Memento { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        originator.State = "Состояние 1";

        Caretaker caretaker = new Caretaker();
        caretaker.Memento = originator.CreateMemento();

        originator.State = "Состояние 2";

        Console.WriteLine($"Текущене состояние: {originator.State}");

        originator.RestoreMemento(caretaker.Memento);

        Console.WriteLine($"Востановленное состояние: {originator.State}");
    }
}
