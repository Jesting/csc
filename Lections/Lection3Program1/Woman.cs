using System;
namespace Lection3Program1
{
    class Woman : Person, IBabySitter
    {
        public bool HasMakeup { get; private set; } = false;
        protected override string HelloPhrase { get; set; } = "Ура, я женщина!";

        public Woman(string name) : base(name)
        {
        }

        public Woman(string name, DateTime birthday) : base(name, birthday)
        {
        }

        public sealed override void SayHello()
        {
            Console.WriteLine("Ура, я женщина!");
        }

        public void PutMakeupOn()
        {
            Console.WriteLine("Наносит макияж");
            this.HasMakeup = true;
        }

        public void RemoveMakeup()
        {
            Console.WriteLine("Удаляет макияж");
            this.HasMakeup = false;
        }

        protected override void TakeCareImlementation()
        {
            if (this.Children != null)
                Console.WriteLine("Кормит ужином и укладывает спать.");
        }

        void IBabySitter.TakeCare()
        {
            Console.WriteLine("Сидит с детьми пока родители на работе.");
        }

    }
}

