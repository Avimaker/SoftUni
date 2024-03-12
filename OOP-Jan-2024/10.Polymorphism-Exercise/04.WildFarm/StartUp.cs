/*
Cat Sammy 1.1 Home Persian
Vegetable 4
End


Tiger Rex 167.7 Asia Bengal
Vegetable 1
Dog Tommy 500 Street
Vegetable 150
End


 
*/

using Raiding.IO;
using WildFarm.Core;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;

namespace WildFarm;
public class StartUp
{
    static void Main(string[] args)
    {

        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IAnimalFactory animalFactory = new AnimalFactory();
        IFoodFactory foodFactory = new FoodFactory();

        IEngine engine = new Engine(reader, writer, animalFactory, foodFactory);

        engine.Run();



    }
}

 