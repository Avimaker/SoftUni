/*
3
Arnoldii<->4
Woodii<->7
Welwitschia<->2
Rate: Woodii - 10
Rate: Welwitschia - 7
Rate: Arnoldii - 3
Rate: Woodii - 5
Update: Woodii - 5
Reset: Arnoldii
Exhibition

1
Arnoldii<->4
Rate: Arnoldii - 3
Rate: Aroldii - 1
Exhibition

*/

using System.Xml.Linq;

namespace _11.PlantDiscovery;

class Plant
{
    public Plant()
    {
    }

    public Plant(string name, int rarity, List<double> rate)
    {
        Name = name;
        Rarity = rarity;
        Rate = rate;
    }

    public string Name { get; set; }
    public int Rarity { get; set; }
    public List<double> Rate { get; set; }
}


class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split("<->");

            string name = input[0];

            int rarity = int.Parse(input[1]);
            List<double> rate = new List<double>();

            Plant plant = new Plant(name, rarity, rate);

            if (!plants.ContainsKey(name))
            {
                plants.Add(name, plant);
            }
            else
            {
                plants[name].Rarity = rarity;
            }
        }

        string command = default;
        while ((command = Console.ReadLine()) != "Exhibition")
        {
            string[] arguments = command.Split();

            string actionCommand = arguments[0].Trim(':');

            // name check
            if (!plants.Keys.Contains(arguments[1]))
            {
                Console.WriteLine("error");
                continue;
            }


            if (actionCommand == "Rate")
            {
                string name = arguments[1];
                double rating = double.Parse(arguments[3]);
                plants[name].Rate.Add(rating);
            }

            else if (actionCommand == "Update")
            {
                string name = arguments[1];
                int rearity = int.Parse(arguments[3]);
                plants[name].Rarity = rearity;
            }

            else if (actionCommand == "Reset")
            {
                string name = arguments[1];
                plants[name].Rate = new List<double>();
            }
        }

        Console.WriteLine("Plants for the exhibition:");

        //foreach (var plant in plants)
        //{
        //    Console.WriteLine($"{plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {(plant.Value.Rate.Any() ? plant.Value.Rate.Average().ToString("f2") : "0.00")}");
        //}

        foreach (var plant in plants)
        {
            double plantAverage = plant.Value.Rate.Any()
                ? plant.Value.Rate.Average()
                : 0.0;

            Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plantAverage:f2}");
        }

    }
}

