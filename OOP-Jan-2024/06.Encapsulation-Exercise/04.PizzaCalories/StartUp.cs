/*
Pizza Meatless
Dough Wholegrain Crispy 100
Topping Veggies 50
Topping Cheese 50
END

Pizza Bulgarian
Dough White Chewy 100
Topping Sauce 20
Topping Cheese 50
Topping Cheese 40
Topping Meat 10
Topping Sauce 10
Topping Cheese 30
Topping Cheese 40
Topping Meat 20
Topping Sauce 30
Topping Cheese 25
Topping Cheese 40
Topping Meat 40
END

 
*/
using PizzaCalories.Models;

namespace PizzaCalories;
public class StartUp
{
    static void Main(string[] args)
    {
        try
        {
            //missing name should throw custom exception - not using RemoveEmptyEntries
            string[] pizzaTokens = Console.ReadLine().Split();
            string[] doughTokens = Console.ReadLine().Split();

            string pizzaName = pizzaTokens[1];

            Dough dough = new(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));

            Pizza pizza = new(pizzaName, dough);

            while (true)
            {
                string toppingsInput = Console.ReadLine();

                if (toppingsInput == "END")
                {
                    break;
                }

                string[] toppingsTokens = toppingsInput.Split();

                Topping topping = new(toppingsTokens[1], double.Parse(toppingsTokens[2]));

                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

