using System.Net.Sockets;
using System.Text;

namespace Lection11Program5;
class Program
{
    static void Main(string[] args)
    {
        var listener = new TcpListener(System.Net.IPAddress.Any,12345);
        
        listener.Start();

        using (TcpClient client = listener.AcceptTcpClient())
        {
            Console.WriteLine("Connected");

            var reader = new StreamReader(client.GetStream());
            var writer = new StreamWriter(client.GetStream());
            
            var s = reader.ReadLine();
            Console.WriteLine(s);
                
            var r = new String(s.Reverse().ToArray());
            writer.WriteLine(r);

            writer.Flush();
        }
    }
}

