namespace Lection12Program5;
class Program
{
    static AutoResetEvent ar1 = new AutoResetEvent(false);
    static AutoResetEvent ar2 = new AutoResetEvent(false);


    static void Main(string[] args)
    {
        new Thread(() => {
            Console.WriteLine("Ждем сигнального состояния");
            ar1.WaitOne();
            Thread.Sleep(2000);
            Console.WriteLine("Поток 1 завершился");
            ar2.Set();

        }).Start();

        Thread.Sleep(1000);
        AutoResetEvent.SignalAndWait(ar1,ar2);

        Console.WriteLine("Один из потоков завершился");
    }
}

