/* 
1, 2, 3, 4, 5, 6, 7, 8
1, 2, 3, 4, 5
13, 23, 1, -8, 4, 9
 
*/

namespace Froggy;
class Program
{
    static void Main(string[] args)
    {
        List<int> stones = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Lake lake = new(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}

