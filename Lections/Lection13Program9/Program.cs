namespace Lection13Program9;

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

    static void Main(string[] args)
    {
        int[] ints = new int[1000000000];
        int total = 0;

        var r = new Random();

        for (int i = 0; i < 1000000000; i++)
        {
            ints[i] = r.Next(100000000, 1000000000);
        }

        var res = Parallel.For(0, 1000000000, (i,state) => {

            bool isPrime = IsPrime(ints[i]);

            if (isPrime)
            {
                if (Interlocked.Increment(ref total) < 6)
                {
                    Console.WriteLine(ints[i]);
                }
                else
                    state.Break();
            }
        });

        if(res.IsCompleted == false)
            Console.WriteLine("5 простых чисел были найдены");
    }
}

