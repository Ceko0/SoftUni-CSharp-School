namespace BookShop
{
    using System.Text;
    using System.Globalization;

    using Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //int input = int.Parse(Console.ReadLine());

            Console.WriteLine(RemoveBooks(db));

            //IncreasePrices(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new();

            if (!Enum.TryParse(command, true, out AgeRestriction ageRestriction))
            {
                return sb.ToString().TrimEnd();
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
                                 b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();

        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new();

            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => a.FirstName != null &&
                            a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                }) 
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray(); 

            foreach (var author in authors)
            {
                sb
                    .AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var books = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();
            foreach (var book in books)
            {
                sb
                    .AppendLine(book);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();
            var books = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToArray();
            foreach (var book in books)
            {
                sb
                    .AppendLine($"{book.Title} ({book.AuthorName})");
            }
            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context
                .Books
                .Count(b => b.Title.Length > lengthCheck);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var authors = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();
            foreach (var author in authors)
            {
                sb
                    .AppendLine($"{author.FullName} - {author.Copies}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .ToArray();
            foreach (var category in categories)
            {
                sb
                    .AppendLine($"{category.Name} ${category.Profit:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var categories = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Take(3)
                        .Select(cb => new
                        {
                            cb.Book.Title,
                            cb.Book.ReleaseDate.Value.Year
                        })
                        .ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();
            foreach (var category in categories)
            {
                sb
                    .AppendLine($"--{category.Name}");
                foreach (var book in category.Books)
                {
                    sb
                        .AppendLine($"{book.Title} ({book.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();
            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Copies < 4200)
                .ToArray();
            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Length;
        }
    }
}


