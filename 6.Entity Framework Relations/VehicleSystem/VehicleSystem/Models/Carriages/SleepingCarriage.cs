using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.Carriages
{
    public class SleepingCarriage :Carriage
    {
        [Required]
        public int BedCount { get; set; } 
    }
}