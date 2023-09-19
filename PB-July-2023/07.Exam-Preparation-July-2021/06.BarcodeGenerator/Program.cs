using System;

namespace _06.BarcodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int firstDigit1 = firstNumber / 1000;
            int secondDigit1 = firstNumber / 100 % 10;
            int thirdDigit1 = firstNumber / 10 % 10;
            int fourthDigit1 = firstNumber % 10;

            int firstDigit2 = secondNumber / 1000;
            int secondDigit2 = secondNumber / 100 % 10;
            int thirdDigit2 = secondNumber / 10 % 10;
            int fourthDigit2 = secondNumber % 10;

            for (int i = firstDigit1; i <= firstDigit2; i++)
            {
                for (int j = secondDigit1; j <= secondDigit2; j++)
                {
                    for (int k = thirdDigit1; k <= thirdDigit2; k++)
                    {

                        for (int l = fourthDigit1; l <= fourthDigit2; l++)
                        {

                            if (i % 2 == 1 && j % 2 == 1 && k % 2 == 1 && l % 2 == 1)
                            {
                                Console.Write($"{i}{j}{k}{l} ");

                            }

                        }

                    }


                }
            }
        }
    }
}

