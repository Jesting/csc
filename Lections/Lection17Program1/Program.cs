using Lection17Interface1;
using Lection17Library2;

namespace Lection17Program1;



class Program
{
    static void Main(string[] args)
    {
        IFibonacci fibonacci = new Fibonacci();
        IFibonacci fibonacciRecursive = new FibonacciRecursive();

        Console.WriteLine(fibonacci.Calculate(5));
        Console.WriteLine(fibonacciRecursive.Calculate(5));
    }
}

