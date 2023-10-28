namespace Lection12Program7;
class Program
{
    static Semaphore semaphore = new Semaphore(2, 2);

    static void ThreadProc(int x)
    {
        semaphore.WaitOne();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(x);   
            Thread.Sleep(200);
        }
        semaphore.Release();
    }

    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            int x = i;

            new Thread(() => { ThreadProc(x); }).Start();
        }
    }
}

