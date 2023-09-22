int number = int.Parse(Console.ReadLine());

int sume = 0;

for (int i = number; i >= 0; i--)
{
    int tempDigit = number % 10;
    sume += tempDigit;
    number /= 10;
}

Console.WriteLine(sume);