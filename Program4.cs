using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            int a = int.Parse(line1);
            string[,] array = new string[a, a];
            for (int i = 0; i < a; i++){
                for (int j = 0; j < a; j++){
                    if (j <= i)
                        array[i, j] = "[*] ";

                    else array[i, j] = " ";
                }
            }
            for (int i = 0; i < a; i++){
                for (int j = 0; j < a; j++)
                { Console.Write(array[i, j]);
                } Console.WriteLine();

            }
        }
    }
}
