using System.Diagnostics;

namespace Lection16Program1;

class Program
{
    static void Main(string[] args)
    {

        var arr = new int[] { 9, 1, 2, 9, 0, 1, -1, -1, 8, 2, 4, 5, 6, 7, 8, 4, 43, 6, 7, 8 };



        var sbubble = new Stopwatch();
        sbubble.Start();
        var sort = new BubbleSort();
        for (int i = 0; i < 10000; i++)
        {
            arr = new int[] { 9, 1, 2, 9, 0, 1, -1, -1, 8, 2, 4, 5, 6, 7, 8, 4, 43, 6, 7, 8 };
            sort.Sort(arr);
        }
        sbubble.Stop();


        var sarr = new Stopwatch();
        sarr.Start();
        for (int i = 0; i < 10000; i++)
        {
            arr = new int[] { 9, 1, 2, 9, 0, 1, -1, -1, 8, 2, 4, 5, 6, 7, 8, 4, 43, 6, 7, 8 };
            
            Array.Sort(arr);
        }
        sarr.Stop();


        Console.WriteLine($"Bubble sort = {sbubble.Elapsed.TotalMilliseconds}");
        Console.WriteLine($"Array sort  = {sarr.Elapsed.TotalMilliseconds}");

    }
}




/*var fib = new Fibonacci();


        var siter = new Stopwatch();

        siter.Start();
        for (int i = 1; i <= 46; i++)
        {
            fib.Calculate(i);
        }
        siter.Stop();


        var srec = new Stopwatch();

        srec.Start();
        for (int i = 1; i <= 46; i++)
        {
            fib.CalculateRec(i);
        }
        srec.Stop();


        Console.WriteLine($"Итеративный метод подсчета = {siter.Elapsed.TotalMilliseconds}");
        Console.WriteLine($"Рекурсивный метод подсчета = {srec.Elapsed.TotalMilliseconds}");
*/