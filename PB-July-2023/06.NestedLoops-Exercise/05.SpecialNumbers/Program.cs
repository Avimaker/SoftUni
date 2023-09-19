using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //v1
            //int n = int.Parse(Console.ReadLine());

            //for (int i = 1111; i <= 9999; i++)
            //{
            //    int currentNum = i;
            //    bool isSpecial = true;
            //    while (currentNum != 0)
            //    {
            //        int lastDigit = currentNum % 10;
            //        if (lastDigit == 0 || n % lastDigit != 0)
            //        {
            //            isSpecial = false;
            //            break;
            //        }
            //        currentNum /= 10;
            //    }

            //    if (isSpecial)
            //    {
            //        Console.Write($"{i} ");
            //    }
            //}

            // v2
            //int n = int.Parse(Console.ReadLine());

            //for (int i1 = 1; i1 <= 9; i1++)
            //{
            //    for (int i2 = 1; i2 <= 9; i2++)
            //    {
            //        for (int i3 = 1; i3 <= 9; i3++)
            //        {
            //            for (int i4 = 1; i4 <= 9; i4++)
            //            {
            //                if (n % i1 == 0 && n % i2 == 0 && n % i3 == 0 && n % i4 == 0)
            //                {
            //                    Console.Write($"{i1}{i2}{i3}{i4} ");
            //                }
            //            }
            //        }
            //    }
            //}

            int n = int.Parse(Console.ReadLine());

            for (int i1 = 1; i1 <= 9; i1++)
            {
                if (n % i1 != 0) continue;

                for (int i2 = 1; i2 <= 9; i2++)
                {
                    if (n % i2 != 0) continue;

                    for (int i3 = 1; i3 <= 9; i3++)
                    {
                        if (n % i3 != 0) continue;

                        for (int i4 = 1; i4 <= 9; i4++)
                        {
                            if (n % i4 == 0)
                            {
                                Console.Write($"{i1}{i2}{i3}{i4} ");
                            }

                            //for (char i5 = 'a'; i5 <= 'z'; i5++)
                            //{

                            //}


                        }
                    }
                }
            }

        }
    }
}

