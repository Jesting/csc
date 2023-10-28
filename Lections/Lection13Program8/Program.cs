using System.Collections.Generic;

namespace Lection13Program8;

class Program
{
    static async Task Main(string[] args)
    {
        List<int> list = Enumerable.Range(0, 100).ToList();
        
        ParallelLoopResult res = Parallel.ForEach<int>(list, x => Console.WriteLine(x));
    }   
}

