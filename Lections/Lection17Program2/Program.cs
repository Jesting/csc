using System.Reflection;

namespace Lection17Program2;

class Program
{
    static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom("Lection17Library1.dll");

        Type? type = assembly.GetType("Fibonacci");


        if (type != null)
        {
            object? instance = Activator.CreateInstance(type);

            MethodInfo? method = type.GetMethod("Calculate");

            var res = method?.Invoke(instance, new object[] { 6 });
            
            Console.WriteLine(res);
        }
        else
        {
            Console.WriteLine("Класс Fibonacci не найден");
        }

    }
}
