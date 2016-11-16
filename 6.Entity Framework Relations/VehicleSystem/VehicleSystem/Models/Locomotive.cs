using System.ComponentModel.DataAnnotations;
using VehicleSystem.Models.MotorVehicle;

namespace VehicleSystem.Models
{
    public class Locomotive
    {
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Power { get; set; }

        [Required]
        public Train Train { get; set; }
    }
}