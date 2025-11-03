using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = "-c \"date\"",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };

        Process process = Process.Start(startInfo);
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();

        Console.WriteLine("Output: " + output);
    }
}
