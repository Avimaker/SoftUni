/*
Tortuga||345000||1250
Santo Domingo||240000||630
Havana||410000||1100
Sail
Plunder=>Tortuga=>75000=>380
Prosper=>Santo Domingo=>180
End


Tortuga||345000||1250
Tortuga||345000||1250

Nassau||95000||1000
San Juan||930000||1250
Campeche||270000||690
Port Royal||320000||1000
Port Royal||100000||2000
Sail


*/




namespace _03.P_rates;

class City
{

    public City()
    {

    }

    public City(string name, int population, int gold)
    {
        Name = name;
        Population = population;
        Gold = gold;
    }

    public string Name { get; set; }
    public int Population { get; set; }
    public int Gold { get; set; }

}


class Program
{
    static void Main(string[] args)
    {
        List<City> targetCities = new List<City>();

        string command = default;
        while ((command = Console.ReadLine()) != "Sail")
        {
            string[] arguments = command.Split("||");

            City currnetCity = new City();
            currnetCity.Name = arguments[0];
            currnetCity.Population = int.Parse(arguments[1]);
            currnetCity.Gold = int.Parse(arguments[2]);

            string searchCity = currnetCity.Name;
            City townToModify = targetCities.Find(t => t.Name == searchCity);

            if (!targetCities.Exists(name => name.Name == currnetCity.Name))
            {
                targetCities.Add(currnetCity);
            }
            else
            {
                //int index = targetCities.IndexOf(townToModify);
                //targetCities[index].Gold += currnetCity.Gold;
                //targetCities[index].Population += currnetCity.Population;

                // Въпроса ми е има ли начин без търсене на индекс в "targetCities", а директно по име което имам от "currentCity.Name" да го намеря в "targetCities" и директно да сменя там стойността на Gold и Population?  

                // нещо такова - знам, че е грешно, но не знам как да опиша какво искам :)
                //targetCities.Where((n => n.Name == currnetCity.Name) => (n.Gold += (currnetCity.Gold));


            }
        }

        ;

    }
}



