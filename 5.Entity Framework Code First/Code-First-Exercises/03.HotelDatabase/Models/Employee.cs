
using System.ComponentModel.DataAnnotations;

namespace _03.HotelDatabase.Models
{
    public class Employee
    {
        [Key]
        public int Id  { get; set; }

        [Required, MinLength(3)]
        public string FirstName { get; set; }

        [Required, MinLength(3)]
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Notes { get; set; }
    }
}
