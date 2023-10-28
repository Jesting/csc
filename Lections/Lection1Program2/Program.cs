namespace Lection1
{
    internal class Program
    {
        static int DivideTwoNumbers(int n1, int n2)
        {
            int res = n1 / n2;
            return res;
        }

        static void Main(string[] args)
        {
            int resultOfDivision = DivideTwoNumbers(1, 0);

            Console.WriteLine($"Result = ${resultOfDivision}");
        }
    }

}

