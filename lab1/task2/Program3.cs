using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();//read input info
            string line2 = Console.ReadLine();//read input info
            string[] parts = line2.Split(new char[] { ' ', ',' });  // split line2 to single chars

            for (int i = 0; i < parts.Length; ++i) // cycle to show parts of line2
            {
                Console.Write(parts[i] + ' '); // show element of line2
                Console.Write(parts[i] + ' '); // show element of line2 again
            }
        }
    }
}
