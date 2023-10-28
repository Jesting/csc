namespace Lection13Program6;

class DisposableAsync : IDisposable, IAsyncDisposable
{
    private bool disposedValue;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Console.WriteLine("Disposing");
            }
        
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await Task.Delay(100);
        Dispose();
    }
}


class Program
{
    static async Task Example()
    {
        await using (var da = new DisposableAsync())
        await using (var db = new DisposableAsync())
        {
            throw new Exception();
            Console.WriteLine("Используем DisposableAsync");
        }
        Console.WriteLine("Уничтожили DisposableAsync");
    }

    static async Task Main(string[] args)
    {
        Task task = Example();

        Console.WriteLine("Управление вернулось в метод Main");

        await task;
    }
}

