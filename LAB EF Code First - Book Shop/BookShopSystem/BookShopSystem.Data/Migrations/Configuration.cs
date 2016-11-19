
namespace BookShopSystem.Data.Migrations
{
    using System.Globalization;
    using System.IO;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookShopSystem.Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BookShopSystem.Data.BookShopContext context)
        {
        }
        private void AddCategoriesToBooks(BookShopContext context)
        {
            var categories = context.Categories.ToList();
            var books = context.Books;
            for (int i = 0; i < 3; i++)
            {
                foreach (Book book in books)
                {
                    Random rnd = new Random();
                    int categoryIndex = rnd.Next(1, categories.Count());
                    book.Categories.Add(categories[categoryIndex]);
                }
            }
        }

        private void AddBooksToAuthorToDatabase(BookShopContext context)
        {
            Random random = new Random();
            var authors = context.Authors.ToList();
            var books = context.Books.ToList();
            foreach (Book book in books)
            {
                var authorIndex = random.Next(1, authors.Count());
                var authorId = authors[authorIndex].Id;
                book.AuthorId = authorId;
            }
            context.SaveChanges();
        }

        private void AddCategoriesToDatabase(BookShopContext context)
        {
            using (var reader = new StreamReader(@"D:\SOFTUNI-C#\DB Advance Entity Framework\LAB EF Code First - Book Shop\BookShopSystem\Resources\categories.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);

                    context.Categories.Add(new Category()
                    {
                        Name = line
                    });

                    context.SaveChanges();
                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }

        public void AddAuthorToDatabase(BookShopContext context)
        {
            using (var reader = new StreamReader(@"D:\SOFTUNI-C#\DB Advance Entity Framework\LAB EF Code First - Book Shop\BookShopSystem\Resources\authors.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    var authorData = line.Split(new[] { ' ' });

                    var firstName = authorData[0];
                    var lastName = authorData[1];

                    context.Authors.Add(new Author()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });

                    context.SaveChanges();
                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }
        
        public void AddBooksToDatabase(BookShopContext context)
        {
            using (var reader = new StreamReader(@"D:\SOFTUNI-C#\DB Advance Entity Framework\LAB EF Code First - Book Shop\BookShopSystem\Resources\books.txt"))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    var bookData = line.Split(new[] { ' ' }, 6);

                    var editionType = (EditionType)int.Parse(bookData[0]);
                    var releaseDate = DateTime.ParseExact(bookData[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                    var copies = int.Parse(bookData[2]);
                    var price = decimal.Parse(bookData[3]);
                    var ageRestriction = (AgeRestriction)int.Parse(bookData[4]);
                    var title = bookData[5];

                    Random random = new Random();
                    var authors = context.Authors.ToList();
                    var authorIndex = random.Next(1, authors.Count());
                    var authorId = authors[authorIndex].Id;

                    context.Books.Add(new Book()
                    {
                        Title = title,
                        Type = editionType,
                        Price = price,
                        Copies = copies,
                        ReleaseDate = releaseDate,
                        AuthorId = authorId,
                        AgeRestriction = ageRestriction
                    });

                    context.SaveChanges();
                    line = reader.ReadLine();
                }
                context.SaveChanges();
            }
        }

    }
}
