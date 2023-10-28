namespace Lection12Program4;

class Program
{
    static bool started = true;
    static AutoResetEvent autoResetEvent = new AutoResetEvent(false);

    static void Thread1Proc()
    {
        while (started)
        {
            Console.Write("Кто");
            Thread.Sleep(500);
            Console.Write(" мы?");
            Thread.Sleep(500);
            Console.WriteLine();
            autoResetEvent.Set();
            autoResetEvent.WaitOne();
        }
    }

    static void Thread2Proc()
    {
        while (started)
        {
            autoResetEvent.WaitOne();
            Console.WriteLine("Программисты!");
            autoResetEvent.Set();
        }
    }

    static void Main(string[] args)
    {
        new Thread(Thread1Proc).Start();
        new Thread(Thread2Proc).Start();
        new Thread(Thread2Proc).Start();
        new Thread(Thread2Proc).Start();

        Thread.Sleep(10000);

        started = false;
    }
}

