/*
>>Chair<<412.23!3
>>Sofa<<500!5
>>Recliner<<<<!5
>>Bench<<230!10
>>>>>>Rocking chair<<!5
>>Bed<<700!5
Purchase
*/

using System.Text.RegularExpressions;

namespace _01.Furniture;

class Furniture
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    //public decimal Total(decimal price, int quantity)
    public decimal Total()
    {
        return Price * Quantity;
    }

}


class Program
{
    static void Main()
    {

        List<Furniture> furnitures = new List<Furniture>();

        string pattern = @">>(?<Name>[A-Za-z]+)<<(?<Price>\d+\.\d+|\d+)!(?<Quantity>\d+)";


        string command = default;
        while ((command = Console.ReadLine()) != "Purchase")
        {
            foreach (Match match in Regex.Matches(command, pattern))
            {
                Furniture furniture = new Furniture();
                furniture.Name = match.Groups["Name"].Value;
                furniture.Price = decimal.Parse(match.Groups["Price"].Value);
                furniture.Quantity = int.Parse(match.Groups["Quantity"].Value);

                furnitures.Add(furniture);
            }
        }

        decimal totalCost = 0;
        Console.WriteLine("Bought furniture:");
        foreach (Furniture furniture in furnitures)
        {
            Console.WriteLine(furniture.Name);
            totalCost += furniture.Total();
        }

        Console.WriteLine($"Total money spend: {totalCost:f2}");


    }
}

