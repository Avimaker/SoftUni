using System.Runtime.ConstrainedExecution;

int orders = int.Parse(Console.ReadLine());

double totalPrice = 0;

for (int i = 0; i < orders; i++)
{
    double pricePerCapsule = double.Parse(Console.ReadLine());
    int days = int.Parse(Console.ReadLine());
    int caps = int.Parse(Console.ReadLine());

    double currentPrice = (days * caps) * pricePerCapsule;
    Console.WriteLine($"The price for the coffee is: {currentPrice}");
    totalPrice += currentPrice;
}

Console.WriteLine($"Total: ${totalPrice:f2}");