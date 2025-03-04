namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Text;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            DbInitializer.ResetDatabase(dbContext);

            ////Problem 02
            //string command = Console.ReadLine();
            //string result = GetBooksByAgeRestriction(dbContext, command);
            //Console.WriteLine(result);


            ////Problem 03
            //string result = GetGoldenBooks(dbContext);
            //Console.WriteLine(result);

            ////Problem 04
            //string result = GetBooksByPrice(dbContext);
            //Console.WriteLine(result);

            ////Problem 05
            //int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(dbContext, year);
            //Console.WriteLine(result);


            ////Problem 06
            //string input = Console.ReadLine();
            //string result = GetBooksByCategory(dbContext, input);
            //Console.WriteLine(result);

            ////Problem 07
            //string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(dbContext, date);
            //Console.WriteLine(result);

            ////Problem 08
            //string input = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(dbContext, input);
            //Console.WriteLine(result);


            ////Problem 09
            //string input = Console.ReadLine();
            //string result = GetBookTitlesContaining(dbContext, input);
            //Console.WriteLine(result);

            ////Problem 10
            //string input = Console.ReadLine();
            //string result = GetBooksByAuthor(dbContext, input);
            //Console.WriteLine(result);

            ////Problem 11
            //int lengthCheck = int.Parse(Console.ReadLine());
            //int result = CountBooks(dbContext, lengthCheck);
            //Console.WriteLine($"There are {result} books with longer title than {lengthCheck} symbols");

            ////Problem 12
            //string result = CountCopiesByAuthor(dbContext);
            //System.Console.WriteLine(result);

            ////Problem 13
            //string result = GetTotalProfitByCategory(dbContext);
            //System.Console.WriteLine(result);

            ////Problem 14
            //string result = GetMostRecentBooks(dbContext);
            //System.Console.WriteLine(result);

            ////Problem 15
            //IncreasePrices(dbContext);

            ////Problem 16
            //int result = RemoveBooks(dbContext);
            //System.Console.WriteLine(result);
        }


        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate == null || b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var books = context.Books
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value < targetDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    EditionType = b.EditionType.ToString(),
                    b.Price
                })
                .ToList();

            var formattedBooks = books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}").ToList();

            return string.Join(Environment.NewLine, formattedBooks);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName != null &&
                            a.FirstName.ToLower().EndsWith(input.ToLower()))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .AsEnumerable() // приключваме с базата и минаваме в паметта
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(name => name)
                .ToList();

            return string.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string inputLower = input.ToLower();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(inputLower))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string searchString = input.ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(searchString))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName
                })
                .AsEnumerable()
                .Select(b => $"{b.Title} ({(b.AuthorFirstName != null ? $"{b.AuthorFirstName} " : "")}{b.AuthorLastName})")
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .AsEnumerable()
                .Select(a => $"{(a.FirstName != null ? a.FirstName + " " : "")}{a.LastName} - {a.TotalCopies}")
                .ToList();

            return string.Join("\n", authors);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Sum(bc => bc.Book.Copies * bc.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .Select(c => $"{c.Name} ${c.Profit:F2}")
                .ToList();

            return string.Join("\n", categories);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(bc => bc.Book)
                .OrderBy(c => c.Name)
                .AsEnumerable()
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                        .Select(bc => bc.Book)
                        .Where(b => b.ReleaseDate.HasValue)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            Title = b.Title,
                            Year = b.ReleaseDate.Value.Year
                        })
                        .ToList()
                })
                .Where(c => c.Books.Any())
                .ToList();

            var output = new StringBuilder();

            foreach (var category in categories)
            {
                output.AppendLine($"--{category.CategoryName}");
                foreach (var book in category.Books)
                {
                    output.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return output.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                           b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToDelete = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int deletedCount = booksToDelete.Count;

            context.Books.RemoveRange(booksToDelete);
            context.SaveChanges();


            return deletedCount;
        }

        //public static int RemoveBooks(BookShopContext context)
        //{
        //    int deletedCount = context.Books
        //        .Where(b => b.Copies < 4200)
        //        .ExecuteDelete();

        //    return deletedCount;
        //}

    }
}


