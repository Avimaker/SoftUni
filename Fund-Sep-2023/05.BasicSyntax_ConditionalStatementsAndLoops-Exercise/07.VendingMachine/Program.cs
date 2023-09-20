string coins = Console.ReadLine();
double money = 0;

while (coins != "Start")
{
    double ammountOfCoin = double.Parse(coins);

    if (ammountOfCoin == 0.1)
    {
        money += 0.1;
    }
    else if (ammountOfCoin == 0.2)
    {
        money += 0.2;
    }
    else if (ammountOfCoin == 0.5)
    {
        money += 0.5;
    }
    else if (ammountOfCoin == 1)
    {
        money += 1;
    }
    else if (ammountOfCoin == 2)
    {
        money += 2;
    }
    else
    {
        Console.WriteLine($"Cannot accept {ammountOfCoin}");
    }

    coins = Console.ReadLine();
}

string product = Console.ReadLine();

while (product != "End")
{
    if (product == "Nuts")
    {
        if (money >= 2.00)
        {
            money -= 2.00;
            Console.WriteLine($"Purchased {product.ToLower()}");
        }

        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }

    else if (product == "Water")
    {
        if (money >= 0.70)
        {
            money -= 0.70;
            Console.WriteLine($"Purchased {product.ToLower()}");
        }

        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }

    else if (product == "Crisps")
    {
        if (money >= 1.50)
        {
            money -= 1.50;
            Console.WriteLine($"Purchased {product.ToLower()}");
        }

        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }

    else if (product == "Soda")
    {
        if (money >= 0.80)
        {
            money -= 0.80;
            Console.WriteLine($"Purchased {product.ToLower()}");
        }

        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }

    else if (product == "Coke")
    {
        if (money >= 1.00)
        {
            money -= 1.00;
            Console.WriteLine($"Purchased {product.ToLower()}");
        }

        else
        {
            Console.WriteLine("Sorry, not enough money");
        }
    }

    else
    {
        Console.WriteLine("Invalid product");
    }


    product = Console.ReadLine();
}

Console.WriteLine($"Change: {money:f2}");