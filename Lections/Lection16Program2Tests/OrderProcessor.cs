namespace Lection16Program2Tests;

public class OrderProcessor
{
    private readonly INotificationService _notificationService;

    public OrderProcessor(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void ProcessOrder(Order order)
    {
       // _notificationService.Notify(order.CustomerEmail, "Ваш заказ обработан.");
    }
}

public class Order
{
    public string CustomerEmail { get; set; }
}

public interface INotificationService
{
    void Notify(string email, string message);
}
