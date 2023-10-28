namespace Lection5Program5;
class Program
{
    static void Main(string[] args)
    {
        int[] arr =  new int[]{ -2,10,2,31,4,5,16,7,8,9};
        int target = 29;

        HashSet<int> set = new HashSet<int>();

        foreach(var i in arr)
        {

            if (set.Contains(target - i))
            {
                Console.WriteLine($"Числа = {target - i},{i}");
                return;
            }
            else
            {
                set.Add(i);
            }
        }
        Console.WriteLine("Числа не найдены");
    }
}

