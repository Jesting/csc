using Lection15Program5.Model;
using Microsoft.EntityFrameworkCore;

namespace Lection15Program5;

class Program
{
    static void Main(string[] args)
    {
        using (var ctx = new TestContext())
        {
            var users = ctx.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Имя {user.Name}");
                Console.WriteLine("________Сообщения:");

                var messages = user.Messages.ToList();
                foreach (var message in messages)
                {
                    Console.WriteLine($"________:{message.Message1}");
                }
            }

        }
    }
}

