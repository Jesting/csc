using Lection15Program2.DB;
using Microsoft.EntityFrameworkCore;

namespace Lection15Program2;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>()
             .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test").UseLazyLoadingProxies();

        using (var ctx = new TestDbContext(optionsBuilder.Options))
        {
            var users = ctx.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Имя {user.Name}");
                Console.WriteLine("________Сообщения:");

                var messages = user.Messages;
                foreach (var message in messages)
                {
                    Console.WriteLine($"________:{message.MessageContent}");
                }
            }
            
        };
    }
}

