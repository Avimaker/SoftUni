/*
2 1 1 2 3 3 2 2 2 1
*/

//Input
int[] masivNum = Console.ReadLine().Split().Select(int.Parse).ToArray();

int maxLength = 1;
int currentLength = 1;
int repeatedNumberCell = 0;

//Start process
for (int i = 1; i < masivNum.Length; i++)
{
    if (masivNum[i] == masivNum[i - 1])
    {
        currentLength++;
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            repeatedNumberCell = i - currentLength + 1;
        }
    }
    else
    {
        currentLength = 1;
    }
}

for (int i = repeatedNumberCell; i < repeatedNumberCell + maxLength; i++)
{
    Console.Write(masivNum[i] + " ");
}