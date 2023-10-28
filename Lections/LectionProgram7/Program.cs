namespace LectionProgram7;

// Абстракция
abstract class Abstraction
{
    protected IImplementor implementor;

    public Abstraction(IImplementor implementor)
    {
        this.implementor = implementor;
    }

    public abstract void Operation();
}

// Конкретная абстракция A
class ConcreteAbstractionA : Abstraction
{
    public ConcreteAbstractionA(IImplementor implementor) : base(implementor)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("Конкретная абстракция A:");
        implementor.OperationImpl();
    }
}

// Конкретная абстракция B
class ConcreteAbstractionB : Abstraction
{
    public ConcreteAbstractionB(IImplementor implementor) : base(implementor)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("Конкретная абстракция B:");
        implementor.OperationImpl();
    }
}

// Интерфейс реализации
interface IImplementor
{
    void OperationImpl();
}

// Конкретная реализация A
class ConcreteImplementorA : IImplementor
{
    public void OperationImpl()
    {
        Console.WriteLine("Конкретная реализация A");
    }
}

// Конкретная реализация B
class ConcreteImplementorB : IImplementor
{
    public void OperationImpl()
    {
        Console.WriteLine("Конкретная реализация B");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Abstraction abstractionA = new ConcreteAbstractionA(new ConcreteImplementorA());
        Abstraction abstractionB = new ConcreteAbstractionB(new ConcreteImplementorB());

        abstractionA.Operation();
        abstractionB.Operation();
    }
}


