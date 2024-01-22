namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"../../../text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new();

            using StreamReader streamReader = new(inputFilePath);

            string line = string.Empty;

            int counter = 0;

            while (line != null)
            {
                line = streamReader.ReadLine();

                if (counter % 2 == 0)
                {
                    string replacedSymbols = ReplacedSymbols(line);
                    string reversedWords = ReversedWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }
                counter++;
            }
            return sb.ToString().TrimEnd();
        }

        //Method for replacement of symbols in the sentence
        private static string ReplacedSymbols(string line)
        {
            StringBuilder sb = new(line);
            char[] symbolsToReplace = { '-', ',', '.', '!', '?' };

            foreach (var symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol,'@');
            }

            return sb.ToString();
        }

        //Method for reversing the words in the sentence
        private static string ReversedWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            return string.Join(" ", reversedWords);
        }
    }
}
