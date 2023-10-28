namespace Lection13Program13;

class Program
{
    public static async IAsyncEnumerable<int> AsyncNumbers(List<int> numbers)
    {
        foreach (int number in numbers)
        {
            await Task.Delay(100);
            yield return number;
        }

    }

    public static async Task Main()
    {
        List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        await foreach (int number in AsyncNumbers(numbers))
        {
            Console.WriteLine(number);
        }
    }
}

