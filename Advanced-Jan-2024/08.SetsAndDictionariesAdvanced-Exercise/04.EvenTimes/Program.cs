/*
3
2
-1
2

5
1
2
3
1
5
*/

namespace _04.EvenTimes;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> evenNumberList = new Dictionary<int, int>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int counter = 0;
            int input = int.Parse(Console.ReadLine());
            if (!evenNumberList.ContainsKey(input))
            {
                evenNumberList.Add(input, counter);
            }
            evenNumberList[input]++;
        }

        //foreach (var even in evenNumberList)
        //{
        //    if (even.Value % 2== 0)
        //    {
        //        Console.WriteLine(even.Key);
        //    }
        //}

        Console.WriteLine(evenNumberList.Single(nc => nc.Value % 2 == 0).Key);
    }
}

