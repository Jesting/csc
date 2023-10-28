namespace Lection2Program1;
class Program
{
    static int Fibonacсi(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 1;

        return Fibonacсi(n - 1) + Fibonacсi(n - 2);
    }


    static void Main(string[] args)
    {
        //Первые 8 чисел Фибоначи
        //1 1 2 3 5 8 13 21
        Console.WriteLine(Fibonacсi(8));
    }
}

