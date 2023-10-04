int dayNumber = int.Parse(Console.ReadLine());
string[] daysOfTheWeek = new string[7] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};


if (dayNumber >= 1 && dayNumber <= 7)
{
    Console.WriteLine(daysOfTheWeek[dayNumber-1]);
    return;
}

Console.WriteLine("Invalid day!");