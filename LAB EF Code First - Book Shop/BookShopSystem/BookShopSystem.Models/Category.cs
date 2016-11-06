using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
