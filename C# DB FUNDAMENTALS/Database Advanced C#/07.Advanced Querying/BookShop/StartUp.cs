namespace BookShop
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Enums;
    using System;
    using System.Linq;
    using System.Text;
    using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                var result = RemoveBooks(db);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var booksTitles = context.Books
                .Where(a => a.AgeRestriction == ageRestriction).
                Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            var result = string.Join(Environment.NewLine, booksTitles);

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookType = EditionType.Gold;

            var books = context.Books
                .Where(b => b.EditionType == bookType && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksTitles = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            return string.Join(Environment.NewLine, booksTitles.Select(b => $"{b.Title} - ${b.Price:F2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, booksTitles);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split().Select(c => c.ToLower());

            var booksTitles = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, booksTitles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var datetime = DateTime.ParseExact(date, "dd-MM-yyyy",null);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < datetime)
                .OrderByDescending(
b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                }).ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}"));
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, $"%{input}"))
                .Select(a => new
            {
                FullName = a.FirstName + " " + a.LastName
            })
                .OrderBy(a => a)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => a.FullName));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => EF.Functions.Like(b.Title.ToLower(), $"%{input.ToLower()}%"))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => EF.Functions.Like(b.Author.LastName.ToLower(), $"{input.ToLower()}%"))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorsFullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorsFullName})"));


        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title)
                .ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors.Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => $"{a.FullName} - {a.Copies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories.Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            return string.Join(Environment.NewLine, categories.Select(c => $"{c.Name} ${c.TotalProfit:F2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(b => new
                        {
                            b.Book.Title,
                            b.Book.ReleaseDate
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .Update(b => new Book() {Price = b.Price + 5});

            Console.WriteLine($"{books} books has been updated.");
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var result = context.Books
                .Where(b => b.Copies < 4200)
                .Delete();

            return result;
        }
    }
}
