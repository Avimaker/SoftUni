using System;

namespace _1.Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());

            double cake = rent * 0.20;
            double drinks = cake * 0.55;
            double animator = rent / 3;


            Console.WriteLine(rent + cake + drinks + animator);

        }
    }
}

