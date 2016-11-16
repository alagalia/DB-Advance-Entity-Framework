
using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.NonMotorVehicle
{
    public class Bike :NonMotorVehicle
    {
        [Required]
        public int ShiftCount { get; set; }

        public string Color { get; set; }
    }
}