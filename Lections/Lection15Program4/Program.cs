using Lection15Program4.DB;
using Microsoft.EntityFrameworkCore;

namespace Lection15Program4;

class Program
{
    static void Main(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>()
             .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test").UseLazyLoadingProxies();

        using (var ctx = new TestDbContext(optionsBuilder.Options))
        {
            var user = ctx.Users.FirstOrDefault(x => x.Name == "Коля");

            if (user != null)
            {
                user.Name = "Николай";
                user.Messages.Clear();
                user.Messages.Add(new Message { MessageContent = "Здраствуйте." });
            }

            int changes = ctx.SaveChanges();

            Console.WriteLine($"Было изменено {changes} записей.");
        };
    }
}

