using System;

namespace _11.FruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double pcs = double.Parse(Console.ReadLine());

            double price = 0;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = 2.50 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "apple":
                        price = 1.20 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "orange":
                        price = 0.85 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapefruit":
                        price = 1.45 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "kiwi":
                        price = 2.70 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "pineapple":
                        price = 5.50 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapes":
                        price = 3.85 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;

                }

                
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = 2.70 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "apple":
                        price = 1.25 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "orange":
                        price = 0.90 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapefruit":
                        price = 1.60 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "kiwi":
                        price = 3.00 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "pineapple":
                        price = 5.60 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapes":
                        price = 4.20 * pcs;
                        Console.WriteLine($"{price:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

            }

            else
            {
                Console.WriteLine("error");
            }




        }
    }
}

