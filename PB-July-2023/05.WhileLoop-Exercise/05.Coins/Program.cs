using System;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            int bgn2 = 200;
            int bgn1 = 100;
            int st50 = 50;
            int st20 = 20;
            int st10 = 10;
            int st5 = 5;
            int st2 = 2;
            int st1 = 1;

            int count = 0;
            double resto = 0;

            double input = double.Parse(Console.ReadLine());
            double sum = input * 100;

            resto = sum;
            while (resto >= 100)
            {

                if (resto >= bgn2)
                {
                    resto -= bgn2;
                    count++;
                }
                if (resto >= bgn1)
                {
                    resto -= bgn1;
                    count++;
                }
            }

            if (resto >= st50)
            {
                resto -= st50;
                count++;
            }
            if (resto >= st20)
            {
                resto -= st20;
                count++;
            }
            if (resto >= st10)
            {
                resto -= st10;
                count++;
            }
            if (resto >= st5)
            {
                resto -= st5;
                count++;
            }
            if (resto >= st2)
            {
                resto -= st2;
                count++;
            }
            if (resto >= st1)
            {
                resto -= st1;
                count++;
            }

            //}

            Console.WriteLine(count);
            


        }
    }
}

