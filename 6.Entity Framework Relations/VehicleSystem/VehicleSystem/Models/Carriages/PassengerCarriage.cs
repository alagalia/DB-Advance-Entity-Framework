using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.Carriages
{
    public class PassengerCarriage :Carriage
    {
        [Required]
        public int StandingPassengersCapacity { get; set; }
    }
}