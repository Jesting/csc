using NetMQ;
using NetMQ.Sockets;

namespace Lection17Program6;

class Program
{

    static void Client()
    {
        using (var client = new RequestSocket())
        {
            client.Connect("tcp://127.0.0.1:5556");
            client.SendFrame("Привет от клиента!");

            Console.WriteLine("Отправленно");

            var msg = client.ReceiveFrameString();
            Console.WriteLine("From Server: {0}", msg);
            while (client.HasIn)
            {
                msg = client.ReceiveFrameString();
                Console.WriteLine("From Server: {0}", msg);
            }
            
        }
    }

    static void Server()
    {
        using (var server = new ResponseSocket())
        {
            server.Bind("tcp://*:5556");
            string msg = server.ReceiveFrameString();
            Console.WriteLine("From Client: {0}", msg);
            server.SendMoreFrame("Привет от").SendFrame("Сервера");
        }
    }

    static void Main(string[] args)
    {
        Task taskCln = Task.Run(Client);

        Task.Delay(1000).Wait();

        Console.WriteLine("Стартуем сервер");

        Task taskSrv = Task.Run(Server);

        Task.WaitAll(taskSrv, taskCln);

    }
}

