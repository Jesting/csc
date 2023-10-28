namespace Lection6Program1;

public class SensorEventArgs : EventArgs
{
    public int Data { get; init; }
}

public delegate void SensorEventHandler<in T>(object sender, T args);

class Sensor
{
    public int SensorNum { get; init; }
    public event SensorEventHandler<SensorEventArgs> SensorEvent;

    public Sensor(int num) => SensorNum = num;

    protected void OnSensorEvent(SensorEventArgs args)
    {
        SensorEvent?.Invoke(this, args);
    }

    public void DoSomeWork()
    {
        new Thread(() =>
        {
            var time = new Random().Next(5000);
            Thread.Sleep(time);
            OnSensorEvent(new SensorEventArgs { Data = time });
        }).Start();
    }
}

class Program
{
    private static void All_Event(object sender, EventArgs args)
    {
        Console.WriteLine($"Объект {sender} прислал событие {args}");
    }

    static void Main()
    {

        for (int i = 0; i < 10; i++)
        {
            var sensor = new Sensor(i);
            sensor.SensorEvent += All_Event;
            sensor.DoSomeWork();
        }
        Console.WriteLine("Ждем событий.");
    }
}


