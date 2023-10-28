using Lection11Interface2;
using Lection17Interface1;
using System.Reflection;

namespace Lection17Program4;

class Program
{
    static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom("Lection17Library3.dll");

        Type[] types = assembly.GetTypes();

        Type interfaceType = typeof(IPluginInfo);

        Type? type = null;

        foreach (Type foundType in types)
        {
            if (interfaceType.IsAssignableFrom(foundType))
            {
                Console.WriteLine($"{foundType.Name} поддерживает интерфейс IPluginInfo");
                type = foundType;
                break;
            }
        }

        if (type != null)
        {
            IPluginInfo? pluginInfo = Activator.CreateInstance(type) as IPluginInfo;

            if (pluginInfo == null)
            {
                Console.WriteLine("IPluginInfo не создан, библиотека не является плагином");
                return;
            }

            Console.WriteLine("Найдены следующие классы:");

            int i = 1;
            foreach (var f in pluginInfo.Features)
            {
                Console.WriteLine(i+++":"+f.GetFeatureDescription());
                Console.WriteLine("Выбиерите вариант 1 или 2:");
                
            }
            bool b = int.TryParse(Console.ReadLine(), out int option);

            if (b == false || (option != 1 && option != 2))
            {
                Console.WriteLine("Выбран неверен");
                return;
            }

            Console.WriteLine("Выбран вариант " + option);

            var typeFib =Activator.CreateInstance(pluginInfo.Features[option - 1].GetFeatureType()) as IFibonacci;

            if (typeFib != null)
            {
                Console.WriteLine(typeFib.Calculate(5));
            }


        }
        else
        {
            Console.WriteLine("IPluginInfo не найден, библиотека не является плагином");
            return;
        }



            
    }
}

