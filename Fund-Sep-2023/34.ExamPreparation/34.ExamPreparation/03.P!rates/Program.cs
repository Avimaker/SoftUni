/*
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End

Tortuga||345000||1250
Tortuga||345000||1250

Nassau||95000||1000
San Juan||930000||1250
Campeche||270000||690
Port Royal||320000||1000
Port Royal||100000||2000
Sail
Prosper=>Port Royal=>-200
Plunder=>Nassau=>94000=>750
Plunder=>Nassau=>1000=>150
Plunder=>Campeche=>150000=>690
End

*/


namespace _03.P_rates;

class City
{

    public City()
    {

    }

    public City(string name, int population, int gold)
    {
        Name = name;
        Population = population;
        Gold = gold;
    }

    public string Name { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }

    public void Update(int population, int gold)
    {
        Population += population;
        Gold += gold;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, City> targetCities = new Dictionary<string, City>();

        string command = default;
        while ((command = Console.ReadLine()) != "Sail")
        {
            string[] arguments = command.Split("||");

            string currentName = arguments[0];
            int currentPpulation = int.Parse(arguments[1]);
            int currenGold = int.Parse(arguments[2]);

            City currnetCity = new City(currentName, currentPpulation, currenGold);

            if (!targetCities.ContainsKey(currentName))
            {
                targetCities.Add(currentName, currnetCity);
            }
            else
            {
                targetCities[currentName].Update(currnetCity.Population, currnetCity.Gold);
            }
        }


        string events = default;
        while ((events = Console.ReadLine()) != "End")
        {
            string[] arguments = events.Split("=>");

            if (arguments[0] == "Plunder")
            {
                string town = arguments[1];
                int people = int.Parse(arguments[2]);
                int gold = int.Parse(arguments[3]);

                targetCities[town].Gold -= gold;
                targetCities[town].Population -= people;

                if (targetCities[town].Gold >= 0 && targetCities[town].Population >= 0)
                {
                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                }
 
                bool forDelete = targetCities.Values.Any(t => t.Gold <= 0 || t.Population <= 0);

                if (forDelete)
                {
                    Console.WriteLine($"{town} has been wiped off the map!");
                    targetCities.Remove(town);
                }

            }

            else if (arguments[0] == "Prosper")
            {
                string town = arguments[1];
                int gold = int.Parse(arguments[2]);

                if (gold <= 0)
                {
                    Console.WriteLine("Gold added cannot be a negative number!");
                    continue;
                }

                targetCities[town].Gold += gold;
                Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {targetCities[town].Gold} gold.");
            }

        }

        if (targetCities.Count == 0)
        {
            Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            return;
        }

        Console.WriteLine($"Ahoy, Captain! There are {targetCities.Count} wealthy settlements to go to:");

        foreach (var town in targetCities)
        {
            Console.WriteLine($"{town.Key} -> Population: {town.Value.Population} citizens, Gold: {town.Value.Gold} kg");
        }

    }
}



///*
//Beer 2.20 100
//IceTea 1.50 50
//NukaCola 3.30 80
//Water 1.00 500
//buy
//*/

//namespace _03.Orders;

//class Product
//{
//    public string Name { get; set; }

//    public double Price { get; set; }

//    public int Quantity { get; set; }

//    public Product(string name, double price, int quantity)
//    {
//        Name = name;
//        Price = price;
//        Quantity = quantity;
//    }

//    public void Update(double price, int quantity)
//    {
//        Price = price;
//        Quantity += quantity;
//    }

//    public double GetTotal()
//    {
//        return Price * Quantity;
//    }

//    public override string ToString()
//    {
//        return $"{Name} -> {GetTotal():F2}";
//    }

//}

//class Program
//{
//    static void Main(string[] args)
//    {

//        Dictionary<string, Product> products = new Dictionary<string, Product>();

//        string input;
//        while ((input = Console.ReadLine()) != "buy")
//        {
//            string[] arguments = input.Split();

//            string name = arguments[0];
//            double price = double.Parse(arguments[1]);
//            int quantity = int.Parse(arguments[2]);

//            Product addProduct = new Product(name, price, quantity);

//            if (!products.ContainsKey(name))
//            {
//                products.Add(addProduct.Name, addProduct);
//            }
//            else
//            {
//                products[name].Update(addProduct.Price, addProduct.Quantity);
//            }
//        }

//        foreach (var result in products)
//        {
//            Console.WriteLine(result.Value);
//        }

//    }
//}

