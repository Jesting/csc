namespace Lection1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                string name = args[0];
                string message = $"Привет {name}";
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Hello world!");
            }
        }
    }

}

