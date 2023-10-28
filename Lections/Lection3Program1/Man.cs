using System;
namespace Lection3Program1
{
    sealed class Man : Person
    {
        public bool HasBeard { get; private set; } = true;
        protected override string HelloPhrase { get; set; } = "Привет, я мужчина!";

        public Man(string name) : base(name)
        {
        }

        public Man(string name, DateTime birthday) : base(name, birthday)
        {
        }

        public override void SayHello()
        {
            Console.WriteLine("Привет, я мужчина!");
        }

        public void SayHelloLikeAParent()
        {
            base.SayHello();
        }

        public void Shave()
        {
            Console.WriteLine("Бреется");   
            this.HasBeard = false;
        }

        new public void Print()
        {
            Console.WriteLine($"Имя = {Name}, день рождения = {Birthday.ToString("dd.MM.yyyy")}(Метод класса Man)");
        }

        protected override void TakeCareImlementation()
        {
            if(this.Children!=null)
                Console.WriteLine("Проверяет уроки и потом идет с детьми на прогулку.");
        }

    }
}

