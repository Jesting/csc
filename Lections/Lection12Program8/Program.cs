namespace Lection12Program8;

class Program
{
    static int x = 0;


    static void Increment()
    {
        for (int i = 0; i < 100000; i++)
        {
            Interlocked.Increment(ref x);
        }
    }
    static void Decrement()
    {
        for (int i = 0; i < 100000; i++)
        {
            Interlocked.Decrement(ref x);
        }
    }
    static void Main(string[] args)
    {

        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
                new Thread(Increment).Start();
            else
                new Thread(Decrement).Start();
        }

        Thread.Sleep(2000);

        Console.WriteLine(x);
    }
}

