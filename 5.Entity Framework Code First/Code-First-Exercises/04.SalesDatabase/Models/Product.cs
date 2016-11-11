using System.Collections.Generic;

namespace _04.SalesDatabase.Models
{
    public class Product
    {
        public Product()
        {
            SalesOfProduct = new HashSet<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Sale> SalesOfProduct { get; set; }

    }
}