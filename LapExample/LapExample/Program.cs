

namespace LapExample;

public class Program
{
    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Write("mmabas@SDOps:~$ ");
            string input = Console.ReadLine() ?? "";
            switch (input)
            {
                case "exit":
                    exit = true;
                    break;
                case "pwd":
                    Pwd();
                    break;
                case "ls":
                    Ls();
                    break;
                case "mkdir":
                    MkDir();
                    break;
                case "touch":
                    Touch();
                    break;
                case "rm":
                    Rm();
                    break;
                case "cat":
                    Cat();
                    break;
                case "nano-append":
                    NanoAppend();
                    break;
                case "nano":
                    Nano();
                    break;
                
                    
            }
        }
    }
    
    public static void Pwd()
    {
        var currentDir = Directory.GetCurrentDirectory();
        DirectoryInfo dirinfo = new DirectoryInfo(currentDir);
        Console.WriteLine(dirinfo.FullName);
        Console.WriteLine("Full Name of the directory is : {0}", dirinfo.FullName);
        Console.WriteLine("The directory was last accesses on: {0}", dirinfo.LastAccessTime.ToString());
    }
    public static void Ls()
    {
        var currentDir = Directory.GetCurrentDirectory();
        DirectoryInfo dirinfo = new DirectoryInfo(currentDir);
    
        FileInfo[] filesInDir = dirinfo.GetFiles();
        DirectoryInfo[] dirsInDir = dirinfo.GetDirectories();
    
        foreach (var directoryInfo in dirsInDir)
        {
            Console.WriteLine("{0}      -----      {1}",
                directoryInfo.Name, directoryInfo.LastAccessTime);
        }
        foreach (FileInfo file in filesInDir)
        {
            Console.WriteLine("{0}      {1}      {2}", 
                file.Name, file.Length, file.LastAccessTime);
        }
    }
    
    public static void MkDir()
    {
        Console.Write("Enter the name of the directory: ");
        var name = Console.ReadLine();
    
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Directory name cannot be empty.");
            return;
        }
    
        if (Directory.Exists(name))
        {
            Console.WriteLine("Directory already exists.");
            return;
        }
    
        Directory.CreateDirectory(name);
    }
 
    public static void Touch()
    {
        Console.Write("Enter the name of the file: ");
        var name = Console.ReadLine();
    
        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("File name cannot be empty.");
            return;
        }
    
        if (File.Exists(name))
        {
            Console.WriteLine("File already exists.");
            return;
        }
    
        var fs = File.Create(name);
        fs.Close();  // Important: Always close the stream after use
    }
    
    private static void Rm()
    {
        Console.Write("Enter the name of the file: ");
        var name = Console.ReadLine();
        if (!File.Exists(name)) return;
    
        File.Delete(name);
    }
    
    private static void Cat()
    {
        Console.Write("Enter the name of the file: ");
        var name = Console.ReadLine();
        if (!ValidateExists(name)) return;
    
        var content = File.ReadAllText(name);
        Console.WriteLine(content);
    }

    private static void NanoAppend()
    {
        Console.Write("Enter the name of the file: ");
        var name = Console.ReadLine();
        if (!ValidateExists(name)) return;
    
        Console.Write("Enter the text to append: ");
        var text = Console.ReadLine();
    
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Text cannot be empty.");
            return;
        }
    
        File.AppendAllText(name, text);
    }
    
    
    private static void Nano()
    {
        Console.Write("Enter the name of the file: ");
        var name = Console.ReadLine();
        if (!ValidateExists(name)) return;
    
        Console.WriteLine("----- ------ ----- [Old Content] ----- ------ -----");
        ReadFileData(name);
    
        Console.WriteLine("----- ------ ----- [Please write the new content] ----- ------ -----");
        WriteFileData(name);
    }
    
    private static void ReadFileData(string? name)
    {
        FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamReader sr = new StreamReader(fs);
        sr.BaseStream.Seek(0, SeekOrigin.Begin);  // Move to start of file
    
        string str = sr.ReadLine();
        while (str != null)
        {
            Console.WriteLine("{0}", str);
            str = sr.ReadLine();
        }
    
        sr.Close();
        fs.Close();
    }
    
    private static void WriteFileData(string? name)
    {
        FileStream fs = new FileStream(name, FileMode.Create, FileAccess.ReadWrite);
        StreamWriter w = new StreamWriter(fs);
    
        var text = Console.ReadLine();
        if (string.IsNullOrEmpty(text))
        {
            Console.WriteLine("Text cannot be empty.");
            return;
        }
    
        w.Write(text);
        w.Flush();  // Ensures data is written to disk
        w.Close();
        fs.Close();
    }
    
    private static bool ValidateExists(string? name)
    {
        return name != null && File.Exists(name);
    }
}