
int number = int.Parse(Console.ReadLine());
int binary = int.Parse(Console.ReadLine());

int zeroesCounter = 0;
int onesCounter = 0;

while (number > 0)
{

    int tempNumber = number % 2;
    number /= 2;

    if (tempNumber == 1)
    {
        onesCounter++;
    }
    else
    {
        zeroesCounter++;
    }

   
}

if (binary == 0)
{
    Console.WriteLine(zeroesCounter);
}
else
{
    Console.WriteLine(onesCounter);
}