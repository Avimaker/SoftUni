// Input

int number = int.Parse(Console.ReadLine());


for (int i = 'a'; i < 'a' + number; i++)
{
    for (int k = 'a'; k < 'a' + number; k++)
    {
        for (int n = 'a'; n < 'a' + number; n++)
        {
            Console.WriteLine($"{(char)i}{(char)k}{(char)n}");


        }

    }


}

//for (char first = 'a'; first < 'a' + number; first++)
//{
//    for (char second = 'a'; second < 'a' + number; second++)
//    {
//        for (char third = 'a'; third < 'a' + number; third++)
//        {
//            Console.WriteLine($"{first}{second}{third}");
//        }
//    }
//}