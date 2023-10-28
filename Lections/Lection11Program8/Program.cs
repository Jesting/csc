using System;
using System.Net.NetworkInformation;
using System.Threading;

namespace Lection11Program8;
class Program
{
    static void Main(string[] args)
    {
        var ping = new Ping();


        for (int i = 0; i <= 10; i++)
        {
            PingReply reply = ping.Send("ya.ru", 1000, new byte[64], new PingOptions { Ttl = 52, DontFragment = true });


            if(reply.Status == IPStatus.Success)
                Console.WriteLine($"{reply.Buffer.Length} bytes from {reply.Address}: icmp_seq = {i} ttl = {reply?.Options?.Ttl} time = {reply?.RoundtripTime}");
        }
        
    }
}

    