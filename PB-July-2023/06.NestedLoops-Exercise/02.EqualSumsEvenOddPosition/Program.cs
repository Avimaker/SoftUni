using System;

namespace _02.EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            // 100012 % 10 = 2
            // 100012 / 10 = 10001

            // 10001 % 10 = 2
            // 10001 / 10 = 1000

            // ....

            // 0

            
            //Var 1
            //int start = int.Parse(Console.ReadLine());
            //int end = int.Parse(Console.ReadLine());

            //for (int i = start; i <= end; i++)
            //{
            //    int currentNum = i;
            //    int evenSum = 0, oddSum = 0;
            //    bool isEven = true;

            //    while (currentNum != 0)
            //    {
            //        int lastDigit = currentNum % 10;

            //        if (isEven) {evenSum += lastDigit; }
            //        else {oddSum += lastDigit;}

            //        isEven = !isEven;
            //        currentNum /= 10;
            //    }

            //    if (evenSum == oddSum)
            //    {
            //        Console.Write($"{i} ");
            //    }
            //}

            //var 2
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                int currentNum = i;
                int evenSum = 0, oddSum = 0;
                int position = 0;

                while (currentNum != 0)
                {
                    int lastDigit = currentNum % 10;

                    if (position % 2 == 0)
                    {
                        evenSum += lastDigit;
                    }
                    else
                    {
                        oddSum += lastDigit;
                    }

                    position++;
                    currentNum /= 10;
                }

                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
            }

        }
    }
}

