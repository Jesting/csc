using System.Diagnostics;

namespace Lection9Program1;
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

    static bool ContainsExtenstions(DirectoryInfo dir, string[] extensions)
    {
        HashSet<string> set = new HashSet<string>(extensions);

        foreach (FileInfo fi in dir.EnumerateFiles())
        {
            if (set.Contains(fi.Extension))
            {
                set.Remove(fi.Extension);
            }
        }
        return set.Count == 0;
    }

    static long CalculateDirectorySize(DirectoryInfo dir)
    {
        long length = 0;
        foreach (var f in dir.GetFiles())
        {
            length+=f.Length;
        }
        foreach (var d in dir.GetDirectories())
        {
            length += CalculateDirectorySize(d);
        }
        return length;
    }

    static void DrawDirectoryInfo(DirectoryInfo dir)
    {    
        foreach (var d in dir.GetDirectories())
        {
            Console.WriteLine($"[{d.Name}]".PadRight(50,' ') + $"<{CalculateDirectorySize(d)}>");

        }

        foreach (var f in dir.GetFiles())
        {
            Console.WriteLine(f.Name.PadRight(50, ' ')+$"<{f.Length}>");
            
        }

    }

    static void Main(string[] args)
    {
        DirectoryInfo? prjRoot = GetProjectRoot();
        if (prjRoot == null)
        {
            Console.WriteLine("Не могу найти каталог проекта");
            return;
        }

        DrawDirectoryInfo(prjRoot);
     
    }
}

