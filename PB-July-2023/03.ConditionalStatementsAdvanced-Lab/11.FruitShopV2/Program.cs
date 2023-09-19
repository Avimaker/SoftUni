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

            bool error = false;

            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = 2.50 * pcs;
                        break;
                    case "apple":
                        price = 1.20 * pcs;
                        break;
                    case "orange":
                        price = 0.85 * pcs;
                        break;
                    case "grapefruit":
                        price = 1.45 * pcs;
                        break;
                    case "kiwi":
                        price = 2.70 * pcs;
                        break;
                    case "pineapple":
                        price = 5.50 * pcs;
                        break;
                    case "grapes":
                        price = 3.85 * pcs;
                        break;
                    default:
                        error = true;
                        break;

                }

            }
            else if (day == "Saturday" || day == "Sunday")
            {
                switch (fruit)
                {
                    case "banana":
                        price = 2.70 * pcs;
                        break;
                    case "apple":
                        price = 1.25 * pcs;
                        break;
                    case "orange":
                        price = 0.90 * pcs;
                        break;
                    case "grapefruit":
                        price = 1.60 * pcs;
                        break;
                    case "kiwi":
                        price = 3.00 * pcs;
                        break;
                    case "pineapple":
                        price = 5.60 * pcs;
                        break;
                    case "grapes":
                        price = 4.20 * pcs;
                        break;
                    default:
                        error = true;
                        break;
                }

            }

            else error = true;


            if (error == true)
            {
                Console.WriteLine("error");
            }
            else
            {
                Console.WriteLine($"{price:f2}");
            }



        }
    }
}

