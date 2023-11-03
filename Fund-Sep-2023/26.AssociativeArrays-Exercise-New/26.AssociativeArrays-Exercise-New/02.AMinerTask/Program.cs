/*
Gold
155
Silver
10
Copper
17
stop
*/

namespace _02.AMinerTask;

class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, int> resourceMap = new Dictionary<string, int>();

        string resource = default;
        while ((resource = Console.ReadLine()) != "stop")
        {
            string[] arguments = resource.Split();

            if (!resourceMap.ContainsKey(resource))
            {
                resourceMap.Add(resource, 0);
            }

            var quantity = int.Parse(Console.ReadLine());
            resourceMap[resource] += quantity;
        }

        foreach (var resourcePair in resourceMap)
        {
            Console.WriteLine($"{resourcePair.Key} -> {resourcePair.Value}");
        }
    }
}

