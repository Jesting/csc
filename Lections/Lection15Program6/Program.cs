using Lection15Program6.Model;

namespace Lection15Program6;

class Program
{
    static void Main(string[] args)
    {
        using (var ctx = new TestContext())
        {
            var users = ctx.Users.Where(x => x.GenderId == GenderId.Female);

            foreach (var u in users)
            {
                Console.WriteLine(u.Name);
            }
        }

    }
}







/*
 *  static void ExceptionMethod()
    {
        throw new Exception("Упс, что-то случилось....");
    }
 * 
 * using (var dbContextTransaction = ctx.Database.BeginTransaction())
            {
                var user = new User() { Name = "Коля", GenderId = GenderId.Male };

                ctx.Users.Add(user);

                int changes = ctx.SaveChanges();

                Console.WriteLine($"Было изменено {changes} записей, User.id = {user.Id}");

                ExceptionMethod();

                if (user.Id % 2 == 0)
                {
                    user.Messages.Add(new Message() { Message1 = "Я четный!" });
                }
                else
                {
                    user.Messages.Add(new Message() { Message1 = "Я нечетный!" });
                }

                changes = ctx.SaveChanges();
                Console.WriteLine($"Было изменено {changes} записей, User.id = {user.Id}");

                changes = ctx.SaveChanges();

                Console.WriteLine($"Было изменено {changes} записей, User.id = {user.Id}");

                dbContextTransaction.Commit();
            }*/


/*
            var user = new User() { Name = "Даша", GenderId = GenderId.Female };

            ctx.Users.Add(user);
            
            int changes = ctx.SaveChanges();

            Console.WriteLine($"Было изменено {changes} записей, User.id = {user.Id}");

            if (user.Id % 2 == 0)
            {
                user.Messages.Add(new Message() { Message1 = "Я четный!" });
            }
            else
            {
                user.Messages.Add(new Message() { Message1 = "Я нечетный!" });
            }

            changes = ctx.SaveChanges();
            Console.WriteLine($"Было изменено {changes} записей, User.id = {user.Id}");*/


/*var user1 = new User() { Name = "Саша", GenderId = GenderId.Male };
            var user2 = new User() { Name = "Маша", GenderId = GenderId.Female };

            ctx.Users.Add(user1);
            ctx.Users.Add(user2);

            user1.Messages.Add(new Message() { Message1 = "Привет я Саша!"});
            user2.Messages.Add(new Message() { Message1 = "Привет я Маша!" });

            int changes = ctx.SaveChanges();

            Console.WriteLine($"Было изменено {changes} записей.");*/