namespace Lection3Program5;
class Program
{
    class Utility
    {
        public static void Swap<T>(ref T v1, ref T v2) 
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }

    static void Main(string[] args)
    {
        int a = 10, b = 20;
        char c1 = 'B', c2 = 'B';
        string s1 = "ABC", s2 = "BCD";

        Utility.Swap<int>(ref a, ref b);

        Console.WriteLine($"a={a}, b = {b}");

        Utility.Swap(ref c1, ref c2);

        Console.WriteLine($"c1={c1}, c2 = {c2}");
        
        Utility.Swap(ref s1, ref s2);

        Console.WriteLine($"c1={s1}, s2 = {s2}");
    }
}

