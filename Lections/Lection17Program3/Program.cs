using System.Reflection;
using Lection17Interface1;

namespace Lection17Program3;


class Program
{
    static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom("Lection17Library2.dll");
        
        Type[] types = assembly.GetTypes();

        Type interfaceType = typeof(IFibonacci);

        Type? type = null;

        foreach (Type foundType in types)
        {
            if (interfaceType.IsAssignableFrom(foundType))
            {
                Console.WriteLine($"{foundType.Name} поддерживает интерфейс IMyInterface");
                type = foundType;
                break;
            }
        }

        if (type != null)
        {

            IFibonacci? fib = Activator.CreateInstance(type) as IFibonacci;

            if (fib != null)
            {
                var res = fib?.Calculate(7);

                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("Класс Fibonacci найден, но не соответствует интерфейсуч IFibonacci");

            }
        }
        else
        {
            Console.WriteLine("Класс Fibonacci не найден");
        }

    }
}
