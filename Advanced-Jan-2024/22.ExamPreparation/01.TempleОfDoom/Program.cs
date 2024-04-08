/*

2 4 6 8
11 3 5 7 9
24 28 18 30


13 7 4 22 11 15 20
3 2 1
12 10 5


*/



namespace _01.TempleОfDoom;
class Program
{
    static void Main(string[] args)
    {
        Queue<int> tools = new Queue<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        Stack<int> substances = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

        List<int> artefacts = new List<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());


        while (true)
        {
            int tool = tools.Peek(); //deque
            int substance = substances.Peek(); //pop

            int craftTool = tool * substance;
            //int searchedArtefact = artefacts.FirstOrDefault(x => x == craftTool);

            if (artefacts.Contains(craftTool))
            {
                artefacts.Remove(craftTool);
                tools.Dequeue();
                substance = substances.Pop();

                if (artefacts.Count == 0)
                {
                    Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;
                }

            }
            else
            {
                int temp = tools.Dequeue();
                tools.Enqueue(temp + 1);
                int tempSub = substances.Pop();
                substances.Push(tempSub - 1);

                if (substances.Peek() == 0)
                {
                    substances.Pop();
                }

                if (substances.Count == 0)
                {
                    Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                    break;
                }
            }
        }


        if (tools.Count != 0)
        {
            Console.WriteLine($"Tools: {string.Join(", ", tools)}");
        }
        if (substances.Count != 0)
        {
            Console.WriteLine($"Substances: {string.Join(", ", substances)}");
        }
        if (artefacts.Count != 0)
        {
            Console.WriteLine($"Challenges: {string.Join(", ", artefacts)}");
        }
    }

}