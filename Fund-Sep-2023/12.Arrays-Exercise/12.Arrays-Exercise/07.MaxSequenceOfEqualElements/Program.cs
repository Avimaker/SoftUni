/*
2 1 1 2 3 3 2 2 2 1
*/

//Input
int[] masivNum = Console.ReadLine().Split().Select(int.Parse).ToArray();

int maxLength = 1;
int currentLength = 1;
int startIndex = 0;

//Start process
for (int i = 1; i < masivNum.Length; i++)
{
    if (masivNum[i] == masivNum[i - 1])
    {
        currentLength++;
        if (currentLength > maxLength)
        {
            maxLength = currentLength;
            startIndex = i - currentLength + 1;
        }
    }
    else
    {
        currentLength = 1;
    }
}

for (int i = startIndex; i < startIndex + maxLength; i++)
{
    Console.Write(masivNum[i] + " ");
}