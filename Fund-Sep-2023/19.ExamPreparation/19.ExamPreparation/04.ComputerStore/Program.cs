/*
1050
200
450
2
18.50 
16.86 
special
 
1023 
15
-20
-5.50
450
20 
17.66 
19.30
regular

regular
 
 */


namespace _04.ComputerStore;

class Program
{
    static void Main(string[] args)
    {
        double currentPrice = 0;
        double tax = 0;
        double totalPrice = 0;

        string inputs = default;
        string custumer = default;
        bool isTrue = true;
        while (isTrue)
        {
            inputs = Console.ReadLine();

            if (inputs != "special" && inputs != "regular")
            {
                double priceCheck = double.Parse(inputs);

                if (priceCheck < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    currentPrice += priceCheck;
                }
            }
            else
            {
                custumer = inputs;
                isTrue = false;
            }

        }

        if (custumer == "regular")
        {
            tax = currentPrice * 0.20;
            totalPrice = currentPrice + tax;
        }
        else if (custumer == "special")
        {
            tax = currentPrice * 0.20;
            totalPrice = currentPrice + tax;
            totalPrice *= 0.90;
        }

        if (totalPrice == 0)
        {
            Console.WriteLine("Invalid order!");
            return;
        }

        Console.WriteLine("Congratulations you've just bought a new computer!");
        Console.WriteLine($"Price without taxes: {currentPrice:f2}$");
        Console.WriteLine($"Taxes: {tax:f2}$");
        Console.WriteLine("-----------");
        Console.WriteLine($"Total price: {totalPrice:f2}$");


    }
}

