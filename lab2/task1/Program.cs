using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = System.IO.File.ReadAllText(@"C:\C#\lab2\sample.txt");
           string reverseline = string.Empty;
            if( line != null)
            {
                for(int i = line.Length - 1; i >=0; i--)
                {
                    reverseline += line[i].ToString();
                }
                if(line == reverseline)
                {
                    Console.WriteLine("Yes");

                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
