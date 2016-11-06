
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    class Author
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
