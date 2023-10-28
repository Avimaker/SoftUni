/*
3
title1, C, author1
title2, B, author2
title3, A, author3
*/

namespace _03.Articles2._0;

class Article
{
    public Article()
    {
    }

    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        int inputLineCount = int.Parse(Console.ReadLine());

        List<Article> listInputs = new List<Article>();

        for (int i = 0; i < inputLineCount; i++)
        {
            string[] artclsInput = Console.ReadLine().Split(", ").ToArray();

            Article articles = new Article(artclsInput[0], artclsInput[1], artclsInput[2]);
            listInputs.Add(articles);

        }

        foreach (var row in listInputs)
        {
            Console.WriteLine(row);
            //Console.WriteLine(row.ToString); //същото е като горното
        }

        Console.WriteLine(string.Join("\n", listInputs)); // \n е за нов ред


    }
}

