using Autofac;

namespace Lection19Program0;


public interface ISingleService
{
    public int Variable { get; set; }
}

public class SingleService:ISingleService
{
    public int Variable { get; set; } = 0;
}


public interface IWriter
{
    public void Write(string s);
}

public interface ILogger
{
    public void Log(string s);
}

public class ConsoleWriter : IWriter
{
    public void Write(string s)
    {
        Console.WriteLine(s);
    }
}

public class FileWriter : IWriter
{
    private string fileName;
    public FileWriter(string fName)
    {
        fileName = fName;
    }

    public void Write(string s)
    {
        Console.WriteLine($"Writing to file {fileName}, $s");
        
    }
}

public class Logger : ILogger
{
    IWriter writer;
    public Logger(IWriter w)
    {
        writer = w;
    }
    public void Log(string s)
    {
        writer.Write($"[{DateTime.Now.ToString()}]:{s}");
    }
}


class Program
{
    static void Main(string[] args)
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<SingleService>().AsSelf().SingleInstance();

        var container = builder.Build();

        var service1 = container.Resolve<SingleService>();

        Console.WriteLine($"ISingleService instance 1 resolved, hashсode = {service1.GetHashCode()}, value = {service1.Variable}");

        service1.Variable++;

        var service2 = container.Resolve<SingleService>();

        Console.WriteLine($"ISingleService instance 2 resolved, hashсode = {service2.GetHashCode()}, value = {service2.Variable}");
    }
}



/*
        builder.RegisterType<SingleService>().AsSelf().AsImplementedInterfaces().SingleInstance();
*/