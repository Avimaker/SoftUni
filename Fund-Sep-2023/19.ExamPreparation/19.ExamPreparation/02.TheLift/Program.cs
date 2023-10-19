/*
15
0 0 0 0

16
0 0 0 0

20
0 2 0

1
0

5
0

6
3

2
4 2 3

15
0 0 0 0 0 0

 */


namespace _02.TheLift;

class Program
{
    static void Main(string[] args)
    {
        int people = int.Parse(Console.ReadLine());

        List<int> liftNumbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        int liftMaxSpace = 4;
        int currentSpace = 0;
        int counter = 0;

        while (people >= 0 && counter < liftNumbers.Count)
        {
            for (int i = 0; i < liftNumbers.Count; i++)
            {

                int currentLiftSpace = liftMaxSpace - liftNumbers[i];

                if (people < currentLiftSpace && i == 0)
                {
                    liftNumbers[i] += people;
                    counter++;
                }
                else if (people > currentLiftSpace)
                {
                    liftNumbers[i] = liftMaxSpace;
                    people -= currentLiftSpace;
                    counter++;
                }
                else if (people == currentLiftSpace)
                {
                    liftNumbers[i] = liftMaxSpace;
                    people -= currentLiftSpace;
                    counter++;
                }
                else if (people < currentLiftSpace && people > 0)
                {
                    liftNumbers[i] += people;
                    people = people - people;
                    counter++;
                }

            }


            if (people < liftMaxSpace && liftNumbers[^1] < 4)//dhdh
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", liftNumbers));
                return;
            }

            if (liftNumbers[0] == 4)
            {

                if (people == 0)
                {
                    Console.WriteLine(string.Join(" ", liftNumbers));
                    return;
                }

                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", liftNumbers));
                return;
            }



            int check = 0;
            for (int i = 0; i < liftNumbers.Count; i++)
            {
                check += 4;
                

            }
            for (int i = 1; i < liftNumbers.Count - 1; i++)
            {

                if (people == 0 && check == (i * 4))
                {
                    Console.WriteLine(string.Join(" ", liftNumbers));
                    return;
                }
                if (people == 0 && check < (i * 4))
                {
                    Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                    Console.WriteLine(string.Join(" ", liftNumbers));
                    return;
                }
                
                if (liftNumbers[^1] < 4)
                {
                    Console.WriteLine("The lift has empty spots!");
                    Console.WriteLine(string.Join(" ", liftNumbers));
                    return;
                }
                if (liftNumbers[^1] == 4)
                {
                    Console.WriteLine(string.Join(" ", liftNumbers));
                    return;
                }

            }
          





        }
    }
}
