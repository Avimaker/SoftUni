/*

5
-----
-PM--
-M---
---H-
-X---
down
right
down
down
left


8
--H-----
---P---X
--------
--M--M--
--H--M--
H-----M-
--------
------H-
down
right
right
down
down
right
down
left
up
up


4
----
P-H-
----
X---
right
right
right
right
down
down
down
left
left
left



 */

namespace _02.EscapeTheMaze;
class Program
{
    static void Main(string[] args)
    {
        int health = 100;

        //задаваме големината на матрицата
        int n = int.Parse(Console.ReadLine());

        //четем матрицата с метод за char матрица
        char[,] matrix = ReadCharMatrix(n, n);

        //така намираме къде е старта. Задаваме нулеви параметри и започваме да търсим P, когато го намерим сетваме координатите за начални

        int currentRow = 0;
        int currentCol = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == 'P')
                {
                    currentRow = row;
                    currentCol = col;
                    break;
                }
            }
        }

        //стартираме четенето на командите
        string command = Console.ReadLine();

        while (health > 0)
        {
            //понеже сме на тази позиция, слагаме -
            matrix[currentRow, currentCol] = '-';

            Direction direction = (Direction)Enum.Parse(typeof(Direction), command);
            switch (direction)
            {
                case Direction.down:
                    currentRow++; //увеличаваме надолу 
                    if (currentRow >= n) //ако прескочим матрицта сетваме реда на нулев
                    {
                        currentRow = n - 1;
                    }
                    break;
                case Direction.up:
                    currentRow--;
                    if (currentRow < 0)
                    {
                        currentRow = 0;
                    }
                    break;
                case Direction.left:
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol = 0;
                    }
                    break;
                case Direction.right:
                    currentCol++;
                    if (currentCol >= n)
                    {
                        currentCol = n-1;
                    }
                    break;
                default: break;
            }

            // тук правим проверки на какво сме попаднали
            if (matrix[currentRow, currentCol] != '-') // нищо не се случва
            {
                if (matrix[currentRow, currentCol] == 'H') //лекуваме се
                {
                    health += 15;
                    if (health > 100)
                    {
                        health = 100;
                    }
                    matrix[currentRow, currentCol] = '-';

                }

                if (matrix[currentRow, currentCol] == 'M') //битката започва
                {
                    health -= 40;

                    if (health <= 0)
                    {
                        Console.WriteLine($"Player is dead. Maze over!");
                        Console.WriteLine("Player's health: 0 units");
                        matrix[currentRow, currentCol] = 'P';
                        PrintMatrix(matrix);
                        return;
                    }

                    else
                    {
                        matrix[currentRow, currentCol] = '-';
                    }
                }

                if (matrix[currentRow, currentCol] == 'X') //изход
                {
                    matrix[currentRow, currentCol] = 'P';
                    Console.WriteLine($"Player escaped the maze. Danger passed!");
                    Console.WriteLine($"Player's health: {health} units");

                    PrintMatrix(matrix);
                    return;
                }

                // слагаме маркер на координатите в които сме в момента "P"
                matrix[currentRow, currentCol] = 'P';
            }

            //четем и продължаваме напред
            command = Console.ReadLine();// слагаме задължително в края
        }
        // тук свуршва while цикъла


        Console.WriteLine($"Player escaped the maze. Danger passed!");
        Console.WriteLine($"Player's health: {health} units");

        PrintMatrix(matrix);




    }

    //char[,] matrix = ReadCharMatrix(n, n);
    public static char[,] ReadCharMatrix(int rows, int cols)
    {
        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string rowArray = Console.ReadLine(); //без сепаратор

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowArray[col];
            }
        }
        return matrix;
    }

    //PrintMatrix(matrix); //така извикваме принт метода
    static void PrintMatrix<T>(T[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    enum Direction
    {
        down,
        up,
        left,
        right
    }


}

