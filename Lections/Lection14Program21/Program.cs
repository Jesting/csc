namespace Lection14Program21;

class Program
{
    static int Power(int x, int power)
    {
        int res = x;

        for (int i = 1; i < power; i++)
        {
            res *= x;
        }
        return res;
    }

    static void Print(int i)
    {
        int i2 = Power(i,2);
        Console.WriteLine($"{i} в степи 2 = {i2}");

        int i3 = Power(i, 3);
        Console.WriteLine($"{i} в степи 3 = {i3}");

        int i4 = Power(i, 3);
        Console.WriteLine($"{i} в степи 4 = {i4}");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Арифметика от 0 до 9");
        for (int i = 0; i < 10; i++)
        {
            Print(i);
        }


        Console.WriteLine("Арифметика от 10 до 20");
        for (int i = 10; i < 20; i++)
        {
            Print(i);
        }
    }


    static void Main1(string[] args)
    {

        Console.WriteLine("Арифметика от 0 до 9");
        for (int i = 0; i < 10; i++)
        {
            int i2 = i * i;
            Console.WriteLine($"{i} в степи 2 = {i2}");

            int i3 = i * i * i;
            Console.WriteLine($"{i} в степи 3 = {i3}");

            int i4 = i * i * i * i;
            Console.WriteLine($"{i} в степи 4 = {i4}");
        }


        Console.WriteLine("Арифметика от 10 до 20");
        for (int i = 10; i < 20; i++)
        {
            int i2 = i * i;
            Console.WriteLine($"{i} в степи 2 = {i2}");

            int i3 = i * i * i;
            Console.WriteLine($"{i} в степи 3 = {i3}");

            int i4 = i * i * i * i;
            Console.WriteLine($"{i} в степи 4 = {i4}");
        }
    }
}

