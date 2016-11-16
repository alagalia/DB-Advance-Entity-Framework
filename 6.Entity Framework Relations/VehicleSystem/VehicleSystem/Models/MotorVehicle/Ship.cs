using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.MotorVehicle
{
    public abstract class Ship :MotorVehicle
    {
        [Required]
        public string Nationality { get; set; }

        [Required]
        public string CapitanName { get; set; }

        public int SizeOfCrew { get; set; }
    }
}