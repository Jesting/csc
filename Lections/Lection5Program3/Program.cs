using System.Text;

namespace Lection5Program3;
class Program
{
    static void Main(string[] args)
    {
        var s = "Тект с повторяющимися повторяющимися повторяющимися словами. Выведи количество повторов вместе со словами";

        StringBuilder sb = new StringBuilder();
        Dictionary<string, int> count = new Dictionary<string, int>();

        foreach(var c in s)
        {
            if (" ,.-".Contains(c))
            {
                if (sb.Length > 0)
                {
                    if (count.ContainsKey(sb.ToString()))
                    {
                        count[sb.ToString()]++;
                    }
                    else
                        count[sb.ToString()] = 1;
                    sb.Clear();
                }
            }
            else
                sb.Append(c);
        }
        if (count.ContainsKey(sb.ToString()))
        {
            count[sb.ToString()]++;
        }
        else
            count[sb.ToString()] = 1;


        foreach (var pair in count)
        {
            Console.WriteLine($"Слово '{pair.Key}' повторяется {pair.Value} раз");
        }

    }
}

