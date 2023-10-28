using System.Reflection;

namespace Lection17Library4;

public class Class1
{
    public Class1()
    {
        Console.WriteLine("Вызван конструктор Class1");

        var t = Assembly.GetEntryAssembly().GetType("Lection17Program5.Program");

        var f = t.GetProperty("Password", BindingFlags.NonPublic | BindingFlags.Static);

        var password = f.GetValue(null);

        Console.WriteLine(password);
        
    }
}

