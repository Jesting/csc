
using Lection17Interface1;

public class Fibonacci:IFibonacci
 {
    public int Calculate(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

        if (number > 46)
            throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

        int first = 1, second = 1;

        for (int i = 2; i <= number; i++)
        {
            int temp = first;
            first = second;
            second = first + temp;
        }

        return first;
    }

}
