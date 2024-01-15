/*
3 4
A B B D
E B B B
I J B B

*/

namespace _2.SquaresInMatrix;

class Program
{
    static void Main(string[] args)
    {
        int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int rows = size[0];
        int cols = size[1];
        int squaresFound = 0;
        string[] previousRow = null;

        for (int row = 0; row < rows; row++)
        {
            string[] currentRow = Console.ReadLine().Split();

            for (int col = 0; col < cols - 1; col++)
            {
                if (row > 0)
                {
                    if (currentRow[col] == previousRow[col] &&
                        currentRow[col] == previousRow[col + 1] &&
                        currentRow[col + 1] == previousRow[col])
                    {
                        squaresFound++;
                    }
                }
            }
            previousRow = currentRow;
        }
        Console.WriteLine(squaresFound);
    }
}

