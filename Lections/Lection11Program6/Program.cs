using System.Net.Sockets;
using System.Text;

namespace Lection11Program6;
class Program
{
    static void Main(string[] args)
    {
        using (TcpClient client = new TcpClient())
        {
            Console.WriteLine($"Connecting...");
            
            client.Connect(System.Net.IPAddress.Parse("127.0.0.1"), 12345);

            Console.WriteLine($"Connected");

            var writer = new StreamWriter(client.GetStream());
            var reader = new StreamReader(client.GetStream());

            writer.WriteLine("Привет!");
            writer.Flush();
                
            var s = reader.ReadLine();
            Console.WriteLine(s);
        };
    }
}

