/*
20, 35, 100, 27, 56, 30, 30
45, 20, 144, 173, 100, 40, 30

20, 1, 10, 16, 1, 5
205, 70, 30

25, 50, 30
50, 25

 
*/

namespace _01.BaristaContest;
class Program
{
    static void Main(string[] args)
    {

        Queue<int> coffeeQuan = new Queue<int>(Console.ReadLine()
           .Split(", ", StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray());


        Stack<int> milkQuan = new Stack<int>(Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        List<int> quantities = new List<int> { 50, 75, 100, 150, 200 };

        Dictionary<string, int> list = new Dictionary<string, int>
        {
            { "Cortado", 0 },
            { "Espresso", 0 },
            { "Capuccino", 0 },
            { "Americano", 0 },
            { "Latte", 0 }
        };

        //int cortado = 0; //50
        //int espresso = 0; //75
        //int capuccino = 0; //100
        //int americano = 0; //150
        //int latte = 0; //200

 
        while (coffeeQuan.Count > 0 && milkQuan.Count > 0)
        {
            int coffee = coffeeQuan.Peek();
            int milk = milkQuan.Peek();
            int drink = coffee + milk;
            bool isFound = quantities.Contains(drink);

            if (isFound)
            {
                coffeeQuan.Dequeue();
                milkQuan.Pop();

                if (drink == 50)
                {
                    //cortado++;
                    list["Cortado"] += 1;
                }
                else if (drink == 75)
                {
                    //espresso++;
                    list["Espresso"] += 1;
                }
                else if (drink == 100)
                {
                    //capuccino++;
                    list["Capuccino"] += 1;

                }
                else if (drink == 150)
                {
                    //americano++;
                    list["Americano"] += 1;

                }
                else if (drink == 200)
                {
                    //latte++;
                    list["Latte"] += 1;

                }
            }
            else
            {
                coffeeQuan.Dequeue();
                milkQuan.Push(milkQuan.Pop() - 5);
            }
        }//while end

        if (coffeeQuan.Count == 0 && milkQuan.Count == 0)
        {
            Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
        }
        else
        {
            Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
        }

        Dictionary<string, int> orderedList = list.OrderBy(n => n.Value).ThenByDescending(n => n.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        if (coffeeQuan.Count == 0)
        {
            Console.WriteLine("Coffee left: none");
        }
        else
        {
            //Console.WriteLine($"Coffee left: {coffeeQuan.Peek()}");
            var coffeeLeft = coffeeQuan.Count == 0 ? "none" : String.Join(", ", coffeeQuan);
            Console.WriteLine($"Coffee left: {coffeeLeft}");
        }

        if (milkQuan.Count == 0)
        {
            Console.WriteLine("Milk left: none");
        }
        else
        {
            //var milkLeft = milkQuan.Count == 0 ? "none" : String.Join(", ", milkQuan);
            //Console.WriteLine($"Milk left: {milkLeft}");

            string milkLeft;
            if (milkQuan.Count == 0)
            {
                milkLeft = "none";
            }
            else
            {
                milkLeft = String.Join(", ", milkQuan);
            }
            Console.WriteLine($"Milk left: {milkLeft}");

        }

        foreach (var item in orderedList)
        {
            if (item.Value > 0)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }


    }
}

