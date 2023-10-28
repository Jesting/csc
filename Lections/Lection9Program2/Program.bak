using System.IO;
using System.Text;

namespace Lection9Program2;
class Program
{
    static DirectoryInfo? GetProjectRoot()
    {
        Stack<string> names = new Stack<string>(new string[] { "bin", "Debug", "net7.0" });

        string currentDir = Directory.GetCurrentDirectory();
        var directoryIno = new DirectoryInfo(currentDir);

        while (names.Count > 0)
        {
            string expected = names.Pop();
            if (directoryIno?.Name == expected)
            {
                directoryIno = directoryIno.Parent;
            }
            else
            {
                return null;
            }
        }
        return directoryIno;
    }
    

    static void Main(string[] args)
    {
        DirectoryInfo? prjRoot = GetProjectRoot();
        if (prjRoot == null)
        {
            Console.WriteLine("Не могу найти каталог проекта");
            return;
        }

        var pathToProgram = Path.Combine(prjRoot.FullName, "Program.cs");
        
        if (!Path.Exists(pathToProgram))
        {
            Console.WriteLine($"Файл {pathToProgram} не найден, завершаем работу");
            return;
        }

        var pathToCopy = Path.ChangeExtension(pathToProgram, ".bak");

        using (var fStream = new FileStream(pathToProgram, FileMode.Open))
        {
            using (var fileStream1 = new FileStream(pathToCopy, FileMode.Create, FileAccess.Write))
            {
                fStream.CopyTo(fileStream1);
            }
        }
    }
}

