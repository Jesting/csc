
using System.Diagnostics;
using System.Reflection;
namespace Lection17Program5;

class Program
{
    private static string Password {
        get {
                StackTrace stackTrace = new StackTrace();

                foreach (var methodBase in stackTrace.GetFrames())
                {
                    var methodSignature = methodBase.GetMethod().ToString();
                    if (methodSignature.Contains("Reflection"))
                    {
                        throw new Exception("Can't access from reflection");
                    }
                }
                return "MyPassword";

        }  } 

    static void Main(string[] args)
    {
        Assembly assembly = Assembly.LoadFrom("/Users/kirillorlov/csac/L/Lection1/Lection17Library4/bin/Debug/net7.0/Lection17Library4.dll");

        Type programType = assembly.GetType("Lection17Library4.Class1");

        //var obj= Activator.CreateInstance(programType);

        Console.WriteLine(Password);

    }
}




/*

static void RunFromCotext()
{
    AssemblyLoadContext context = new CollectibleAssemblyLoadContext();
    Assembly assembly = context.LoadFromAssemblyPath("/Users/kirillorlov/csac/L/Lection1/Lection17Program5/bin/Debug/net7.0/Lection17Library4.dll");


    System.Type programType = assembly.GetType("Lection17Library4.Class1");
    var eval = System.Activator.CreateInstance(programType);
}


static void RunFromNewDomain()
{
    AppDomain newDomain = AppDomain.CreateDomain("MyNewAppDomain");
    Assembly assembly = newDomain.Load("Lection17Library4.dll");

    Type type = assembly.GetType("Lection17Library4.Class1");
    object obj = Activator.CreateInstance(type);
}

//RunFromNewDomain();
//RunFromCotext();


//Console.WriteLine("попробовали");

///return;*/
///


/*   Assembly assembly = Assembly.LoadFrom("/Users/kirillorlov/csac/L/Lection1/Lection17Library4/bin/Debug/net7.0/Lection17Library4.dll");

        Type? type = assembly.GetType("Lection17Library4.Class1");


        if (type != null)
        {
            object? instance = Activator.CreateInstance(type);

            Console.WriteLine("Выполняем строку после попытки создания класса");

        }
        else
        {
            Console.WriteLine("Класс Class1 не найден");
        }*/