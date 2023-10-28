namespace Lection13Program10;

class Program
{
    static bool IsPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;

        var limit = Math.Ceiling(Math.Sqrt(number));

        for (int i = 2; i <= limit; ++i)
            if (number % i == 0)
                return false;
        return true;
    }

    static async Task Main(string[] args)
    {
        int[] ints = new int[1000000000];
        int total = 0;

        var r = new Random();

        for (int i = 0; i < 1000000000; i++)
        {
            ints[i] = r.Next(100000000, 1000000000);
        }

        CancellationTokenSource cts = new CancellationTokenSource();

        var task = Parallel.ForEachAsync(ints,cts.Token, (i, ct) => {

            bool isPrime = IsPrime(i);

            if (isPrime)
            {
                Interlocked.Increment(ref total);
                
                Console.WriteLine(i);
            }
            return ValueTask.CompletedTask;
        });

        Console.WriteLine("Ждем 5 секунд");
        await Task.Delay(5000);

        Console.WriteLine("Отменяем задачу");
        cts.Cancel();

        try
        {
            await task;
        }
        catch
        {
        }
        Console.WriteLine("За 5 секунда было найдено " +total+" случайных простых чисел.");
    }
}

