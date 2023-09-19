using System;

namespace _06.OperationsBetweenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0.00;



            if(operation == '+')
            {
                result = n1 + n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }

            else if (operation == '-')
            {
                result = n1 - n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }

            else if (operation == '*')
            {
                result = n1 * n2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - even");
                }
                else
                {
                    Console.WriteLine($"{n1} {operation} {n2} = {result} - odd");
                }
            }

            
            else if (operation == '%' && n2 != 0)
            {
                result = n1 % n2;
                Console.WriteLine($"{n1} {operation} {n2} = {result}");
            }

            else if (n2 == 0 && operation == '/' || operation == '%')
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }

            else if (operation == '/')
            {
                result = (n1 * 1.00) / n2;
                Console.WriteLine($"{n1} {operation} {n2} = {result:f2}");
            }

        }
    }
}

