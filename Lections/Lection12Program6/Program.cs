namespace Lection12Program6;

class Program
{
    static bool started = true;
    static ManualResetEvent ManualResetEvent = new ManualResetEvent(false);

    static void Thread1Proc()
    {
        var signaled = false;   
        while (started)
        {
            Thread.Sleep(1000);
            if (signaled)
            {
                ManualResetEvent.Reset();
                signaled = false;
            }
            else
            {
                ManualResetEvent.Set();
                signaled = true;
            }
        }
    }

    static void Thread2Proc()
    {
        while (started)
        {
            ManualResetEvent.WaitOne();
            Console.WriteLine("Сигнал!");
            Thread.Sleep(100); 
        }
    }

    static void Main(string[] args)
    {
        new Thread(Thread1Proc).Start();
        new Thread(Thread2Proc).Start();       

        Thread.Sleep(10000);

        started = false;
    }
}

