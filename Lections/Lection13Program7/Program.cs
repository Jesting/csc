namespace Lection13Program7;

class Program
{
    static async Task TaskProc()
    {
        Console.WriteLine("TaskProc = "+Thread.CurrentThread.ManagedThreadId);

        await Task.Delay(100);

        Console.WriteLine("TaskProc = " + Thread.CurrentThread.ManagedThreadId);
    }


    static async Task Main(string[] args)
    {
        Console.WriteLine("Main = "+Thread.CurrentThread.ManagedThreadId);

        await TaskProc().ConfigureAwait(true);

        Console.WriteLine("Main = " + Thread.CurrentThread.ManagedThreadId);
    }
}

