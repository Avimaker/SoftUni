/*
9 5 8 18
18 12 10 5

18 10 8 9
5 10 12 18

1 1 4 5 9 9 9
9 15 18 13 10

1 1 4 5 6 2 3 2
17 8 18 19 20
 
 */



namespace _01.ChickenSnack;
class Program
{
    static void Main(string[] args)
    {

        Stack<int> moneyAmount = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        Queue<int> prices = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        int foodCounter = 0;

        while (moneyAmount.Count > 0 && prices.Count > 0)
        {
            int money = moneyAmount.Peek();
            int price = prices.Peek();
            int change = 0;

            if (money == price)
            {
                money = moneyAmount.Pop();
                price = prices.Dequeue();
                foodCounter++;
            }

            else if (money > price)
            {
                change = money - price;

                money = moneyAmount.Pop();
                if (moneyAmount.Count > 0)
                {
                int temp = moneyAmount.Pop();
                change += temp; 
                }

                moneyAmount.Push(change);
                price = prices.Dequeue();
                foodCounter++;
            }

            else if (money < price)
            {
                money = moneyAmount.Pop();
                price = prices.Dequeue();
            }
        }

        if (foodCounter == 0)
        {
            Console.WriteLine("Henry remained hungry. He will try next weekend again.");
        }
        else if (foodCounter == 1)
        {
            Console.WriteLine($"Henry ate: {foodCounter} food.");
        }
        else if (foodCounter >= 4)
        {
            Console.WriteLine($"Gluttony of the day! Henry ate {foodCounter} foods.");
        }
        else if (foodCounter < 4)
        {
            Console.WriteLine($"Henry ate: {foodCounter} foods.");
        }
       

    }
}

