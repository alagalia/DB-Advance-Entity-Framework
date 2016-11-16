using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.Models
{
    public abstract class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Phone]
        public string Phone { get; set; } 
    }
}