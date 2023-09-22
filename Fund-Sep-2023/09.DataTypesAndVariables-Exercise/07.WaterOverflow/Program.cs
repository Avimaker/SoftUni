int n = int.Parse(Console.ReadLine());
int tankCapacity = 255;
int currentLiters = 0;

for (int i = 0; i < n; i++)
{
    int litersToAdd = int.Parse(Console.ReadLine());

    if (currentLiters + litersToAdd <= tankCapacity)
    {
        currentLiters += litersToAdd;
    }
    else
    {
        Console.WriteLine("Insufficient capacity!");
    }
}

Console.WriteLine(currentLiters);