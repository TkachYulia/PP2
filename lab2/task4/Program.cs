using System;
using System.IO;
namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            File.Create(@"C:\C#\lab2\ex2.txt");
            File.Create(@"C:\C#\lab2\ex3.txt");
            string line = "hfhdg";
            File.WriteAllText(@"C:\C#\lab2\ex2.txt", line);
            string sourceFile = Path.Combine(@"C:\C#\lab2\ex2.txt");
            string destFile = Path.Combine(@"C:\C#\lab2\ex3.txt");
            File.Copy(sourceFile, destFile);
        }
    }
}
