namespace _01.CountCharsInAStringNew;


class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var charOccurrences = new Dictionary<char, int>();


        for (int i = 0; i < input.Length; i++)
        {
            char character = input[i];

            if (character == ' ')
            {
                continue;
            }

            // Var 1 
            //if (!charOccurrences.ContainsKey(character)) // if exist
            //{
            //    charOccurrences[character] = 0;
            //}

            //if (charOccurrences.ContainsKey(character)) // if exist
            //{
            //    charOccurrences[character]++;
            //}


            //// Var 2 проверяваме дали съществува в дикшънарито
            if (!charOccurrences.ContainsKey(character)) // if not exist
            {
                charOccurrences.Add(character, 0);
            }

            charOccurrences[character]++;
        }

        ////var 1 за изписване
        //foreach (KeyValuePair<char, int> kvp in charOccurrences) //kvp вместо item за да свикна
        //{
        //    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
        //}


        // var 2 за изписване
        foreach (var occuence in charOccurrences)
        {
            char character = occuence.Key;
            int count = occuence.Value;
            Console.WriteLine($"{character} -> {count}");
        }

    }
}


