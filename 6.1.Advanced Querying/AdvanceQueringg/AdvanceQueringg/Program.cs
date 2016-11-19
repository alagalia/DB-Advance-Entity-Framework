using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceQueringg
{
    class Program
    {
        static void Main(string[] args)
        {
            BookShopSystemEntities context = new BookShopSystemEntities();

            //1.	Books Titles by Age Restriction
           // Write a program that selects and prints titles of all books where their age restriction matches the given input(minor, teen or adult).Ignore casing of the input.
            string restriction = Console.ReadLine();
            var restrict = 2;
            if (restriction != null && restriction.ToLower() == "minor")
            {
                restrict = 0;
            }else if (restriction != null && restriction.ToLower() == "teen")
            {
                restrict = 1;
            }
            var books = context.Books.Where(b=>b.AgeRestriction == restrict);

            foreach (Books book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
