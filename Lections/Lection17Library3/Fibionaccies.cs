
using Lection11Interface2;
using Lection17Interface1;

namespace Lection17Library3;

public class FeatureDescription : IFeatureDescription
{
    private string featureDescription;
    private Type featureType;

    public FeatureDescription(string description, Type type)
    {
        this.featureDescription = description;
        this.featureType = type;
    }

    public string GetFeatureDescription()
    {
        return featureDescription;
    }

    public Type GetFeatureInterface()
    {
        return typeof(IFibonacci);
    }

    public Type GetFeatureType()
    {
        return featureType;
    }
}

public class PluginInfo : IPluginInfo
{

    public List<IFeatureDescription> Features => new List<IFeatureDescription>{
        new FeatureDescription("Фибоначчи итаративный", typeof(Fibonacci)),
        new FeatureDescription("Фибоначчи рекурсивный", typeof(FibonacciRecursive)),
    };
}



public class Fibonacci : IFibonacci
{
    public int Calculate(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

        if (number > 46)
            throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

        int first = 1, second = 1;

        for (int i = 2; i <= number; i++)
        {
            int temp = first;
            first = second;
            second = first + temp;
        }

        return first;
    }

}


public class FibonacciRecursive : IFibonacci
{
    public int Calculate(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

        if (number > 46)
            throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

        if (number == 1)
            return 1;

        if (number == 2)
            return 1;

        return Calculate(number - 1) + Calculate(number - 2);

    }
}

