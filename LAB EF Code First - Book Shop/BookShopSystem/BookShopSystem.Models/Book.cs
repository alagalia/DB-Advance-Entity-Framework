using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    public enum EditionType
    {
        Normal, Promo, Gold
    }

    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }

    public class Book
    {
        private ICollection<Category> categories;

        public Book()
        {
            this.categories = new List<Category>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public EditionType Type { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        } 
    }
}
