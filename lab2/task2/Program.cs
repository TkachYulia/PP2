using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = System.IO.File.ReadAllText(@"C:\C#\lab2\text.txt");
            string[] parts = line.Split(new char[] { ' ', ',' });
            string primes = "";
            for (int i = 0; i < parts.Length; i++) // cycle to identify prime numbers
            {
                int cnt = 0; // counter for dividers
                int b = int.Parse(parts[i]); // transform char to int
                for (int j = 1; j < b; j++) // cycle, which check dividers
                {
                    if (b % j == 0) // condition which check if number have dividers
                        cnt++;
                }
                if (cnt <= 1) // condition to check how many dividers does number have
                {
                    primes += b;
                    primes += " ";
                }
            }
            System.IO.File.WriteAllText(@"C:\C#\lab2\output.txt", primes);

        }
    }
}
