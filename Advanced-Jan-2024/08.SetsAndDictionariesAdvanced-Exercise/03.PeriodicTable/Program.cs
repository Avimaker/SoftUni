/*
4
Ce O
Mo O Ce
Ee
Mo

3
Ge Ch O Ne
Nb Mo Tc
O Ne

*/

namespace _03.PeriodicTable;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        SortedSet<string> elements = new SortedSet<string>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            for (int k = 0; k < input.Length; k++)
            {
                elements.Add(input[k]);
            }

        }

        //foreach (var element in elements)
        //{
        //    Console.Write($"{element} ");
        //}

        Console.Write(string.Join(" ", elements));

    }
}

