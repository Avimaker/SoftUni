using System;

namespace _03.SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int primeSum = 0, compositeSum = 0;

            while (input != "stop")
            {
                int currentNum = int.Parse(input);

                if (currentNum < 0)
                {
                    Console.WriteLine($"Number is negative.");
                }
                else
                {

                    bool isPrime = true;
                    double sqrt = Math.Sqrt(currentNum);
                    for (int i = 2; i <= sqrt; i++)
                    {
                        if (currentNum % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime) { primeSum += currentNum; }
                    else { compositeSum += currentNum; }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {compositeSum}");
        }
    }
}

