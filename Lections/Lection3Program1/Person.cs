using System;
namespace Lection3Program1
{
    public abstract class Person:IComparable, IParent, IFamily
    {
        public readonly string Name;
        public readonly DateTime Birthday;
        public Person Father = null;
        public Person Mother = null;
        public Person[] Children = null;
        protected abstract string HelloPhrase { get;  set; }
        private IBabySitter BabySitter = null;

        private Person[] Family;
        public int Count { get { return 1 + (Family?.Length ?? 0); } }

        public Person this[int index] {
            get {
                if (index <= 0) return this;
                if (Family is null)
                    return null;
                if (Family.Length >= index)
                    return Family[index-1];
                return null;
            }
        }

        public Person(string name, DateTime birthday)
        {
            Birthday = birthday;
            Name = name;
        }

        public Person(string name)
        {
            Name = name;
            Birthday = DateTime.Now;
        }

        public static bool AreBrothersOrSisters(Person p1, Person p2)
        {
            if(p1.Mother!=null && p2.Mother!=null)
                if (p1.Mother == p2.Mother) return true;
            if (p1.Father != null && p2.Father != null)
                if (p1.Father == p2.Father) return true;
            return false;
        }

        public virtual void SayHello()
        {
            Console.WriteLine("Привет, я человек!");
        }

        public void SayHelloPhrase()
        {
            Console.WriteLine(HelloPhrase);
        }

        public void Print()
        {
            Console.WriteLine($"Имя = {Name}, день рождения = {Birthday.ToString("dd.MM.yyyy")}");
        }

        public bool IsAdult(int adultAge = 18)
        {
            var delta = DateTime.Now.Year - Birthday.Year;

            if (delta > adultAge ||
               (delta == adultAge && DateTime.Now.DayOfYear <= Birthday.DayOfYear))
            {
                return true;
            }
            else
                return false;
        }

        public void AddFamilyInfo(Person father, Person mother, params Person[] children)
        {
            Father = father;
            Mother = mother;
            Children = children;

            int familyCount = 0;

            familyCount += Father == null ? 0 : 1;
            familyCount += Mother == null ? 0 : 1;
            familyCount += Children.Length;


            if (familyCount > 0)
                Family = new Person[familyCount];

            int counter = 0;

            if (father != null)
            {
                Family[counter] = Father;
                counter++;
            }
            if (mother != null)
            {
                Family[counter] = Mother;
                counter++;
            }
            if (Children != null)
            {
                foreach (var child in Children)
                {
                    Family[counter] = child;
                    counter++;
                }
            }
        }

        public void PrinfFamilyInfo()
        {
            if (Father != null)
            {
                Console.Write("Отец: ");
                Father.Print();
            }
            if (Mother != null)
            {
                Console.Write("Мать: ");
                Mother.Print();
            }
            if (Children != null && Children.Length > 0)
            {
                Console.WriteLine("Дети: ");
                foreach (var child in Children)
                {
                    child.Print();
                }
            }
        }

        public void HireBabySitter(IBabySitter babySitter)
        {
            this.BabySitter = babySitter;
        }

        public void UseBabySitter()
        {
            if(BabySitter!=null)
                BabySitter.TakeCare();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return -1;
            return this.Birthday.CompareTo((obj as Person).Birthday);
        }

        public bool GetChildren(out Person[] children)
        {
            if (Children != null && Children.Length != 0)
            {
                children = Children;
                return true;
            }
            else
            {
                children = null;
                return false;
            }
        }

        protected abstract void TakeCareImlementation();

        public void TakeCare()
        {
            if (Children != null)
                TakeCareImlementation();
        }

    }
}

