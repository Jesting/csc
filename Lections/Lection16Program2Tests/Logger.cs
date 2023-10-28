public class Logger
{
    private readonly ILogWriter _logWriter;

    public Logger(ILogWriter logWriter)
    {
        _logWriter = logWriter;
    }

    public void LogMessage(string message)
    {
        _logWriter.Write(message);
    }
}

public interface ILogWriter
{
    void Write(string message);
}