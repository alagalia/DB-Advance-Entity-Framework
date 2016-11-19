using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models
{
    class License
    {
        public int Id { get; set; }
        
        [Required]
        public string  Name { get; set; }
    }
}
