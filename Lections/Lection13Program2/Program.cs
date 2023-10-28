namespace Lection13Program2;

class Program
{
    static byte[] GenerateNumbers()
    {
        var rand = new Random();

        byte[] b = new byte[100];

        rand.NextBytes(b);

        return b;
    }

    static int FindMinimum(Task<byte[]> task)
    {
        var b = task.Result;

        var min = b[0];

        foreach (var x in b)
        {
            if (x < min)
                min = x;
        }
        return min;
    }

    static async Task Main(string[] args)
    {
        var task = new Task<byte[]>(GenerateNumbers);

        var task2 = task.ContinueWith<int>((x) => { return FindMinimum(x); });

        task.Start();

        task2.Wait();

        var res = task2.Result;

        Console.WriteLine("Минимум = "+res);
    }
}


