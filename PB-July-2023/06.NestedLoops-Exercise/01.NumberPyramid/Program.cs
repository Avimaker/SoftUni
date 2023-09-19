using System;

namespace _01.NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            //Var 1
            //int n = int.Parse(Console.ReadLine());

            //int row = 1;
            //int column = 1;

            //for (int i = 1; i <= n; i++)
            //{
            //    Console.Write(i);

            //    if (column == row)
            //    {
            //        Console.WriteLine();
            //        row++;
            //        column = 1;
            //    }
            //    else
            //    {
            //        Console.Write(" ");
            //        column++;
            //    }
            //}


            //Var 2
            //int n = int.Parse(Console.ReadLine());

            //int currentNum = 1;

            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write($"{currentNum} ");
            //        currentNum++;

            //        if (currentNum > n) { return; }
            //    }

            //    Console.WriteLine();
            //}


            //Var 3
            //int n = int.Parse(Console.ReadLine());

            //int currentNum = 1;
            //bool enough = false;

            //for (int i = 1; i <= n; i++)
            //{
            //    for (int j = 1; j <= i; j++)
            //    {
            //        Console.Write($"{currentNum} ");
            //        currentNum++;

            //        if (currentNum > n)
            //        {
            //            enough = true;
            //            break;
            //        }
            //    }

            //    if (enough)
            //    {
            //        break;
            //    }
            //    Console.WriteLine();

            //Var 4
            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;
            bool enough = false;

            for (int i = 1; i <= n && !enough; i++)
            {
                for (int j = 1; j <= i && !enough; j++)
                {
                    Console.Write($"{currentNum} ");
                    currentNum++;

                    if (currentNum > n)
                    {
                        enough = true;
                    }
                }

                Console.WriteLine();

            }
        }
    }
}

