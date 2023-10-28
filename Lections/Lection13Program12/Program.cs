namespace Lection13Program12;

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

        for (int i = 0; i < 1000000000; i++)
        {
            ints[i] = 100000000 + i;
        }

        var res = ints.AsParallel().Where(IsPrime).AsSequential().Take(10);

        foreach (var r in res)
        {
            Console.WriteLine(r);
        }

    }
}



