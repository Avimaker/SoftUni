/*
5 8 4 6
3 7 2 9

4 6 8 10 12 16
16 12 10 8 6 4

3 3 3 3 3
4 4 4 4
 
 
 */


namespace _01.PiePursuit;
class Program
{
    static void Main(string[] args)
    {
        Queue<int> contestants = new Queue<int>(Console.ReadLine()
           .Split(" ", StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray());


        Stack<int> pies = new Stack<int>(Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());


        while (contestants.Count != 0 && pies.Count != 0)
        {
            int contestant = contestants.Peek();
            int pie = pies.Peek();
            int result = Math.Abs(contestants.Peek() - pies.Peek());

            if (contestant >= pie && pies.Count > 0)
            {


                if (contestant == pie) // = 0
                {
                    contestants.Dequeue();

                }
                else
                {
                    contestants.Dequeue();
                    contestants.Enqueue(result);
                }

                pies.Pop();

            }

            else
            {

                int newPieSize = pie - contestant;

                if (newPieSize == 1) // пай 1 парче
                {
                    if (pies.Count != 1)
                    {
                        pies.Pop();
                        pies.Push(pies.Pop() + 1);//next pcs + 1 and return
                    }
                    else
                    {
                        pies.Pop();
                        pies.Push(newPieSize);
                    }
                }
                else
                {
                    pies.Pop();
                    pies.Push(newPieSize);
                }

                contestants.Dequeue();// заминава си


            }
        }

        if (contestants.Count > 0 && pies.Count == 0)
        {
            Console.WriteLine("We will have to wait for more pies to be baked!");
            Console.WriteLine($"Contestants left: {contestants.Count}");
        }
        else if (contestants.Count == 0 && pies.Count > 0)
        {
            Console.WriteLine("Our contestants need to rest!");
            Console.WriteLine($"Pies left: {pies.Count}");
        }
        else if (contestants.Count == 0 && pies.Count == 0)
        {
            Console.WriteLine("We have a champion!");
        }

    }
}

