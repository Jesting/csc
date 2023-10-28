namespace Lection8Program1;
class Program
{
    static T Create<T>()
    {
        T obj = Activator.CreateInstance<T>();

        if (obj == null)
            throw new Exception("Не удалось создать класс");

        Type type = obj.GetType();

        var methods = type.GetMethods(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

        foreach (var m in methods)
        {
            var attributes = m.GetCustomAttributes(false);

            foreach (var attribute in attributes)
            {
                if (attribute is InvokeAfterCreationAttribute)
                {
                    InvokeAfterCreationAttribute? attr = attribute as InvokeAfterCreationAttribute;

                    m.Invoke(obj, new Object[] { attr.Value });
                }    
                    
            }
        }

        return obj;
    }

    static void Main(string[] args)
    {
        Create<SomeClass>();
    }
}

