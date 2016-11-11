
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace _03.HotelDatabase.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AccountNumber { get; set; }

        [Required, MaxLength(50)]
        public string  FirstName { get; set; }

        [Required, MaxLength(50)]
        public string  LastName { get; set; }

        [Required, RegularExpression("\\d{6,}")]
        public string  PhoneNumber { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string EmergencyName { get; set; }

        [Required, RegularExpression("\\d{6,}")]
        public int EmergencyNumber { get; set; }

        public string Notes { get; set; }
    }
}
