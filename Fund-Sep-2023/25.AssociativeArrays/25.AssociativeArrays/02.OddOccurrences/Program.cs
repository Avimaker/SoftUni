using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences;

class Program
{
    static void Main(string[] args)
    {
        //string[] words = Console.ReadLine().Split().Select(x => x.ToLower()).ToArray();

        //var numberOccurrences = new Dictionary<string, int>();
        //for (int i = 0; i < words.Length; i++)
        //{

        //    if (!numberOccurrences.ContainsKey(words[i])) // ако не съдържа думата 
        //    {
        //        numberOccurrences.Add(words[i], 0); // да го добави и сложи стойност 0
        //    }

        //    numberOccurrences[words[i]]++; // ако я има увеличавам с едно появяванията
        //}

        //foreach (KeyValuePair<string, int> kvp in numberOccurrences) //kvp вместо item за да свикна
        //{
        //    if (kvp.Value % 2 == 1) //когато стойността е нечетна
        //    {
        //        Console.Write($"{kvp.Key} ");
        //    }

        //}


        string[] words = Console.ReadLine().Split().ToArray();

        var numberOccurrences = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!numberOccurrences.ContainsKey(word.ToLower())) // ако не съдържа думата 
            {
                numberOccurrences.Add(word.ToLower(), 0); // да го добави и сложи стойност 0
            }

            numberOccurrences[word.ToLower()]++; // ако я има увеличавам с едно появяванията
        }

        foreach (KeyValuePair<string, int> kvp in numberOccurrences) //kvp вместо item за да свикна
        {
            if (kvp.Value % 2 == 1) //когато стойността е нечетна
            {
                Console.Write($"{kvp.Key} ");
            }

        }




    }
}

