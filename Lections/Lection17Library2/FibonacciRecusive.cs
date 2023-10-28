using Lection17Interface1;

namespace Lection17Library2;

public class FibonacciRecursive : IFibonacci
{
    public int Calculate(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

        if (number > 46)
            throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

        if (number == 1)
            return 1;

        if (number == 2)
            return 1;

        return Calculate(number - 1) + Calculate(number - 2);

    }
}

