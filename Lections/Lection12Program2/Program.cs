namespace Lection12Program1;
class Program
{
    static Mutex mtx;

    static void Print()
    {
        try
        {
            mtx.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}:{i}");
            }
        }
        finally
        {
            mtx.ReleaseMutex();
        }

    }

    static void Main(string[] args)
    {
        mtx = new Mutex(true);
        Console.WriteLine("Мьютекс создан и контроль над ним получен.");

        for (int i = 0; i < 10; i++)
        {
            var t = new Thread(Print);
            t.Name = $"Thread {i}";
            t.Start();
        }

        Thread.Sleep(2000);
        mtx.ReleaseMutex();
        Console.WriteLine("После 2х секундного ожидания, освобождаем мьютекс.");
    }
}

