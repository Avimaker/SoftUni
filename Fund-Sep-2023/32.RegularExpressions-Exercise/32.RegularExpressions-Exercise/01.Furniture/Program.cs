using System.Text.RegularExpressions;

namespace _01.Furniture;

class Furniture
{
    public string Name { get; set; }
    public string Price { get; set; }
    public string Quantity { get; set; }


}


class Program
{
    static void Main(string[] args)
    {

        string pattern = @">>(?<Name>[A-Za-z]+)<<(?<Price>\\d+\\.\\d+|\\d+)!(?<Quantity>\\d+)";

        Regex r = new Regex(pattern);

        var m:MatchCollection = r.Matches("");



    }
}

