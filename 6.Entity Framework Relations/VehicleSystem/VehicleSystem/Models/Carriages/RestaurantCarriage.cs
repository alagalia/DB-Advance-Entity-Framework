using System.ComponentModel.DataAnnotations;

namespace VehicleSystem.Models.Carriages
{
    public class RestaurantCarriage :Carriage
    {
        [Required]
        public int TableCount { get; set; } 
    }
}