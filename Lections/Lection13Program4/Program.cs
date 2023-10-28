namespace Lection13Program4;

class Program
{
    static async Task<int> Fibonacci(int x)
    {
        return await Task<int>.Run(() => {
            int a = 0, b = 1;

            for(int i = 0; i<x-2; i++)
            {
                int t = b + a;
                a = b;
                b = t;
            }
            return b;

        });
    }

    static async Task Main(string[] args)
    {
        var tx =  Fibonacci(5000);
        var ty = Fibonacci(2000);

        int res = await tx + await ty;

        Console.WriteLine(res);
    }
}

