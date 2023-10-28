namespace Lection5Program1;
class Program
{
    static IEnumerable<int> DataSource()
    {
        for (int i = 0; i < 30; i++)
            yield return i;
    }

    static void Main()
    {
        var q = new Queue<int>();

        foreach (var el in DataSource())
        {
            q.Enqueue(el);
            if (q.Count > 5)
                Console.Write(q.Dequeue() + " ");
        }
    }
}

