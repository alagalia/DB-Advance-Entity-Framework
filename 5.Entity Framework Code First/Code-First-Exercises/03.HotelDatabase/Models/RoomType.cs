using System.ComponentModel.DataAnnotations;

namespace _03.HotelDatabase.Models
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public string Notes { get; set; }
    }
}