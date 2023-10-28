

namespace _01.RandomizeWords;
class Program
{
    static void Main(string[] args)
    {
        List<string> words = Console.ReadLine()
            .Split()
            .ToList();

        Random rnd = new Random();
        int randomNumber = rnd.Next();

    }
}

