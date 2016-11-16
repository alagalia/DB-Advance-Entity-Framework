using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.MotorVehicle
{
    public class Plane :MotorVehicle
    {
        [Required]
        public string Owner { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int PassengersCapacity { get; set; }
    }
}