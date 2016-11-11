using System;
using System.ComponentModel.DataAnnotations;

namespace _03.HotelDatabase.Models
{
    public class Occupancy
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateOccupied { get; set; }

        public string AccountNumber { get; set; }

        public string RoomNumber { get; set; }

        public int RateApplied { get; set; }

        public decimal PhoneCharge { get; set; }

        public string Notes { get; set; }
    }
}