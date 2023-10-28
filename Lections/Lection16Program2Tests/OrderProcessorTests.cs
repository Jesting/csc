using NUnit.Framework;
using Moq;
using Lection16Program2Tests;


[TestFixture]
public class OrderProcessorTests
{
    [Test]
    public void ProcessOrder_SendsNotificationTests()
    {
        var notificationServiceMock = new Mock<INotificationService>();

        var orderProcessor = new OrderProcessor(notificationServiceMock.Object);
        
        var order = new Order { CustomerEmail = "customer@example.com" };

        orderProcessor.ProcessOrder(order);

        notificationServiceMock.Verify(x => x.Notify("customer@example.com", "Ваш заказ обработан."), Times.Once);
    }
}
