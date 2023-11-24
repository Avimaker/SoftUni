/*
2
@#FreshFisH@#
##InvaliDiteM##


6
@###Val1d1teM@###
@#ValidIteM@#
##InvaliDiteM##
@InvalidIteM@
@#Invalid_IteM@#
@#ValiditeM@#


*/

using System.Text.RegularExpressions;

namespace _02.FancyBarcodes;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string pattern = @"@#+(?<barcode>[A-Z]{1}[A-Za-z-0-9]{4,}[A-Z]{1})@#+";


        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(pattern);
            Match match = regex.Match(input);

            string testBarcode = match.Groups["barcode"].Value;
            bool isExist = match.Success;

            if (isExist == false)
            {
                Console.WriteLine("Invalid barcode");
                continue;
            }

            string digitResult = new string(input.Where(x => char.IsDigit(x)).ToArray());
            if (digitResult == "")
            {
                Console.WriteLine($"Product group: 00");
            }
            else
            {
                Console.WriteLine($"Product group: {digitResult}");
            }

        }


    }
}
