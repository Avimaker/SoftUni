int numberOfVagons = int.Parse(Console.ReadLine());

int[] numberOfPeople = new int[numberOfVagons];

int totlaSum = 0;

for (int i = 0; i < numberOfVagons; i++)
{
    //numberOfPeople = Console.ReadLine().Split().Select(int.Parse).ToArray();
    numberOfPeople[i] = int.Parse(Console.ReadLine());
    totlaSum += numberOfPeople[i];
}

//Console.WriteLine(string.Join(" ", numberOfPeople));
for (int i = 0; i < numberOfVagons; i++)
{
    Console.Write($"{numberOfPeople[i]} ");
}
Console.WriteLine();
Console.WriteLine(totlaSum);