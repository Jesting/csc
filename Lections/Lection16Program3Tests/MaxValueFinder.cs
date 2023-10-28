public class MaxValueFinder
{
    public static int FindMaxValue(int[] numbers)
    {
        if (numbers.Length == 0)
        {
            throw new InvalidOperationException("The array is empty.");
        }

        int maxValue = numbers[0];
        foreach (int number in numbers)
        {
            if (number > maxValue)
            {
                maxValue = number;
            }
        }

        return maxValue;
    }
}