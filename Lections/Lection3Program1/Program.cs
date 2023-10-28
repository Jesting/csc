using System;
namespace Lection3Program1;

class Program
{
    static void Main(string[] args)
    {
        var person1 = new Woman("Анна", DateTime.Parse("01.01.1970"));
        var surname = "Иванова";

        var newObject = new { person1.Name, person1.Birthday, surname};

        Console.WriteLine($"Анонимный тип с заимствованными именами свойств {newObject.Name}, {newObject.Birthday}, {newObject.surname}");
    }
}






/*var woman = new Woman("Анна", DateTime.Parse("01.01.1990"));
        var man = new Man("Алексей", DateTime.Parse("01.01.2000"));


        var mother = new Woman("Татьяна", DateTime.Parse("01.01.1960"));
        woman.AddFamilyInfo(null, mother);
        man.AddFamilyInfo(null, mother);

        Console.WriteLine(Person.AreBrothersOrSisters(woman,man));*/
