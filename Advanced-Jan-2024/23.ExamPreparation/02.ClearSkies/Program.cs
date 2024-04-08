/*
5
-R---
-J--E
-E---
--E-E
-R---
up
down
down
down
right
right
right

4
-R--
-JEE
-E-R
--E-
right
right
down
left
left
down
right

5
-J--E
-R--E
-E--R
--R-E
-R---
right
right
right
down
down
down
left
left
left
up


 
 */

namespace _02.ClearSkies;
class Program
{
    static void Main(string[] args)
    {
        int armor = 300;

        //задаваме големината на матрицата
        int n = int.Parse(Console.ReadLine());

        //четем матрицата с метод за char матрица
        char[,] matrix = ReadCharMatrix(n, n);

        //така намираме къде е старта. Задаваме нулеви параметри и започваме да търсим J, когато го намерим сетваме координатите за начални

        int currentRow = 0;
        int currentCol = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == 'J')
                {
                    currentRow = row;
                    currentCol = col;
                    break;
                }
            }
        }

        //намирам колко са вражеските самолети
        int enemyPlanes = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col] == 'E')
                {
                    enemyPlanes++;
                }
            }
        }

        //стартираме четенето на командите
        string command = Console.ReadLine();

        while (armor > 0)
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
                if (matrix[currentRow, currentCol] == 'R')
                {
                    armor = 300;
                }

                if (matrix[currentRow, currentCol] == 'E') //битката започва
                {
                    armor -= 100;

                    if (armor <= 0)
                    {
                        Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                        matrix[currentRow, currentCol] = 'J';
                        PrintMatrix(matrix);
                        return;
                    }

                    enemyPlanes--;

                    if (enemyPlanes == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                        matrix[currentRow, currentCol] = 'J';
                        PrintMatrix(matrix);
                        return;
                    }
                }

                // слагаме маркер на координатите в които сме в момента "J"
                matrix[currentRow, currentCol] = 'J';
            }

            //четем и продължаваме напред
            command = Console.ReadLine();// слагаме задължително в края
        }
        // тук свуршва while цикъла


        PrintMatrix(matrix);

        //край
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

