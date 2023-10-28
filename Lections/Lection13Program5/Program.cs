namespace Lection13Program5;

class Program
{
    static async ValueTask<int> AsyncMethod()
    {
        return 42;
    }


    static async Task Main(string[] args)
    {
        ValueTask<int> v = AsyncMethod();

        ValueTask<int> task = v.Preserve(); 

        var res = await task + await task;

        Console.WriteLine(res);

    }
}

