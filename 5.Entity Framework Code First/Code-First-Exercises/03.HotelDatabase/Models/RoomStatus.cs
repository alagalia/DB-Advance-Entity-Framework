using System.ComponentModel.DataAnnotations;

namespace _03.HotelDatabase.Models
{

    public class RoomStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        public string Notes { get; set; }

    }
}
