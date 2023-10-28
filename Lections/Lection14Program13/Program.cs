namespace Lection14Program13;
using System;

interface ICommand
{
    void Execute();
}

class LightOnCommand : ICommand
{
    private Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

class LightOffCommand : ICommand
{
    private Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}


class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Свет включен");
    }

    public void TurnOff()
    {
        Console.WriteLine("Свет выключен");
    }
}

class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void ExecuteButton()
    {
        command.Execute();
    }

    public void SetAndExecuteButton(ICommand command)
    {
        this.SetCommand(command);
        this.ExecuteButton();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Light light = new Light();
        ICommand lightOnCommand = new LightOnCommand(light);
        ICommand lightOffCommand = new LightOffCommand(light);

        RemoteControl remote = new RemoteControl();

        remote.SetAndExecuteButton(lightOnCommand);

        remote.SetAndExecuteButton(lightOffCommand);
        
    }
}

