/*
5
S---9
777-1
--5--
11W11
988--
down
down
down
down
down
down
right
right
right
collect the nets

4
---S
----
9-5-
34--
down
down
right
down
collect the nets

4
-,-,-,S
-,-,-,-
9,-,5,-
3,4,-,-
 
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        //задаваме големината на матрицата
        int n = int.Parse(Console.ReadLine());

        //четем матрицата с метод за char матрица
        char[,] matrix = ReadCharMatrix(n, n);

        //така намираме къде е старта. Задаваме нулеви параметри и започваме да търсим S, когато го намерим сетваме координатите за начални
        int currentRow = 0;
        int currentCol = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == 'S')
                {
                    currentRow = row;
                    currentCol = col;
                    break;
                }
            }
        }

        // правиме променлива да пазим уловената риба
        int caughtFish = 0;

        //стартираме четенето на командите
        string command = Console.ReadLine();

        while (command != "collect the nets")
        {
            //понеже сме на тази позиция, слагаме -
            matrix[currentRow, currentCol] = '-';

            // тук вместо if ползваме енумерация като кастваме с долната команда енумерацията към променливата direction
            Direction direction = (Direction)Enum.Parse(typeof(Direction), command);
            switch (direction)
            {
                case Direction.down:
                    currentRow++; //увеличаваме надолу 
                    if (currentRow >= n) //ако преско§им матрицта сетваме реда на нулев
                    {
                        currentRow = 0;
                    }
                    break;
                case Direction.up:// увеличаваме нагоре
                    currentRow--;
                    if (currentRow < 0) // ако прескочим нулеивя ред задаваме координати на най-долния в матрицата, така оставаме в матрицата
                    {
                        currentRow = n - 1;
                    }
                    break;
                case Direction.left: //тук десйтваме както горните
                    currentCol--;
                    if (currentCol < 0)
                    {
                        currentCol = n - 1;
                    }
                    break;
                case Direction.right:
                    currentCol++;
                    if (currentCol >= n)
                    {
                        currentCol = 0;
                    }
                    break;
                default: break;
            }

            // тук правим проверки на какво сме попаднали
            if (matrix[currentRow, currentCol] != '-') // нищо не се случва
            {
                if (matrix[currentRow, currentCol] == 'W') //потапяме кораба
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");
                    return;
                }
                else // добавяме рибата към улова, взимаме символа от моментните координати и го правим на стринг след което го парсваме към "int"
                {
                    caughtFish += int.Parse(matrix[currentRow, currentCol].ToString());
                }
            }

            // слагаме маркер на координатите в които сме в момента "S"
            matrix[currentRow, currentCol] = 'S';

            //четем и продължаваме напред
            command = Console.ReadLine();// слагаме задължително в края
        }
        // тук свуршва while цикъла


        //правим проверка за улова
        if (caughtFish < 20)
        {
            Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {20 - caughtFish} tons of fish more.");
        }
        else
        {
            Console.WriteLine("Success! You managed to reach the quota!");
        }


        //и в двата случая печатаме улова
        if (caughtFish > 0)
            Console.WriteLine($"Amount of fish caught: {caughtFish} tons.");

        //печатаме резултата
        PrintMatrixAbs(matrix, symbol =>
        {
            Console.Write(symbol);
        });


    }

    // това ни е енумерацията

    enum Direction
    {
        down,
        up,
        left,
        right
    }


    //от тук започват методите


    // със сепаратор
    // използва се с
    //char[,] matrix = ReadCharMatrix(n, n, " ");
    public static char[,] ReadCharMatrixSeparator(int rows, int cols, string separator)
    {
        char[,] matrix = new char[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            //string rowArray = Console.ReadLine(); //без сепаратор
            char[] rowArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = rowArray[col];
            }
        }
        return matrix;
    }

    // без сепаратор
    // използва се с
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


    //int[,] matrix = ReadIntMatrix(n, n, " ");
    private static int[,] ReadIntMatrix(int rows, int cols, string separator)
    {
        int[,] matrix = new int[rows, cols];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            int[] rowArray = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

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

    //PrintMatrixAbs(matrix, Console.Write); //така извикваме принт метода
    //PrintMatrixAbs(matrix, symbol =>
    //    {
    //       Console.Write(symbol + " ");
    //    });

    static void PrintMatrixAbs<T>(T[,] matrix, Action<T> print)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                print(matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

 

}