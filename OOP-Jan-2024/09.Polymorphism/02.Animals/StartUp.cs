using Animals.Models;

namespace Animals;
public class StartUp
{
    static void Main(string[] args)
    {
        //Animal cat = new Cat("Peter", "Whiskas");
        //Animal dog = new Dog("George", "Meat");

        //Console.WriteLine(cat.ExplainSelf());
        //Console.WriteLine(dog.ExplainSelf());

        Animal animal = new Cat("Peter", "Whiskas");
        Explain(animal);
        animal = new Dog("George", "Meat");
        Explain(animal);

    }

    static void Explain(Animal animal)
    {
        Console.WriteLine(animal.ExplainSelf());
    }

}

