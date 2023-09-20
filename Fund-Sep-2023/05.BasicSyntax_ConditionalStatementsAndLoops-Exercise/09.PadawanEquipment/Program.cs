double ammountOfMoney = double.Parse(Console.ReadLine());
int countOfStudents = int.Parse(Console.ReadLine());
double priceOfLightsaber = double.Parse(Console.ReadLine());
double priceOfRobe = double.Parse(Console.ReadLine());
double priceOfBelt = double.Parse(Console.ReadLine());

double priceForAllLightsabers = Math.Ceiling(countOfStudents * 1.1) * priceOfLightsaber;
double priceForAllRobes = countOfStudents * priceOfRobe;

int freeBelts = countOfStudents / 6;
double priceForAllBelts = (countOfStudents - freeBelts) * priceOfBelt;

double finalPrice = priceForAllLightsabers + priceForAllRobes + priceForAllBelts;

if (finalPrice <= ammountOfMoney)
{
    Console.WriteLine($"The money is enough - it would cost {finalPrice:f2}lv.");
}
else
{
    double neededMoney = finalPrice - ammountOfMoney;
    Console.WriteLine($"John will need {neededMoney:f2}lv more.");
}


