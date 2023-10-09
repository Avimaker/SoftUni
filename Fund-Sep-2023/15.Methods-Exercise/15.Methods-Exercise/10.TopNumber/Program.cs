using System;

class Program
{
    static void Main()
    {
        int range = int.Parse(Console.ReadLine());

        for (int number = 1; number <= range; number++)
        {
            if (IsTopNumber(number))
            {
                Console.WriteLine(number);
            }
        }
    }

    static bool IsTopNumber(int number)
    {
        return IsDivisibleBy8(number) && CheckForOddDigit(number);
    }

    static bool IsDivisibleBy8(int number)
    {
        int currentSumme = 0;
        int tempNumber = number;

        while (tempNumber > 0)
        {
            int digit = tempNumber % 10;
            currentSumme += digit;
            tempNumber /= 10;
        }

        return currentSumme % 8 == 0;
    }

    static bool CheckForOddDigit(int number)
    {
        while (number > 0)
        {
            int digit = number % 10;
            if (digit % 2 != 0)
            {
                return true;
            }
            number /= 10;
        }

        return false;
    }
}