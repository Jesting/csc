
namespace Lection17Program9;

class Program
{
    static void Server()
    {
        using (var publisher = new PublisherSocket())
        {
            publisher.Bind("tcp://127.0.0.1:5556");

            while (true)
            {
                Console.WriteLine("Publishing message to topic1...");
                publisher.SendMoreFrame("topic1").SendFrame("This is a message with topic1");
                Console.WriteLine("Publishing message to topic2...");
                publisher.SendMoreFrame("topic2").SendFrame("This is a message with topic2");
            }
        }
    }

    static void Client(string topicName)
    {
        using (var subscriber = new SubscriberSocket())
        {
            subscriber.Connect("tcp://127.0.0.1:5556");
            subscriber.Subscribe(topicName);

            while (true)
            {
                var topic = subscriber.ReceiveFrameString();
                var message = subscriber.ReceiveFrameString();
                Console.WriteLine($"Received message with topic '{topic}': {message}");
            }
        }
    }

   

    static void Main(string[] args)
    {
        
        Task taskCln1 = Task.Run(() => Client("topic1"));
        Task taskCln2 = Task.Run(() => Client("topic2"));


        Task taskSrv = Task.Run(Server);

        Task.Delay(1000).Wait();

    }
}

