using System;
using System.Collections.Generic;
namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine(); //read input info
            int a = int.Parse(line1); //transform first string to int

            string[] parts = line2.Split(new char[] { ' ', ',' }); // split line2 to single chars
            List<int> pr = new List<int>(); // create new list of integers
            
            int cnt2 = 0; // add counter for prime numbers
            for (int i=0; i<a; i++) // cycle to identify prime numbers
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
                        pr.Add(b); // add nuber in list if it prime
                        cnt2++;
                    }
                }
            Console.WriteLine(cnt2); // show the amount of primes
            for (int i=0; i < cnt2; i++) // cycle to show list of primes
            {
                Console.Write(pr[i]); //output primes
            }
        }
    }
}
