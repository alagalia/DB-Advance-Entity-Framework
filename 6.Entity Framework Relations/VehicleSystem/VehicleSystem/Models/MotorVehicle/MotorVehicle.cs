using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.MotorVehicle
{
    public abstract class MotorVehicle :Vehicle
    {
        [Required]
        public int NumberOfEngines { get; set; }

        [Required]
        public string EngineType { get; set; }

        [Required]
        public int TankCapacity { get; set; }
    }
}