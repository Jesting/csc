namespace Lection13Program1;
class Program
{

    static object lockObj = new object();

    static void Print()
    {
        lock (lockObj)
        {
            for (int i = 0; i < 10; i++)
                Console.WriteLine($"{Thread.CurrentThread.GetHashCode()}:{i}");
        }
    }

    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Run(Print));
        }

        //Task.WaitAll(tasks.ToArray());
    }
}


