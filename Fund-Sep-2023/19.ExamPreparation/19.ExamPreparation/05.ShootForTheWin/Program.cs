/*
24 50 36 70
0
4
3
1
End

30 30 12 60 54 66
5
2
4
0
End

 */



namespace _05.ShootForTheWin;

class Program
{
    static void Main(string[] args)
    {
        List<int> targets = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        int shotTargets = 0;
        string command = default;
        while ((command = Console.ReadLine()) != "End")
        {
            int inputIndex = int.Parse(command);

            if (inputIndex < targets.Count) // proverka za indeksa dali e w dylvinata na lista
            {
                int checkIndex = targets[inputIndex];
                targets[inputIndex] = -1;

                for (int index = 0; index < targets.Count; index++)
                {
                    if (targets[index] > checkIndex && targets[index] != -1)// mishenata e golqma i mahame ot drugite i e razlichna ot -1
                    {
                        targets[index] -= checkIndex;
                    }
                    else if (targets[index] <= checkIndex && targets[index] != -1)//mishenata e malka i dobaviame kym drugite ako ne e -1
                    {
                        targets[index] += checkIndex;
                    }
                    
                }
                shotTargets++;
            }// if end
        }// while end

        Console.Write($"Shot targets: {shotTargets} -> ");

        for (int i = 0; i < targets.Count; i++)
        {
            Console.Write($"{targets[i]} ");
        }

    }
}

