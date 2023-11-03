/*
Beer 2.20 100
IceTea 1.50 50
NukaCola 3.30 80
Water 1.00 500
buy
*/

namespace _03.Orders;

class Product
{
    public string Name { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public void Update(double price, int quantity)
    {
        Price = price;
        Quantity += quantity;
    }

    public double GetTotal()
    {
        return Price * Quantity;
    }

    public override string ToString()
    {
        return $"{Name} -> {GetTotal():F2}";
    }

}

class Program
{
    static void Main(string[] args)
    {

        Dictionary<string, Product> products = new Dictionary<string, Product>();

        string input;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] arguments = input.Split();

            string name = arguments[0];
            double price = double.Parse(arguments[1]);
            int quantity = int.Parse(arguments[2]);

            Product addProduct = new Product(name, price, quantity);

            if (!products.ContainsKey(name))
            {
                products.Add(addProduct.Name, addProduct);
            }
            else
            {
                products[name].Update(addProduct.Price, addProduct.Quantity);
            }
        }

        foreach (var result in products)
        {
            Console.WriteLine(result.Value);
        }

    }
}

