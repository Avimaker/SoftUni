/*
@mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r

#po0l##l0op# @bAc##cAB@ @LM@ML@ #xxxXxx##xxxXxx# @aba@@ababa@

#lol#lol# @#God@@doG@# #abC@@Cba# @Xyu@#uyX#

pattern:
(\@{1}|\#{1})(?<word>[A-Za-z]{3,})(\1)(\@{1}|\#{1})(?<mirror>[A-Za-z]{3,})(\1)
 
*/


using System.Text.RegularExpressions;

namespace _07.MirrorWords;

class Pair
{
    public Pair(string word, string mirror)
    {
        Word = word;
        Mirror = mirror;
    }

    public string Word { get; set; }
    public string Mirror { get; set; }

    public override string ToString()
    {
        return $"{Word} <=> {Mirror}";
    }
}



class Program
{
    public static string ReversedMirror(string mirror)
    {
        char[] reversedMirrorChar = mirror.ToCharArray();
        Array.Reverse(reversedMirrorChar);
        string reversedMirror = new string(reversedMirrorChar);
        return reversedMirror;
    }

    static void Main(string[] args)
    {

        string input = Console.ReadLine();
        string pattern = @"(\@{1}|\#{1})(?<word>[A-Za-z]{3,})(\1)(\@{1}|\#{1})(?<mirror>[A-Za-z]{3,})(\1)";

        List<Pair> binded = new List<Pair>();

        MatchCollection matches = Regex.Matches(input, pattern);

        foreach (Match match in matches)
        {
            string word = match.Groups["word"].Value;
            string mirror = match.Groups["mirror"].Value;

            if (word == ReversedMirror(mirror))
            {
                Pair currentPair = new Pair(word, mirror);
                binded.Add(currentPair);
            }
        }

        if (matches.Count == 0)
        {
            Console.WriteLine("No word pairs found!");
        }
        else
        {
            Console.WriteLine($"{matches.Count} word pairs found!");
        }

        if (binded.Count > 0)
        {
            Console.WriteLine("The mirror words are:");
            Console.WriteLine(string.Join(", ", binded));
        }
        else
        {
            Console.WriteLine("No mirror words!");
        }
    }
}

