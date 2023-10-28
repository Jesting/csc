namespace Lection13Program11;

class Program
{
    static void Main(string[] args)
    {
        Parallel.Invoke(
            new Action[]{
                ()=>{Thread.Sleep(100); Console.WriteLine(1); },
                ()=>{Thread.Sleep(100); Console.WriteLine(2); },
                ()=>{Thread.Sleep(100); Console.WriteLine(3); },
                ()=>{Thread.Sleep(100); Console.WriteLine(4); },
                ()=>{Thread.Sleep(100); Console.WriteLine(5); },
                ()=>{Thread.Sleep(100); Console.WriteLine(6); },
                ()=>{Thread.Sleep(100); Console.WriteLine(7); },
                ()=>{Thread.Sleep(100); Console.WriteLine(8); },
                ()=>{Thread.Sleep(100); Console.WriteLine(9); },
                ()=>{Thread.Sleep(100); Console.WriteLine(10); },
            });
    }
}

