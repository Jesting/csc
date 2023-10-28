namespace Lection12Program1;
class Program
{
    static object lockObj = new object();

    static void Print()
    {
        lock (lockObj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}:{i}");
            }
        }
    }

    static void Main(string[] args)
    {

        for(int i = 0; i<10; i++)
        {
            var t = new Thread(Print);
            t.Name = $"Thread {i}";
            t.Start();
        }
    }
}

