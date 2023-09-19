using System;

namespace _01.Clock
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int h = 0; h <= 23; h++)
            {
                for (int m = 0; m <= 59; m++)
                {
                    // Var1
                    //if (m < 10)
                    //{
                    //    Console.WriteLine($"{h}:0{m}");
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"{h}:{m}");
                    //}

                    //Var2
                    //Console.WriteLine($"{h:d2}:{m:d2}");

                    //Var3
                    if (h <= 12)
                    {
                        Console.WriteLine($"AM {h}:{m:d2}");
                    }
                    else if (h == 13)
                    {
                        Console.WriteLine($"PM 1:{m:d2}");
                    }
                    else if (h == 14)
                    {
                        Console.WriteLine($"PM 2:{m:d2}");
                    }
                    else if (h == 15)
                    {
                        Console.WriteLine($"PM 3:{m:d2}");
                    }
                    else if (h == 16)
                    {
                        Console.WriteLine($"PM 4:{m:d2}");
                    }


                    // Judge right answer
                    //Console.WriteLine($"{h}:{m}");

                }



            }

        }
    }
}

