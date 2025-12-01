

using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",  // Windows
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        
        Process process = Process.Start(startInfo);
        
        // Send commands
        process.StandardInput.WriteLine("echo Hello World!");
        process.StandardInput.WriteLine("date /t");
        process.StandardInput.WriteLine("exit");
        
        // Read output
        string output = process.StandardOutput.ReadToEnd();
        string errors = process.StandardError.ReadToEnd();
        
        process.WaitForExit();
        
        Console.WriteLine("=== Output ===");
        Console.WriteLine(output);
        
        if (!string.IsNullOrEmpty(errors))
        {
            Console.WriteLine("\n=== Errors ===");
            Console.WriteLine(errors);
        }
    }
}
