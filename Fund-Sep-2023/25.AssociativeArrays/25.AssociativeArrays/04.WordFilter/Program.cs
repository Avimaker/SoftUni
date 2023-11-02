namespace _04.WordFilter;

class Program
{
    static void Main(string[] args)
    {
        ////Var 1
        //List<string> words = Console.ReadLine()
        //    .Split()
        //    .Where(x => x.Length % 2 == 0)
        //    .ToList();

        //Console.WriteLine(string.Join(Environment.NewLine, words));

        // Var 2

        Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
            .Split()
            .Where(x => x.Length % 2 == 0)
            .ToList()));


    }
}


