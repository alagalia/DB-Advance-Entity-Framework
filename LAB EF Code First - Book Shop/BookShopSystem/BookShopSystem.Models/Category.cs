using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public class Category
    {
        private ICollection<Book> book;

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.book; }
            set { this.book = value; }
        }
    }
}
