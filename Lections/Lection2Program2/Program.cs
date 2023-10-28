namespace Lection2Program2;
class Program
{
    static int Fibonacci(int n)
    {
        if (n <= 0)
            return 0;

        int[] numbers = new int[n];

        numbers[0] = 1;
        numbers[1] = 1;

        for (int i = 2; i < n; i++)
        {
            numbers[i] = numbers[i - 1]+ numbers[i - 2];
        }

        return numbers[n - 1];
    }

    static void Main(string[] args)
    {
        //Первые 8 чисел Фибоначи
        //1 1 2 3 5 8 13 21
        Console.WriteLine(Fibonacci(8));
    }
}

