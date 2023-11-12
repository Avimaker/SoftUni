/*
C:\Internal\training-internal\Template.pptx
*/

using System;
using System.Linq;
using System.IO;

namespace _03.ExtractFile;

class Program
{
    static void Main()
    {
        var filePath = Console.ReadLine();

        string fileName = string.Empty;
        string fileExtension = string.Empty;

        int lastSeparatorIndex = filePath.LastIndexOf('\\');
        int extensionIndex = filePath.LastIndexOf('.');


        fileName = filePath.Substring(lastSeparatorIndex + 1, extensionIndex - lastSeparatorIndex );


        Console.WriteLine($"File name: {fileName}");
        Console.WriteLine($"File extension: {Path.GetExtension(filePath).Replace(".", "")}");

    }


}

