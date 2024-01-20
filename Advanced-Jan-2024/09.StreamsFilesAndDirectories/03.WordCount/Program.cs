using System.Diagnostics.CodeAnalysis;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"../../../Files/words.txt";
            string textPath = @"../../../Files/text.txt";
            string outputPath = @"../../../Files/output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader textRead = new StreamReader(textFilePath))
            {
                using (StreamReader wordRead = new StreamReader(wordsFilePath))
                {
                    using (StreamWriter output = new StreamWriter(outputFilePath))
                    {

                        string line = "";
                        string pattern = @"\b\w+(?:'\w+)?\b";
                        Regex regex = new Regex(pattern);

                        string[] wordsForCheck = wordRead.ReadLine().Split();

                        MatchCollection matches = regex.Matches(textRead.ReadToEnd());
                        List<string> listForCheck = new List<string>();

                        foreach (var match in matches)
                        {
                            listForCheck.Add(match.ToString());
                        }


                        Dictionary<string, int> result = new Dictionary<string, int>();

                        for (int l = 0; l < wordsForCheck.Length; l++)
                        {
                            if (!result.ContainsKey(wordsForCheck[l]))
                            {
                                {
                                    result.Add(wordsForCheck[l], 0);
                                }
                            }

                            for (int i = 0; i < listForCheck.Count; i++)
                            {
                                if (string.Equals(wordsForCheck[l], listForCheck[i], StringComparison.OrdinalIgnoreCase))
                                {
                                    result[wordsForCheck[l]]++;
                                }

                            }

                        }

                        Dictionary<string, int> sortedResult = result.OrderByDescending(k => k.Value).ToDictionary(k => k.Key, k => k.Value);

                        foreach (var item in sortedResult)
                        {
                            output.WriteLine($"{item.Key} - {item.Value}");
                        }

                    }
                }
            }
        }
    }
}
