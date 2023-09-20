int n = 0;

bool isTrue = true;

while (isTrue)
{
    n = int.Parse(Console.ReadLine());
    if (n % 2 == 0)
    {
        Console.WriteLine($"The number is: {Math.Abs(n)}");
        isTrue = false;
    }
    else
    {
        Console.WriteLine("Please write an even number.");
    }
    
}