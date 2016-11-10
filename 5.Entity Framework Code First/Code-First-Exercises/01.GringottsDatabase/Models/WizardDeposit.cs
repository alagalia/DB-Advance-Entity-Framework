using System;

namespace _01.GringottsDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class WizardDeposit
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "First name cannot be more than 50 characters!" )]
        public string FirstName { get; set; }

        [Required, MaxLength(60, ErrorMessage = "Last name cannot be more than 60 characters!")]
        public string LastName { get; set; }

        [MaxLength(1000, ErrorMessage = "Notes cannot be more than 1000 characters!")]
        public string Notes { get; set; }

        [Required]
        public int Age { get; set; }

        [MaxLength(100, ErrorMessage = "MagicWandCreator text must be 100 chars max!")]
        public string MagicWandCreator { get; set; }

        public int MagicWandSize  { get; set; }

        [MaxLength(20)]
        public string DepositGroup { get; set; }

        public DateTime DepositStartDate { get; set; }

        public decimal DepositAmount { get; set; }

        public float DepositInterest { get; set; }

        public double DepositCharge { get; set; }

        public DateTime DepositExpirationDate { get; set; }

        public bool IsDepositExpired { get; set; }
    }
}
