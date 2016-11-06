using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.Models
{
    public enum EditionType
    {
        Normal, Promo, Gold
    }

    public class Class1
    {
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

        public DateTime ReleaseDate { get; set; }
    }
}
