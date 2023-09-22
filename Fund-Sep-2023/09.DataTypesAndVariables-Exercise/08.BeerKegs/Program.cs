/*
3
Keg 1
10
10
Keg 2
20
20
Keg 3
10
30
*/

// Input

int kegsCount = int.Parse(Console.ReadLine());

// Process
string biggestKegModel = "";
decimal biggestKegVolume = 0;

for (int i = 0; i < kegsCount; i++)
{
    string kegModel = Console.ReadLine();
    decimal kegRadius = decimal.Parse(Console.ReadLine());
    decimal kegHeight = decimal.Parse(Console.ReadLine());

    decimal volume = (decimal)Math.PI * (kegRadius * kegRadius) * kegHeight;
    //decimal volume = (decimal)Math.PI * (decimal)Math.Pow((double)radius, 2) * height;

    if (volume > biggestKegVolume)
    {
        biggestKegVolume = volume;
        biggestKegModel = kegModel;
    }

}

//Output
Console.WriteLine(biggestKegModel);