/*
some title, some content, some author
3
Edit: better content
ChangeAuthor:  better author
Rename: better title
*/

namespace _02.Articles;

class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }

    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public void ChangeAutor(string newAutor)
    {
        Author = newAutor;
    }

    // това е метод овърайд - с него като напишем конзол райтлайн
    // Console.WriteLine(инстанцията); - тя ще бъде форматирана
    // Console.WriteLine(article)
    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}"; 
    }

    //public void ToString()
    //{
    //    Console.WriteLine($"{Title} - {Content}: {Autor}");
    //}

    // тук във мейна го викаме
    // инстанцията.ToString();
    // article.ToString();
}

class Program
{
    static void Main(string[] args)
    {

        string[] firstContentRead = Console.ReadLine()
            .Split(", ")
            .ToArray();
         
        Article article = new Article(firstContentRead[0],
            firstContentRead[1], firstContentRead[2]);

        int commandCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandCount; i++)
        {
            string[] command = Console.ReadLine().Split(": ");

            switch (command[0])
            {
                case "Edit":
                    article.Edit(command[1]);// 1ви вариант
                    break;
                case "ChangeAuthor":
                    string newAuthor = command[1];// 2ри начин
                    article.ChangeAutor(newAuthor);
                    break;
                case "Rename":
                    article.Rename(command[1]);
                    break;
            }
        }

        Console.WriteLine(article);
        //article.ToString(); //това е за без overide

    }
}

