
using System;
using System.Linq;
using BookShopSystem.Data;

namespace BookShopSystem.ConsoleClient
{
    public class BookShopMain
    {
        private static void Main()
        {
            //var migrationStrategy = new DropCreateDatabaseIfModelChanges<BookShopContext>();
            //Database.SetInitializer(migrationStrategy);
            var context = new BookShopContext();
            context.Database.Initialize(true);
            //1. get all books after the year 2000.Print only their titles.
            //GetBookAfter2000(context);

            //2.Get all authors with at least one book with release date before 1990.Print their first name and last name.
            //GetAuthorsWithBookReleasedBefore1990(context);

            //3.Get all authors, ordered by the number of their books (descending). Print their first name, last name and book count.	
            //GetAuthorsOrderedByBooksCount(context);

            //4.Get all books from author George Powell, ordered by their release date(descending), then by book title (ascending).Print the book's title, release date and copies.
            //GetBooksByGivenAuthorOrderBy(context);

            //5.  * *Get the most recent books by categories. The categories should be ordered by total book count.Only take the top 3 most recent books from each category -ordered by date (descending), then by title(ascending).Select the category name, total book count and for each book -its title and release date.
            //GetFirst3BookGroupByCategoryOrderByBookCount(context);


            //// Query the first three books to get their names and their related book names
            //GetRelatedBooksTitleFirst3(context);
        }

        private static void GetRelatedBooksTitleFirst3(BookShopContext context)
        {
            var booksFromQuery = context.Books.Take(3).Select(b => new
            {
                b.Title,
                relatedBooks = b.RelatedBooks.Select(relBookk => relBookk.Title)
            });


            foreach (var book in booksFromQuery)
            {
                Console.WriteLine("--{0}", book.Title);
                foreach (var relatedBook in book.relatedBooks)
                {
                    Console.WriteLine(relatedBook);
                }
            }
        }

        private static void GetFirst3BookGroupByCategoryOrderByBookCount(BookShopContext context)
        {
            var categories = context.Categories.OrderByDescending(c => c.Books.Count).Select(category => new
            {
                categoryName = category.Name,
                totalBook = category.Books.Count,
                first3Books =
                    category.Books.OrderByDescending(b => b.ReleaseDate).ThenBy(b => b.Title).Take(3).Select(book => new
                    {
                        book.Title,
                        book.ReleaseDate
                    })
            });

            foreach (var category in categories)
            {
                Console.WriteLine($"--{category.categoryName}: {category.totalBook} books");
                foreach (var book in category.first3Books)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
        }

        private static void GetBooksByGivenAuthorOrderBy(BookShopContext context)
        {
            var books =
                context.Books.Where(book => book.Author.FirstName == "George" && book.Author.LastName == "Powell")
                    .OrderByDescending(book => book.ReleaseDate)
                    .ThenBy(book => book.Title);
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Title} {book.ReleaseDate} {book.Copies}");
            }
        }

        private static void GetAuthorsOrderedByBooksCount(BookShopContext context)
        {
            var authors = context.Authors.OrderByDescending(a => a.Books.Count).Select(a => new
            {
                a.FirstName,
                a.LastName,
                bookCount = a.Books.Count
            });

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} {author.bookCount}");
            }
        }

        private static void GetAuthorsWithBookReleasedBefore1990(BookShopContext context)
        {
            var authors = context.Authors
                .Where(a => a.Books.Any(b => b.ReleaseDate.Value.Year < 2900)).Select(author => new
                {
                    author.FirstName,
                    author.LastName
                });
            foreach (var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }

            //     private static void PrintAuthorsWithBookBefore1990(BookShopContext context)
            //    {
            //        var authors =
            //            context.Authors.Where(
            //                author =>
            //                    author.Books.Count(book => book.ReleaseDate.HasValue && book.ReleaseDate.Value.Year < 1990) != 0);

            //        foreach (Author author in authors)
            //        {
            //            Console.WriteLine(author.FirstName + " " + author.LastName);
            //        }
            //      }
        }

        private static void GetBookAfter2000(BookShopContext context)
        {
            var booksAfter2000 = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year > 2000)
                .Select(book => new
                {
                    book.Title,
                    year = book.ReleaseDate.Value.Year
                }).ToList();

            foreach (var str in booksAfter2000)
            {
                Console.WriteLine(str.Title + " ------- " + str.year);
            }
        }
    }
}
