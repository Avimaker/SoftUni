/*
4
Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress

4
Red -> hat
Red -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
White tanktop

5
Blue -> shoes
Blue -> shoes,shoes,shoes
Blue -> shoes,shoes
Blue -> shoes
Blue -> shoes,shoes
Red tanktop

 
*/

namespace _06.Wardrobe;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] lookFor = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string color = lookFor[0];
            string[] dressList = lookFor[1].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, int> dress = new Dictionary<string, int>();

            if (!wardrobe.ContainsKey(color))
            {
                wardrobe.Add(color, dress);
            }

            for (int c = 0; c < dressList.Length; c++)
            {
                if (!wardrobe[color].ContainsKey(dressList[c]))
                {
                    wardrobe[color].Add(dressList[c], 0);
                }
                wardrobe[color][dressList[c]]++;
            }


        }

        string[] lookForEnd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        string colorEnd = lookForEnd[0];
        string dressEnd = lookForEnd[1];


        //var 1
        //foreach (var col in wardrobe)
        //{
        //    Console.WriteLine($"{col.Key} clothes:");

        //    foreach (var dres in col.Value)
        //    {
        //        if (col.Key == colorEnd && dres.Key == dressEnd)
        //        {
        //            Console.WriteLine($"* {dres.Key} - {dres.Value} (found!)");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"* {dres.Key} - {dres.Value}");
        //        }
        //    }
        //}

        //var2
        foreach (var col in wardrobe)
        {
            Console.WriteLine($"{col.Key} clothes:");

            foreach (var dres in col.Value)
            {
                string printItem = $"* {dres.Key} - {dres.Value}";

                if (col.Key == colorEnd && dres.Key == dressEnd)
                {
                    printItem += " (found!)";
                }
                Console.WriteLine(printItem);
            }
        }


    }
}

