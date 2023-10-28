namespace Lection5Program4;
class Program
{
    static void Main(string[] args)
    {
        var s = "To use or not to use Dictionary";

        int[] count = new int[26];

        foreach(var c in s)
        {
            if (!Char.IsAsciiLetter(c))
                continue;
            var toLower = Char.ToLower(c);

            int pos = ((byte)toLower) - ((byte)'a');

            count[pos]++;
        }

        for (int i=0; i <26; i++)
        {
            if (count[i] > 0)
                Console.WriteLine($"{(char)(i+(byte)'a')}={count[i]}");
        }
    }
}

