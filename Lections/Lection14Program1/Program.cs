namespace Lection14Program1;

public class Singleton
{
    public static readonly Singleton Instance = new Singleton();

    private Singleton()
    {
    }
    public void DoSomeWork() => Console.WriteLine("Work");
}

class Program
{
    static void Main(string[] args)
    {
        var x = Singleton.Instance;


        x.DoSomeWork();
    }
}

