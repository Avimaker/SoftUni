using System;

namespace _03.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int smallThan200 = 0;
            int between200To399 = 0;
            int between400To599 = 0;
            int between600To799 = 0;
            int biggerThan800 = 0;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    smallThan200++;
                }
                if (num >= 200 && num <400)
                {
                    between200To399++;
                }
                if (num  >= 400 && num < 600)
                {
                    between400To599++;
                }
                if (num >= 600 && num < 800)
                {
                    between600To799++;
                }
                if (num >= 800)
                {
                    biggerThan800++;
                }
            }

            //int sum = smallThan200 + between200To399 + between400To599 + between600To799 + biggerThan800;
            //double procent = 100.00 / sum; 

            //Console.WriteLine($"{smallThan200 * procent:f2}%");
            //Console.WriteLine($"{between200To399 * procent:f2}%");
            //Console.WriteLine($"{between400To599 * procent:f2}%");
            //Console.WriteLine($"{between600To799 * procent:f2}%");
            //Console.WriteLine($"{biggerThan800 * procent:f2}%");

            Console.WriteLine($"{100.0 * smallThan200 / n:f2}%");
            Console.WriteLine($"{100.0 * between200To399 / n:f2}%");
            Console.WriteLine($"{100.0 * between400To599 / n:f2}%");
            Console.WriteLine($"{100.0 * between600To799 / n:f2}%");
            Console.WriteLine($"{100.0 * biggerThan800 / n:f2}%");


        }
    }
}

