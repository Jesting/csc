public class FactorialCalculator
{
    public static int CalculateFactorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Can't calculate factorial of negative value");
        }
        if (number > 13)
        {
            throw new ArgumentOutOfRangeException("Can't calculate factorial value greatet than 13");
        }
        if (number == 0)
        {
            return 0;
        }
        else
        if (number == 1)
        {
            return 1;
        }
        else
        {
            return number * CalculateFactorial(number - 1);
        }
    }
}