/*
In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 **Tigers**, 1 ::Elephant:, 12 **Monk3ys**, a **Gorilla::, 5 ::fox:es: and 21 different types of :Snak::Es::. ::Mooning:: **Shy**

5, 4, 3, 2, 1, go! The 1-th consecutive banana-eating contest has begun! ::Joy:: **Banana** ::Wink:: **Vali** ::valid_emoji::

It is a long established fact that 1 a reader will be distracted by 9 the readable content of a page when looking at its layout. The point of using ::LoremIpsum:: is that it has a more-or-less normal 3 distribution of 8 letters, as opposed to using 'Content here, content 99 here', making it look like readable **English**.
 
*/

using System.Text.RegularExpressions;

namespace _05.HeroesOfCodeAndLogicVII;

class Program
{
    static void Main(string[] args)
    {

        string emojiPattern = @"(\*{2}|\:{2})(?<Emoji>[A-Z][a-z]{2,})\1";
        string coolTresholdPattern = @"\d";

        List<string> coolEmojies = new List<string>();

        string input = Console.ReadLine();

        ulong coolThreshold = 1;

        foreach (Match match in Regex.Matches(input, coolTresholdPattern))
        {
            coolThreshold *= ulong.Parse(match.Value);
        }

        MatchCollection matches = Regex.Matches(input, emojiPattern);
        foreach (Match match in matches)
        {
            string emojiString = match.Groups["Emoji"].Value;

            ulong totalEmojiSum = 0;
            foreach (char character in emojiString)
            {
                totalEmojiSum += character;
            }

            if (totalEmojiSum >= coolThreshold)
            {
                coolEmojies.Add(match.Value);
            }
        }

        Console.WriteLine($"Cool threshold: {coolThreshold}");
        Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");
        coolEmojies.ForEach(emoji => Console.WriteLine(emoji));

    }
}

