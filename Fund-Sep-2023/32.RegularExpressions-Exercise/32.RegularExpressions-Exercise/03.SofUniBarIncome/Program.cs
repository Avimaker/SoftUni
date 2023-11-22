/*
%George%<Croissant>|2|10.3$
%Peter%<Gum>|1|1.3$
%Maria%<Cola>|1|2.4$
end of shift

%InvalidName%<Croissant>|2|10.3$
%Peter%<Gum>1.3$
%Maria%<Cola>|1|2.4
%Valid%<Valid>valid|10|valid20$
end of shift


(\%(?<Name>[A-Z][a-z]+)\%)([^|$%.]*\<(?<Product>\w+)\>[^|$%.]*)(\|(?<Count>\d+)\|[^|$%.]*?)((?<Price>\d+(?:\.\d+)?)\$)
 
*/

using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Text;

class Order
{
    public string Custumer { get; set; }
    public string Product { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }

    public Order()
    {

    }

    public Order(string custumer, string product, int count, double price)
    {
        Custumer = custumer;
        Product = product;
        Count = count;
        Price = price;
    }
}



//namespace _03.SofUniBarIncome;

class Program
{
    static void Main(string[] args)
    {

        //string namePattern = @"%(?<Name>[A-Z][a-z]+)%";
        //string productPattern = @"<(?<Product>[A-z]+)>";
        //string countPattern = @"\\|(?<Count>\\d+)\\|";
        //string pricePattern = @"(?<Price>\d+.\d\$|\d\d\$)";

        string pattern = @"(\%(?<Name>[A-Z][a-z]+)\%)([^|$%.]*\<(?<Product>\w+)\>[^|$%.]*)(\|(?<Count>\d+)\|[^|$%.]*?)((?<Price>\d+(?:\.\d+)?)\$)";


        List<Order> orders = new List<Order>();
        double totalIncome = 0;

        string command = default;
        while ((command = Console.ReadLine()) != "end of shift")
        {

            foreach (Match match in Regex.Matches(command, pattern))
            {
                Order order = new Order();
                order.Custumer = match.Groups["Name"].Value;
                order.Product = match.Groups["Product"].Value;
                order.Count = int.Parse(match.Groups["Count"].Value);
                order.Price = order.Count * double.Parse(match.Groups["Price"].Value.Trim('$'));


                orders.Add(order);
                Console.WriteLine($"{order.Custumer}: {order.Product} - {order.Price:f2}");
                totalIncome += order.Price;
            }
        }


            //foreach (var price in orders)
            //{
            //    double tempValue = orders.Sum(p => p.Price);
            //    totalIncome += tempValue;
            //}



        Console.WriteLine($"Total income: {totalIncome:F2}");

    }
}

