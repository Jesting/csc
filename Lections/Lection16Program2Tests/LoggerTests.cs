using NUnit.Framework;
using Moq;

[TestFixture]
public class LoggerTests
{
    [Test]
    public void LogMessage_Calls_WriteOnLogWriter()
    {
        var logWriterMock = new Mock<ILogWriter>();

        var logger = new Logger(logWriterMock.Object);
        
        string capturedMessage = null;
        logWriterMock.Setup(x => x.Write(It.IsAny<string>()))
            .Callback<string>(message => capturedMessage = message);
        
        logger.LogMessage("Test message");
        
        logWriterMock.Verify(x => x.Write(It.IsAny<string>()), Times.Once);

        Assert.AreEqual("[LOGMESSAGE:Test message", capturedMessage);
    }
}
