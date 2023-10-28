namespace Lection13Program3;

class Program
{
    static async Task<int> SomeMethod()
    {
        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("SomeMethod "+i);
            await Task.Delay(100);
        }
        return 42;
    }


    static async Task Main(string[] args)
    {
        Task<int> task = SomeMethod();

        for (int i = 0; i <= 10; i++)
        {
            Console.WriteLine("Main " + i);

            Task.Delay(50).Wait();
        }

        int x = await task;

        Console.WriteLine(x);
    }
}

