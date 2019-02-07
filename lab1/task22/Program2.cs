using System;

namespace task22
{
    class Student
        {
            public string name;
            public string id;
        public int year;
            public void PrintInfo()
            {
                Console.WriteLine(name + " " + id + " " + year);
            }
        }
      class Program{
        static void Main(string[] args){

            Student s = new Student();
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();
            string line3 = Console.ReadLine();
            s.name = line1;
            s.id = line2;
            int a = int.Parse(line3);
            a = a + 1;
            s.year = a;
            s.PrintInfo();

            
        }
    }
}
