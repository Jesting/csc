namespace Lection14Program4;

interface IButton
{
    void Display();
}

interface ITextBox
{
    void Display();
}

class WindowsButton : IButton
{
    public void Display()
    {
        Console.WriteLine("Отображаем кнопку Windows");
    }
}

class WindowsTextBox : ITextBox
{
    public void Display()
    {
        Console.WriteLine("Отображаем окно ввода Windows");
    }
}

class MacOSButton : IButton
{
    public void Display()
    {
        Console.WriteLine("Отображаем кнопку MacOS");
    }
}

class MacOSTextBox : ITextBox
{
    public void Display()
    {
        Console.WriteLine("Отображаем окно ввода MacOS");
    }
}

interface IControlsFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}


class WindowsControlsFactory : IControlsFactory
{
    public IButton CreateButton() => new WindowsButton();
    public ITextBox CreateTextBox() => new WindowsTextBox();
}

class MacOSControlsFactory : IControlsFactory
{
    public IButton CreateButton() => new MacOSButton();
    public ITextBox CreateTextBox() => new MacOSTextBox();
}

class Program
{
    static void Main(string[] args)
    {
        bool osWindows = true;

        IControlsFactory factory = null;
        if (osWindows)
        {

            factory = new WindowsControlsFactory();
          
        }
        else
        {
            factory = new MacOSControlsFactory();
           
        }

        IButton button = factory.CreateButton();
        ITextBox textBox = factory.CreateTextBox();

        button.Display();
        textBox.Display();


    }
}
