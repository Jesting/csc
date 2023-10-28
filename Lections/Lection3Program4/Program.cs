namespace Lection3Program4;
class Program
{
    class Fibonacci
    {
        public int Value { get; private set; } = 1;
        private int valuePrev = 0;

        public static Fibonacci operator ++(Fibonacci f)
        {
            var temp = f.Value;
            f.Value = f.Value + f.valuePrev;
            f.valuePrev = temp;

            return f;
        }

        public static Fibonacci operator +(Fibonacci f, int count)
        {
            for (int i = 0; i < count; i++)
            {
                f++;
            }
            return f;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    static void Main(string[] args)
    {
        var a = new Fibonacci();

        a = a + 7;

        Console.WriteLine(a);
    }
}

