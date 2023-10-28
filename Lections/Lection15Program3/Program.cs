using Lection15Program3.DB;
using Microsoft.EntityFrameworkCore;

namespace Lection15Program3;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>()
             .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test").UseLazyLoadingProxies();

        using (var ctx = new TestDbContext(optionsBuilder.Options))
        {
            var user = new User();
            user.Name = "Коля";
            user.Messages = new HashSet<Message>();
            user.Messages.Add(new Message { MessageContent = "Привет!" });
            user.Messages.Add(new Message { MessageContent = "Я Коля!" });

            ctx.Add(user);

            int changes = ctx.SaveChanges();

            Console.WriteLine($"Было сделано {changes} записей.");
        };
    }
}
