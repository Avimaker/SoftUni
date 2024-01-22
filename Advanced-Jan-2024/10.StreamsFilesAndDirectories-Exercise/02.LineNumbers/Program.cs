using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers;

public class LineNumbers
{
    static void Main()
    {
        string inputFIlePath = @"../../../text.txt";
        string outputFIlePath = @"../../../output.txt";

        ProcessLines(inputFIlePath, outputFIlePath);
    }

    public static void ProcessLines(string inputFilePath, string outputFilePath)
    {

        StringBuilder text = new();

        string[] lines = File.ReadAllLines(inputFilePath);

        for (int i = 0; i < lines.Length; i++)
        {
            int lettersCount = lines[i].Count(char.IsLetter);
            int symbolsCount = lines[i].Count(char.IsPunctuation);

            text.Append($"Line {i + 1}: {lines[i]} ({lettersCount})({symbolsCount})");
        }

        File.WriteAllText(outputFilePath, text.ToString().TrimEnd());
    }
}
